using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using Dapper;
using System.Dynamic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web;
using System.Web.Routing;
namespace Infrastructure.DynamicMySQLDb
{
    public abstract class MySQLDynamicDb : IDisposable
    {
        private MySqlConnection connection;
        public MySQLDynamicDb()
        {
        }

        public MySqlConnection GetOpenConnection()
        {

            /*This is going to need to change to the db we are using*/
            connection = new MySqlConnection("server=webdev.cs.uwosh.edu;user=moonn52;database=moonn52;port=4381;password=j382052");
            connection.Open();
            return connection;
        }

        public void Dispose()
        {
            this.connection.Dispose();
        }

        //going to need to change the schema to the appropriate name
        protected bool ExecuteQuery(string procedureName, Object args, string schema = "moonn52")
        {
            RouteValueDictionary dbArgsDictionary = new RouteValueDictionary(args);
            var dbArgs = new DynamicParameters();
            foreach (var pair in dbArgsDictionary)
            {
                dbArgs.Add(pair.Key, pair.Value);
            }
            dynamic dapperArgs = dbArgs;
            procedureName = schema + "." + procedureName;
            //try
            //{
                using (MySqlConnection connection = GetOpenConnection())
                {
                    return connection.Execute(procedureName, dbArgs, commandType: CommandType.StoredProcedure) > 0;
                }
            //}
            //catch (Exception ex)
            //{
            //    //return message here.
            //    throw ex;
            //}
        }

        protected IEnumerable<T> RunProcedure<T>(string procedureName, Object args, string schema = "moonn52")
        {
            RouteValueDictionary dbArgsDictionary = new RouteValueDictionary(args);
            var dbArgs = new DynamicParameters();
            foreach (var pair in dbArgsDictionary)
            {
                dbArgs.Add(pair.Key, pair.Value);
            }

            procedureName = schema + "." + procedureName;
            try
            {
                using (MySqlConnection connection = GetOpenConnection())
                {
                    return connection.Query<T>(procedureName, args, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                // return ex.Message;
                throw ex;
            }
        }

        protected IEnumerable<dynamic> RunProcedure(string procedureName, Object args, string schema = "moonn52")
        {
            RouteValueDictionary dbArgsDictionary = new RouteValueDictionary(args);
            var dbArgs = new DynamicParameters();
            foreach (var pair in dbArgsDictionary)
            {
                dbArgs.Add(pair.Key, pair.Value);
            }

            procedureName = schema + "." + procedureName;
            try
            {
                using (MySqlConnection connection = GetOpenConnection())
                {
                    return connection.Query(procedureName, args, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                // return ex.Message;
                throw ex;
            }
        }

		protected dynamic RawQuery ( string query, string schedma = "moonn52" )
		{
			try
			{
				using ( MySqlConnection connection = GetOpenConnection() )
				{
					return connection.Query( query );
				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}
    }
}