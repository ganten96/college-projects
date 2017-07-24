package calculator.lab6;

import android.content.Intent;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.text.Editable;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;


public class CreateAccount extends ActionBarActivity
{

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_create_account);
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_create_account, menu);
        return true;
    }

    public void CreateAccount(View v)
    {
        Database db = new Database(getApplicationContext());
        db.getWritableDatabase();
        String password = ((EditText) findViewById(R.id.CreatePassword)).getText().toString();
        String userName = ((EditText) findViewById(R.id.CreateUsername)).getText().toString();
        if((password.equals("") || userName.equals("")) && (userName.length() < 4 && password.length() < 4))
        {
            Toast.makeText(getApplicationContext(), "Bad Username or password. ", Toast.LENGTH_LONG).show();
            return;
        }
        else
        {
            long userId = db.InsertUser(userName, password);
            if(userId > 0)
            {
                //we did it
                Toast.makeText(getApplicationContext(), "Your account has been created!", Toast.LENGTH_LONG).show();
                //return to log in
                Intent intent = new Intent(this, LoginActivity.class);
                startActivity(intent);
            }
            else
            {
                Toast.makeText(getApplicationContext(), "An error ocurred while creating your account.", Toast.LENGTH_LONG).show();
            }
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
