package com.example.ganten96.calculator;

import android.app.AlertDialog;
import android.app.Dialog;
import android.app.Fragment;
import android.app.FragmentManager;
import android.app.FragmentTransaction;
import android.content.DialogInterface;
import android.content.Intent;
import android.net.Uri;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class MainActivity extends ActionBarActivity
        implements ButtonsFragment.OnFragmentInteractionListener,
        EquationFragment.OnFragmentInteractionListener,
        SolvedEquation.OnFragmentInteractionListener
{
    public String expressionString = "";
    public EquationFragment savedFrag;
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        EquationFragment expressionFragment = new EquationFragment();

        FragmentTransaction ft = getFragmentManager().beginTransaction();
        ft.add(R.id.ExpressionContainer, expressionFragment, "ExpressionFragment");
        ft.addToBackStack(null);
        ft.commit();
    }

    public void addToExpression(View v)
    {
        Button pressedButton = (Button)v;
        String pressedOperator = (String)pressedButton.getText();
        expressionString += pressedOperator;
        TextView expressionView = (TextView)findViewById(R.id.expressionEnter);
        expressionView.setText(expressionString);

    }

    public void removeFromExpression(View v)
    {
        if(expressionString.length() > 0)
        {
            expressionString = expressionString.substring(0, expressionString.length() - 1);
        }
        TextView expressionView = (TextView)findViewById(R.id.expressionEnter);
        expressionView.setText(expressionString);
    }

    public void deleteExpression(View v)
    {
        expressionString = "";
        TextView expressionView = (TextView)findViewById(R.id.expressionEnter);
        expressionView.setText(expressionString);
    }

    public void evaluateExpression(View v)
    {
        if(expressionString.length() > 0)
        {
            Bundle data = new Bundle();
            data.putString("EXPRESSION_STRING", expressionString);
            SolvedEquation frag = new SolvedEquation();
            savedFrag = (EquationFragment)getFragmentManager().findFragmentById(R.id.ExpressionContainer);
            frag.setArguments(data);
            FragmentTransaction ft = getFragmentManager().beginTransaction();
            ft.addToBackStack("ExpressionFragment");
            ft.replace(R.id.ExpressionContainer, frag);
            ft.commit();
        }
        else
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.setPositiveButton("OK", new DialogInterface.OnClickListener()
            {
                public void onClick(DialogInterface dialog, int id)
                {
                    dialog.dismiss();
                }
            });
            builder.setMessage("Please enter an expression.");
            builder.show();
        }
    }

    public void returnClick(View v)
    {
        ButtonsFragment bf = (ButtonsFragment)getFragmentManager().findFragmentById(R.id.ButtonContainer);

        FragmentManager fm = getFragmentManager();
        getFragmentManager().popBackStack();
        fm.beginTransaction()
                .setCustomAnimations(android.R.animator.fade_in, android.R.animator.fade_out)
                .show(bf)
                .remove(getFragmentManager().findFragmentById(R.id.ExpressionContainer))
                .commit();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
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

    @Override
    public void onFragmentInteraction(Uri uri)
    {

    }
}
