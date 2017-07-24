package calculator.lab6;

import android.provider.BaseColumns;

import java.io.Serializable;

/**
 * Created by Nick on 4/12/2015.
 */
public class Equation implements Serializable
{
    private String equation;
    private long userId;
    private long equationId;
    private String equationName;

    public Equation(String eq)
    {
        equation = eq;
    }

    public String getName()
    {
        return equationName;
    }

    public String getEquation()
    {
        return equation;
    }

    public long getEquationId()
    {
        return equationId;
    }


    public Equation(String eq, long usId, long eqId, String eqName)
    {
        equation = eq;
        userId = usId;
        equationId = eqId;
        equationName = eqName;
    }

    public static abstract class EquationTable implements BaseColumns
    {
        public static final String TABLE_NAME = "Equations";
        public static final String COLUMN_NAME_ID = "EquationId";
        public static final String COLUMN_NAME_EQUATION = "Equation";
        public static final String COLUMN_NAME_USERID = "UserId";
        public static final String COLUMN_NAME_NAME = "EquationName";
    }
}
