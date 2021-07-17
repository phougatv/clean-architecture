namespace Components.Value.Persistence.Base
{
    using Components.Value.Persistence.Poco;
    using Microsoft.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Data;

    internal class ValueDbContext
    {
        private readonly string _connectionString;
        private readonly ValueConfig _valueConfig;

        public ValueDbContext(IConfiguration configuration)
        {
            //_connectionString = configuration.GetConnectionString("MsSql");
            _valueConfig = configuration.GetSection("Value").Get<ValueConfig>();
            _connectionString = _valueConfig.ConnectionStrings["MsSql"];
        }

        internal bool Create(Value entity)
        {
            using var sqlConnection = new SqlConnection(_connectionString);        // Create a SQL Connection
            using var sqlCommand = new SqlCommand("CreateValue", sqlConnection);
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Add Input-Parameters
                sqlCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier));
                sqlCommand.Parameters["@Id"].Value = entity.Id;
                sqlCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 100));
                sqlCommand.Parameters["@Name"].Value = entity.Name;
                sqlCommand.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.UniqueIdentifier));
                sqlCommand.Parameters["@CreatedBy"].Value = entity.CreatedBy;
                sqlCommand.Parameters.Add(new SqlParameter("@UpdatedBy", SqlDbType.UniqueIdentifier));
                sqlCommand.Parameters["@UpdatedBy"].Value = entity.UpdatedBy;
                sqlCommand.Parameters.Add(new SqlParameter("@CreatedOn", SqlDbType.DateTime2));
                sqlCommand.Parameters["@CreatedOn"].Value = entity.CreatedOn;
                sqlCommand.Parameters.Add(new SqlParameter("@UpdatedOn", SqlDbType.DateTime2));
                sqlCommand.Parameters["@UpdatedOn"].Value = entity.UpdatedOn;

                // Add Output-Parameters
                sqlCommand.Parameters.Add(new SqlParameter("@isSuccess", SqlDbType.Bit));
                sqlCommand.Parameters["@isSuccess"].Direction = ParameterDirection.ReturnValue;

                var isSuccess = false;
                try
                {
                    sqlConnection.Open();               // Open the connection to DB.

                    sqlCommand.ExecuteNonQuery();       // Run the Stored-Procedure.

                    isSuccess = Convert.ToBoolean(sqlCommand.Parameters["@isSuccess"].Value);
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    sqlConnection.Close();
                }

                return isSuccess;
            }
        }
    }
}
