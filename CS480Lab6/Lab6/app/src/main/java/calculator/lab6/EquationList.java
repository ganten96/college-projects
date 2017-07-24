package calculator.lab6;

import android.app.ListActivity;
import android.content.Intent;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AbsListView;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;


public class EquationList extends ListActivity
{
    private long userId;
    private ArrayList<Equation> equations;
    private EquationArrayAdapter adapter;
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        userId = getIntent().getExtras().getLong("UserId");
        Database db = new Database(getApplicationContext());
        equations = db.GetEquationsByUserId(userId);
        adapter = new EquationArrayAdapter(getApplicationContext(), equations);
        setListAdapter(adapter);
    }

    @Override
    protected void onListItemClick(ListView l, View v, int position, long id)
    {
        String equationName = ((TextView)(v.findViewById(R.id.EquationName))).getText().toString();//((TextView)findViewById(R.id.EquationName)).getText().toString();
        String equation = ((TextView)(v.findViewById(R.id.EquationString))).getText().toString();
        long eqId = Long.parseLong(((TextView)(v.findViewById(R.id.EquationListId))).getText().toString());
        Equation e = new Equation(equation, userId, eqId, equationName);

        Intent intent = new Intent(this, Calculator.class);
        intent.putExtra("Equation", e);
        intent.putExtra("UserId", userId);
        startActivity(intent);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_equation_list, menu);
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
