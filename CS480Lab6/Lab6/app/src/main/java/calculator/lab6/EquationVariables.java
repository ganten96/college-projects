package calculator.lab6;

import android.provider.BaseColumns;

/**
 * Created by Nick on 4/12/2015.
 */
public class EquationVariables
{
    public static abstract class VariableTable implements BaseColumns
    {
        public static String TABLE_NAME = "EquationVariables";
        public static String COLUMN_NAME_VARIABLE_ID = "VariableId";
        public static String COLUMN_NAME_VARIABLE = "Variable";
        public static String COLUMN_NAME_EQID = "EquationId";
        public static String COLUMN_NAME_VALUE = "VariableValue";
    }
}
