namespace Touchdevice.Dal
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public class DalLayer
    {
        private string conStr = ConfigurationManager.ConnectionStrings["TouchConStr"].ConnectionString;

        public bool CudCommand(SqlCommand cmd)
        {
            SqlConnection connection = new SqlConnection();
            bool flag = false;
            connection.ConnectionString = this.conStr;
            try
            {
                using (connection)
                {
                    cmd.Connection = connection;
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    using (cmd)
                    {
                        using (transaction)
                        {
                            try
                            {
                                cmd.Transaction = transaction;
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                                transaction.Commit();
                                return true;
                            }
                            catch (Exception)
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }
                        return flag;
                    }
                }
            }
            catch (Exception)
            {
            }
            return flag;
        }

        public bool cudsp(SqlParameter[] spParam, string spName)
        {
            bool flag;
            SqlConnection connection = new SqlConnection();
            SqlCommand command = connection.CreateCommand();
            try
            {
                using (connection)
                {
                    connection.ConnectionString = this.conStr;
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    SqlTransaction transaction2 = transaction;
                    try
                    {
                        using (command)
                        {
                            command.Transaction = transaction;
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = spName;
                            foreach (SqlParameter parameter in spParam)
                            {
                                command.Parameters.Add(parameter);
                            }
                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        flag = true;
                    }
                    catch (Exception exception)
                    {
                        transaction.Rollback();
                        throw exception;
                    }
                    finally
                    {
                        if (transaction2 != null)
                        {
                            transaction2.Dispose();
                        }
                    }
                }
            }
            catch (Exception exception2)
            {
                throw exception2;
            }
            return flag;
        }

        public DataTable ExecuteSelectsp(string spName)
        {
            DataTable table2;
            SqlConnection connection = new SqlConnection();
            SqlCommand selectCommand = connection.CreateCommand();
            try
            {
                using (connection)
                {
                    connection.ConnectionString = this.conStr;
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    SqlTransaction transaction2 = transaction;
                    try
                    {
                        DataTable table;
                        using (selectCommand)
                        {
                            selectCommand.Transaction = transaction;
                            selectCommand.CommandType = CommandType.StoredProcedure;
                            selectCommand.CommandText = spName;
                            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                            table = new DataTable();
                            adapter.Fill(table);
                        }
                        transaction.Commit();
                        table2 = table;
                    }
                    catch (Exception exception)
                    {
                        transaction.Rollback();
                        throw exception;
                    }
                    finally
                    {
                        if (transaction2 != null)
                        {
                            transaction2.Dispose();
                        }
                    }
                }
            }
            catch (Exception exception2)
            {
                throw exception2;
            }
            return table2;
        }

        public DataTable ExecuteSelectspWithParameter(SqlParameter[] spParam, string spName)
        {
            DataTable table2;
            SqlConnection connection = new SqlConnection();
            SqlCommand selectCommand = connection.CreateCommand();
            try
            {
                using (connection)
                {
                    connection.ConnectionString = this.conStr;
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    SqlTransaction transaction2 = transaction;
                    try
                    {
                        DataTable table;
                        using (selectCommand)
                        {
                            selectCommand.Transaction = transaction;
                            selectCommand.CommandType = CommandType.StoredProcedure;
                            selectCommand.CommandText = spName;
                            foreach (SqlParameter parameter in spParam)
                            {
                                selectCommand.Parameters.Add(parameter);
                            }
                            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                            table = new DataTable();
                            adapter.Fill(table);
                        }
                        transaction.Commit();
                        table2 = table;
                    }
                    catch (Exception exception)
                    {
                        transaction.Rollback();
                        throw exception;
                    }
                    finally
                    {
                        if (transaction2 != null)
                        {
                            transaction2.Dispose();
                        }
                    }
                }
            }
            catch (Exception exception2)
            {
                throw exception2;
            }
            return table2;
        }

        public bool ExeNonQuery(string query)
        {
            bool flag;
            SqlConnection connection = new SqlConnection();
            try
            {
                using (connection)
                {
                    connection.ConnectionString = this.conStr;
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlTransaction transaction = connection.BeginTransaction();
                    using (transaction)
                    {
                        try
                        {
                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                        catch (Exception exception)
                        {
                            transaction.Rollback();
                            throw exception;
                        }
                        flag = true;
                    }
                }
            }
            catch (Exception exception2)
            {
                throw exception2;
            }
            return flag;
        }

        public object ExeScalar(string query)
        {
            object obj3;
            SqlConnection connection = new SqlConnection();
            try
            {
                using (connection)
                {
                    object obj2 = null;
                    connection.ConnectionString = this.conStr;
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    try
                    {
                        using (command)
                        {
                            command.CommandType = CommandType.Text;
                            command.CommandText = query;
                            obj2 = command.ExecuteScalar();
                        }
                        obj3 = obj2;
                    }
                    catch (Exception exception)
                    {
                        throw exception;
                    }
                }
            }
            catch (Exception exception2)
            {
                throw exception2;
            }
            return obj3;
        }

        public string GetScalarValue(SqlCommand cmd)
        {
            object obj2;
            SqlConnection connection = new SqlConnection();
            using (connection)
            {
                connection.ConnectionString = this.conStr;
                cmd.Connection = connection;
                connection.Open();
                try
                {
                    using (cmd)
                    {
                        try
                        {
                            obj2 = cmd.ExecuteScalar();
                            cmd.Parameters.Clear();
                        }
                        catch (Exception)
                        {
                            obj2 = 0;
                        }
                    }
                }
                catch (Exception)
                {
                    obj2 = 0;
                }
            }
            return obj2.ToString().Trim();
        }

        public DataSet ReturnDataset(SqlCommand cmd)
        {
            SqlConnection connection = new SqlConnection();
            DataSet dataSet = new DataSet();
            connection.ConnectionString = this.conStr;
            try
            {
                using (connection)
                {
                    cmd.Connection = connection;
                    connection.Open();
                    new SqlDataAdapter(cmd).Fill(dataSet);
                    cmd.Parameters.Clear();
                }
            }
            catch (Exception)
            {
            }
            return dataSet;
        }

        public DataTable ReturnDataTable(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(this.conStr))
            {
                SqlCommand selectCommand = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                try
                {
                    adapter.Fill(dataTable);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return dataTable;
        }

        public object ReturnObject(SqlCommand cmd)
        {
            SqlConnection connection = new SqlConnection();
            object obj2 = null;
            connection.ConnectionString = this.conStr;
            try
            {
                using (connection)
                {
                    cmd.Connection = connection;
                    connection.Open();
                    obj2 = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                }
            }
            catch (Exception)
            {
            }
            return obj2;
        }

        public bool TabelHasRows(SqlCommand cmd)
        {
            SqlConnection connection = new SqlConnection();
            bool hasRows = false;
            using (connection)
            {
                connection.ConnectionString = this.conStr;
                cmd.Connection = connection;
                connection.Open();
                SqlDataReader reader = null;
                try
                {
                    using (cmd)
                    {
                        reader = cmd.ExecuteReader();
                        cmd.Parameters.Clear();
                    }
                    hasRows = reader.HasRows;
                }
                catch (Exception)
                {
                    hasRows = false;
                }
            }
            return hasRows;
        }
    }
}

