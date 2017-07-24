package com.example.ganten96.calculator;

import android.content.Intent;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.TextView;

import org.w3c.dom.Text;

import java.util.ArrayList;
import java.util.Stack;
import java.util.StringTokenizer;


public class SolvedExpression extends ActionBarActivity
{
    public String expressionString;
    public ArrayList<String> expressionList;
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_solved_expression);
        Intent intent = getIntent();
        expressionString = intent.getStringExtra("EXPRESSION_STRING");
        String postfixExpression = ConvertInfixToPostfix();
        TextView postfixView = (TextView)findViewById(R.id.postfix);
        postfixView.setText(expressionString + "\n" + postfixExpression + "\n");
        String answer = "Answer: " + PostFixEvaluator(postfixExpression);
        TextView answerView = (TextView)findViewById(R.id.answer);
        answerView.setText(answer);
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
                String step = "";
                for(String s: stacky)
                {
                    step += s + " ";
                }
                step += currentToken;
                step = PostfixToInfix(step);
                TextView postfixView = (TextView)findViewById(R.id.postfix);
                postfixView.append(step + "\n");
                step = "";

                String opX = stacky.pop();
                String opY = stacky.pop();
                stacky.push(evaluate(opX, opY, currentToken));
            }
        }
        return stacky.pop();
    }

    private String evaluate(String op2, String op1, String op)
    {
        Double op2Parsed = Double.parseDouble(op2);
        Double op1Parsed = Double.parseDouble(op1);
        String val = "";
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

    public String PostfixToInfix(String postfix)
    {
        Stack<String> stacky = new Stack<String>();
        StringTokenizer t = new StringTokenizer(postfix);
        while(t.hasMoreTokens())
        {
            String cToken = t.nextToken();

            if(isOperator(cToken))
            {
                String a = stacky.pop();
                String b = stacky.pop();

                stacky.push(a + " " + cToken + b);
            }
            else
            {
                stacky.push(" " + cToken);
            }
        }
        return stacky.pop();
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

    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_solved_expression, menu);
        return true;
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
