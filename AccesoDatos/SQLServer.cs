using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace AccesoDatos
{
    public class SQLServer
    {
        private readonly string _connectionString;

        public SQLServer(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void NonQuery(string query, SqlParameter[]? parameters = null)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection) {  })
                    {
                        command.CommandType = CommandType.Text;

                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        connection.Open();

                        if (command.ExecuteNonQuery() == 0)
                        {
                            throw new Exception("No hubo cambios en registros.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T? Reader<T>(string query, SqlParameter[]? parameters = null) where T : class, new()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.Text;

                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        connection.Open();

                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            if (dataReader.Read())
                            {
                                T resultType = new ();
                                
                                int count = dataReader.FieldCount - 1;
                                for (int i = 0; i <= count; i++)
                                {
                                    string columna = dataReader.GetName(i);
                                    
                                    PropertyInfo propiedad = typeof(T).GetProperty(columna);
                                    if (propiedad != null && !dataReader.IsDBNull(i))
                                    {
                                        propiedad.SetValue(resultType, dataReader.GetValue(i));
                                    }
                                }
                                return resultType;
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public List<T>? ReaderList<T>(string query, SqlParameter[]? parameters = null) where T : new()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.Text;

                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        connection.Open();

                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            List<T> lista = new List<T>();

                            while (dataReader.Read())
                            {
                                T resultType = new ();

                                for (int i = 0; i < dataReader.FieldCount; i++)
                                {
                                    string nombreColumna = dataReader.GetName(i);
                                    
                                    PropertyInfo propiedad = typeof(T).GetProperty(nombreColumna);
                                    if (propiedad != null && !dataReader.IsDBNull(i))
                                    {
                                        object valor = dataReader.GetValue(i);
                                        propiedad.SetValue(resultType, valor);
                                    }
                                }

                                lista.Add(resultType);
                            }
                            return lista;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

    }
}

