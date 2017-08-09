using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Xml;


namespace ParserIO.DAL
{
    public class DataBaseHelper
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CS"].ToString();

        private SqlConnection connection;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public DataBaseHelper()
        {
        }

        public DataBaseHelper(string connection)
        {
            connectionString = connection;
        }

        public DataSet ExecuteStoredProcedure(string procedureName, List<SqlParameter> parameters = null)
        {
            DataSet result = new DataSet();
            using (connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    using (SqlCommand command = new SqlCommand(procedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                            command.Parameters.AddRange(parameters.ToArray());

                        adapter.SelectCommand = command;
                        adapter.Fill(result);
                    }
                }
            }

            return result;
        }

        public XmlReader ExecuteXmlQuery(string query, List<SqlParameter> parameters = null)
        {
            XmlReader result = null;
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;

                    if (parameters != null)
                        command.Parameters.AddRange(parameters.ToArray());

                    result = command.ExecuteXmlReader();
                }
            }

            return result;
        }

        public DataSet ExecuteTextQuery(string query, List<SqlParameter> parameters = null)
        {
            DataSet result = new DataSet();
            using (connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.Text;

                        if (parameters != null)
                            command.Parameters.AddRange(parameters.ToArray());

                        adapter.SelectCommand = command;
                        adapter.Fill(result);
                    }
                }
            }

            return result;
        }

        public Object ExecuteScalarTextQuery(string query, List<SqlParameter> parameters = null)
        {
            Object result = null;
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;

                    if (parameters != null)
                        command.Parameters.AddRange(parameters.ToArray());

                    result = command.ExecuteScalar();
                }

            }

            return result;
        }

        public object ExecuteScalarStoredProcedure(string procedureName, List<SqlParameter> parameters = null)
        {
            object result = new object();
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                        command.Parameters.AddRange(parameters.ToArray());

                    result = command.ExecuteScalar();
                }

            }

            return result;
        }

        public int? ExecuteNonQueryStoredProcedure(string procedureName, SqlParameter outParameter = null, List<SqlParameter> parameters = null)
        {
            int? result = null;
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                        command.Parameters.AddRange(parameters.ToArray());

                    if (outParameter != null)
                        command.Parameters.Add(outParameter);

                    int executionResult = command.ExecuteNonQuery();
                    //if (executionResult != -1 && outParameter != null)
                    //    result = (int)outParameter.Value;
                    result = executionResult;
                }
            }

            return result;
        }

        public int? ExecuteNonQueryStoredProcedure_1(string procedureName, List<SqlParameter> outParameter = null, List<SqlParameter> parameters = null)
        {
            int? result = null;
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                        command.Parameters.AddRange(parameters.ToArray());

                    if (outParameter != null)
                        command.Parameters.AddRange(outParameter.ToArray());

                    int executionResult = command.ExecuteNonQuery();
                    //if (executionResult != -1 && outParameter != null)
                    //    result = (int)outParameter

                }
            }

            return result;
        }

        private SqlParameter[] GetParameters(Dictionary<string, object> parameters)
        {
            return parameters.Select(e => new SqlParameter(e.Key, e.Value)).ToArray();
        }

        public SqlParameter GetParameter(string name, object value, SqlDbType type)
        {
            SqlParameter result = new SqlParameter(name, type);
            result.Value = value;

            return result;
        }
    }
}