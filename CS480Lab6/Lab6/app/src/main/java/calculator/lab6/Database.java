package calculator.lab6;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.widget.Toast;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

/**
 * Created by Nick on 4/12/2015.
 */
public class Database extends SQLiteOpenHelper
{
    public static final int DATABASE_VERSION = 1;
    public static final String DATABASE_NAME = "Calculator.db";
    public Database(Context context)
    {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }

    @Override
    public void onCreate(SQLiteDatabase db)
    {
        String userTable = "CREATE TABLE " + User.UserTable.TABLE_NAME + "" +
                "(" +
                    User.UserTable.COLUMN_NAME_ID + " INTEGER PRIMARY KEY," +
                    User.UserTable.COLUMN_NAME_USERNAME + " TEXT," +
                    User.UserTable.COLUMN_NAME_PASSWORD + " TEXT" +
                ");";
        String equationTable = "CREATE TABLE " + Equation.EquationTable.TABLE_NAME +
                                "(" +
                                    Equation.EquationTable.COLUMN_NAME_ID + " INTEGER PRIMARY KEY," +
                                    Equation.EquationTable.COLUMN_NAME_EQUATION + " TEXT," +
                                    Equation.EquationTable.COLUMN_NAME_USERID + " INTEGER," +
                                    Equation.EquationTable.COLUMN_NAME_NAME + " TEXT," +
                                    "FOREIGN KEY (UserId) REFERENCES Users(UserId)" +
                                ")";
        String variableTable = "CREATE TABLE " + EquationVariables.VariableTable.TABLE_NAME +
                                "(" +
                                    EquationVariables.VariableTable.COLUMN_NAME_EQID + " INTEGER," +
                                    EquationVariables.VariableTable.COLUMN_NAME_VARIABLE + " TEXT," +
                                    EquationVariables.VariableTable.COLUMN_NAME_VARIABLE_ID + " INTEGER PRIMARY KEY," +
                                    EquationVariables.VariableTable.COLUMN_NAME_VALUE + " TEXT, " +
                                    "FOREIGN KEY(EquationId) REFERENCES Equation(EquationId)" +
                                ")";

        //table creation.
        db.execSQL(userTable);
        db.execSQL(equationTable);
        db.execSQL(variableTable);
    }

    public long InsertUser(String userName, String password)
    {
        ContentValues values = new ContentValues();
        values.put("UserName", userName);
        values.put("Password", password);
        SQLiteDatabase localDb = getWritableDatabase();
        long id = localDb.insert(User.UserTable.TABLE_NAME, null, values);
        localDb.close();
        return id;
    }

    public ArrayList<Equation> GetEquationsByUserId(long userId)
    {
        ArrayList<Equation> equations = new ArrayList<>();
        SQLiteDatabase db = getReadableDatabase();
        Cursor items = db.query("Equations", new String[]{"EquationName", "EquationId", "Equation"}, "UserId = " + userId, null, null, null, null);
        items.moveToFirst();
        while(items.isAfterLast() == false)
        {
            String eqName = items.getString(0);
            long eqId = items.getLong(1);
            String equation = items.getString(2);
            Equation eq = new Equation(eqName, userId, eqId, equation);
            equations.add(eq);
            items.moveToNext();
        }
        return equations;
    }

    public long SaveEquation(String name, String equation, HashMap<String, String> variables, long userId)
    {
        SQLiteDatabase localDb = getWritableDatabase();
        ContentValues vals = new ContentValues();
        vals.put("EquationName", name);
        vals.put("Equation", equation);
        vals.put("UserId", userId);
        long equationId = localDb.insert("Equations", null, vals);
        if(equationId > 0)
        {
            //insert variables
            for(Map.Entry<String, String> entry : variables.entrySet())
            {
                ContentValues varvals = new ContentValues();
                varvals.put("Variable", entry.getKey());
                varvals.put("VariableValue", entry.getValue());
                varvals.put("EquationId", equationId);
                long variableId = localDb.insert("EquationVariables", null, varvals);
                if(variableId == 0)
                {
                    return 0; //error
                }
            }
            return equationId;
        }
        else
        {
            return 0;
        }
    }

    public HashMap<String, String> GetVariablesForEquation(long equationId)
    {
        SQLiteDatabase localdb = getReadableDatabase();
        Cursor c = localdb.query("EquationVariables", new String[] { "Variable", "VariableValue" }, "EquationId = " + equationId, null, null, null, null);
        c.moveToFirst();
        HashMap<String, String> vars = new HashMap<>();
        while(!c.isAfterLast())
        {
            String variable = c.getString(0);
            String value = c.getString(1);
            vars.put(variable, value);
            c.moveToNext();
        }
        return vars;
    }

    public long LogInUser(String userName, String password)
    {
        SQLiteDatabase localDb = getReadableDatabase();
        ContentValues vals = new ContentValues();
        vals.put("Username", userName);
        vals.put("Password", password);
        Cursor c = localDb.query("Users", new String[] {"UserId"} ,"Password = '" + password + "' AND UserName = '" + userName + "'", null, null, null, null);
        c.moveToFirst();
        long userId = 0;
        try
        {
            userId = c.getLong(c.getColumnIndexOrThrow(User.UserTable.COLUMN_NAME_ID));
        }
        catch(Exception e)
        {
            e.printStackTrace();
        }
        localDb.close();
        return userId;
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
    {
        onCreate(db);
    }
}
