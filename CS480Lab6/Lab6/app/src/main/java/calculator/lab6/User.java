package calculator.lab6;

import android.provider.BaseColumns;

/**
 * Created by Nick on 4/12/2015.
 */
public final class User
{
    public User(){};
    public static abstract class UserTable implements BaseColumns
    {
        public static final String TABLE_NAME = "Users";
        public static final String COLUMN_NAME_ID = "UserId";
        public static final String COLUMN_NAME_USERNAME = "UserName";
        public static final String COLUMN_NAME_PASSWORD = "Password";
    }
}
