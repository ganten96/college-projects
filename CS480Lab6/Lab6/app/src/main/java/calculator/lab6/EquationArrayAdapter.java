package calculator.lab6;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import java.util.ArrayList;

/**
 * Created by ganten96 on 4/16/2015.
 */
public class EquationArrayAdapter extends ArrayAdapter<Equation>
{

    private Context context;
    private ArrayList<Equation> equations;

    public EquationArrayAdapter(Context context, ArrayList<Equation> eqs)
    {
        super(context, R.layout.equation_list, eqs);
        this.context = context;
        this.equations = eqs;
    }

    public View getView(int key, View convertView, ViewGroup parent)
    {
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View rowView = inflater.inflate(R.layout.equation_list, parent, false);
        TextView equationName = (TextView) rowView.findViewById(R.id.EquationName);
        TextView equation = (TextView) rowView.findViewById(R.id.EquationString);
        TextView id = (TextView) rowView.findViewById(R.id.EquationListId);
        equationName.setText(equations.get(key).getName());
        equation.setText(equations.get(key).getEquation());
        long eqid = equations.get(key).getEquationId();
        id.setText(eqid + "");
        return rowView;
    }
}
