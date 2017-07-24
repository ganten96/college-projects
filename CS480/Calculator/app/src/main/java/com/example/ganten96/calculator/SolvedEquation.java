package com.example.ganten96.calculator;

import android.app.Activity;
import android.app.FragmentManager;
import android.app.FragmentTransaction;
import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.net.Uri;
import android.os.Bundle;
import android.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.RelativeLayout;
import android.widget.TextView;

import java.util.Stack;
import java.util.StringTokenizer;


/**
 * A simple {@link Fragment} subclass.
 * Activities that contain this fragment must implement the
 * {@link SolvedEquation.OnFragmentInteractionListener} interface
 * to handle interaction events.
 * Use the {@link SolvedEquation#newInstance} factory method to
 * create an instance of this fragment.
 */
public class SolvedEquation extends Fragment
{

    public String expressionString;

    private OnFragmentInteractionListener mListener;

    // TODO: Rename and change types and number of parameters
    public static SolvedEquation newInstance()
    {
        SolvedEquation fragment = new SolvedEquation();
        Bundle args = new Bundle();
        fragment.setArguments(args);
        return fragment;
    }

    public SolvedEquation()
    {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        if (getArguments() != null)
        {

        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState)
    {
        ButtonsFragment bf = (ButtonsFragment)getFragmentManager().findFragmentById(R.id.ButtonContainer);
        FragmentManager fm = getFragmentManager();
        fm.beginTransaction()
                .setCustomAnimations(android.R.animator.fade_in, android.R.animator.fade_out)
                .hide(bf)
                .show(this)
                .commit();
        View parentLayout = inflater.inflate(R.layout.fragment_solved_equation, container, false);
        Bundle b = this.getArguments();
        expressionString = b.getString("EXPRESSION_STRING");
        String postfixExpression = ConvertInfixToPostfix();
        TextView postfixView = (TextView) parentLayout.findViewById(R.id.postfix);
        postfixView.setText(expressionString + "\n" + postfixExpression + "\n");
        String answer = "Answer: " + PostFixEvaluator(postfixExpression, parentLayout);
        TextView answerView = (TextView)parentLayout.findViewById(R.id.answer);
        answerView.setText(answer);

        return parentLayout;
    }

    // TODO: Rename method, update argument and hook method into UI event
    public void onButtonPressed(Uri uri)
    {
        if (mListener != null)
        {
            mListener.onFragmentInteraction(uri);
        }
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

    public String PostFixEvaluator(String expression, View parent)
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
                /*final TextView dynamicText = new TextView(super.getActivity());
                dynamicText.setText(step);

                dynamicText.setOnClickListener(new View.OnClickListener()
                {
                    @Override
                    public void onClick(View v)
                    {

                            dynamicText.setBackgroundColor(Color.GREEN);

                            //dynamicText.setBackgroundColor(defaultColor);

                    }
                });

                RelativeLayout layout = (RelativeLayout)getActivity().findViewById(R.id.ExpressionContainer);
                LayoutInflater.from(getActivity()).inflate(R.layout.fragment_solved_equation, layout, false);
                layout.addView(dynamicText);*/
                TextView postfixView = (TextView)parent.findViewById(R.id.postfix);
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
    public void onAttach(Activity activity)
    {
        super.onAttach(activity);
        try
        {
            mListener = (OnFragmentInteractionListener) activity;
        } catch (ClassCastException e)
        {
            throw new ClassCastException(activity.toString()
                    + " must implement OnFragmentInteractionListener");
        }
    }

    @Override
    public void onDetach()
    {
        super.onDetach();
        mListener = null;
    }

    /**
     * This interface must be implemented by activities that contain this
     * fragment to allow an interaction in this fragment to be communicated
     * to the activity and potentially other fragments contained in that
     * activity.
     * <p/>
     * See the Android Training lesson <a href=
     * "http://developer.android.com/training/basics/fragments/communicating.html"
     * >Communicating with Other Fragments</a> for more information.
     */
    public interface OnFragmentInteractionListener
    {
        // TODO: Update argument type and name
        public void onFragmentInteraction(Uri uri);
    }

}
