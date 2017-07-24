package calculator.lab6;

import android.content.Intent;
import android.database.sqlite.SQLiteDatabase;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import org.w3c.dom.Text;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.Stack;
import java.util.StringTokenizer;


public class Calculator extends ActionBarActivity
{
    private long userId;
    private String postfixExpression;
    private HashMap<String, String> variables;
    String expressionString = "";
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_calculator);
        userId = getIntent().getExtras().getLong("UserId");
        Equation e = (Equation)getIntent().getExtras().getSerializable("Equation");
        if(e != null)
        {
            Database db = new Database(getApplicationContext());
            variables = db.GetVariablesForEquation(e.getEquationId());
            String varString = "";
            for(Map.Entry<String, String> entry : variables.entrySet())
            {
                varString += entry.getKey() + " = " + entry.getValue() + ";";
            }

            ((TextView) findViewById(R.id.varBox)).setText(varString);
            ((TextView) findViewById(R.id.equationName)).setText(e.getEquation());
            ((TextView) findViewById(R.id.expressionEnter)).setText(e.getName());
            Toast.makeText(getApplicationContext(), "Equation loaded successfully!", Toast.LENGTH_LONG).show();
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_calculator, menu);
        return true;
    }

    private void parseVariables()
    {
        variables = new HashMap<String, String>();
        EditText varBox = (EditText)findViewById(R.id.varBox);
        String vars = varBox.getText().toString();

        String[] varArray = vars.split(";");
        if(!vars.equals(""))
        {
            for(String var : varArray)
            {
                try
                {
                    if(varArray.length > 0)
                    {
                        String[] varAssign = var.split(" = ");
                        String key = varAssign[0];
                        String value = varAssign[1];
                        variables.put(key, value);
                    }
                }
                catch (Exception e)
                {
                    Toast.makeText(getApplicationContext(), "Invalid variable expression.", Toast.LENGTH_LONG).show();
                    return;
                }
            }
        }
    }

    public void saveEquation(View v)
    {
        String equation = ((EditText) findViewById(R.id.expressionEnter)).getText().toString();
        String name = ((EditText) findViewById(R.id.equationName)).getText().toString();
        parseVariables();
        //send them off to the database.
        Database db = new Database(getApplicationContext());
        long eqId = db.SaveEquation(name, equation, variables, userId);
        if(eqId > 0)
        {
            Toast.makeText(getApplicationContext(), "Equation Saved successfully.", Toast.LENGTH_LONG).show();
        }
        else
        {
            Toast.makeText(getApplicationContext(), "Equation was not saved.", Toast.LENGTH_LONG).show();
        }
    }

    public void getEquationsByUserId(View v)
    {
        Intent intent = new Intent(this, EquationList.class);
        intent.putExtra("UserId", userId);
        startActivity(intent);
    }


    public void evalExpression(View v)
    {
        expressionString = ((EditText)findViewById(R.id.expressionEnter)).getText().toString();
        if(!expressionString.contains(" ") || expressionString.equals(""))
        {
            Toast.makeText(getApplicationContext(), "Please enter a valid equation. Each operator must be separated by a space.", Toast.LENGTH_LONG);
            return;
        }
        parseVariables();
        for(String s : variables.keySet())
        {
            if(expressionString.contains(s))
            {
                expressionString = expressionString.replace(s, variables.get(s).toString());
            }
        }
        postfixExpression = ConvertInfixToPostfix();
        String ans = PostFixEvaluator(postfixExpression);
        TextView ansView = (TextView)findViewById(R.id.answer);
        ansView.setText(ans);
    }

    private int precedence(String op)
    {
        int precedence = 0;
        switch(op)
        {
            case "+":
                precedence = 1;
                break;
            case "-":
                precedence = 1;
                break;
            case "/":
                precedence = 2;
                break;
            case "*":
                precedence = 2;
                break;
            case "%":
                precedence = 2;
                break;
        }
        return precedence;
    }

    private boolean isOperator(String op)
    {
        boolean isOp = false;
        switch(op)
        {
            case "+":
                isOp = true;
                break;
            case "-":
                isOp = true;
                break;
            case "/":
                isOp = true;
                break;
            case "*":
                isOp = true;
                break;
            case "%":
                isOp = true;
                break;
        }
        return isOp;
    }

    public String PostFixEvaluator(String expression)
    {
        Stack<String> stacky = new Stack<String>(); //in memoriam of Samuel Micka, graduated Dec 2014.
        //stacky has been used as our faithful stack in many an ACM problem.
        StringTokenizer tokenizer = new StringTokenizer(expression, " ");
        while(tokenizer.hasMoreTokens())
        {
            String currentToken = tokenizer.nextToken();
            if(!isOperator(currentToken))
            {
                stacky.push(currentToken);
            }
            if(isOperator(currentToken))
            {
                String opX = stacky.pop();
                String opY = stacky.pop();
                stacky.push(evaluate(opX, opY, currentToken));
            }
        }
        return stacky.pop();
    }


    public String ConvertInfixToPostfix()
    {
        Stack<String> stack = new Stack<String>();
        String convertedExpression = "";
        StringTokenizer tokenizer = new StringTokenizer(expressionString, " ");
        while(tokenizer.hasMoreTokens())
        {
            String currentToken = tokenizer.nextToken();
            if(currentToken.equals("("))
            {
                stack.push(currentToken);
            }
            else if(!isOperator(currentToken) && (!currentToken.equals("(") && !currentToken.equals(")")))
            {
                convertedExpression += currentToken + " ";
            }
            else if(currentToken.equals(")"))
            {
                while(!stack.peek().equals("("))
                {
                    String s = stack.pop();
                    convertedExpression += s + " ";
                }
                stack.pop();
            }
            if(isOperator(currentToken))
            {
                while(!stack.isEmpty() && !stack.peek().equals("(")
                        && precedence(currentToken) <= precedence(stack.peek()))
                {
                    String s = stack.pop();
                    convertedExpression += s + " ";
                }
                stack.push(currentToken);
            }
        }
        while(!stack.isEmpty())
        {
            String s = stack.pop();
            convertedExpression += s + " ";
        }
        return convertedExpression;
    }

    private String evaluate(String op2, String op1, String op)
    {
        String val = "";
        try
        {
            Double op2Parsed = Double.parseDouble(op2);
            Double op1Parsed = Double.parseDouble(op1);
            switch(op)
            {
                case "+":
                    val = op1Parsed + op2Parsed + "";
                    break;
                case "-":
                    val = (op1Parsed - op2Parsed) + "";
                    break;
                case "*":
                    val = (op1Parsed * op2Parsed) + "";
                    break;
                case "/":
                    if(op2.contains("."))
                    {
                        val = (op1Parsed / op2Parsed) + "";
                    }
                    else
                    {
                        val = (int)Math.floor((op1Parsed / op2Parsed)) + "";
                    }
                    break;
                case "%":
                    val = (int)(op1Parsed % op2Parsed) + "";
                    break;
            }
            return val;
        }
        catch (Exception e)
        {
            Toast.makeText(getApplicationContext(), "Error evaluating. Equation is invalid.", Toast.LENGTH_LONG);
            return val;
        }
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item)
    {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings)
        {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
