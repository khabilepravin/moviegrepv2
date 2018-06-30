using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace dataAccess
{
    public class DataAccessBase
    {
        private readonly string connectionString = string.Empty;
        private const string CONNECTION_CONFIG_KEY = "ConnectionString";

        public DataAccessBase()            
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_CONFIG_KEY].ConnectionString;
            }
        }

        public SqlConnection GetNewConnection()
        {
            SqlConnection conn = null;

            if (!string.IsNullOrEmpty(connectionString))
            {
                conn = new SqlConnection(connectionString);
            }
            else
            {
                throw new Exception(string.Format("Connection string configuration with the key '{0}' not found.", CONNECTION_CONFIG_KEY));
            }

            return conn;
        }

        /// <summary>
        /// Generic command creation method
        /// </summary>
        /// <returns></returns>
        public SqlCommand BuildCommand(string commandText, CommandType commandType, List<SqlParameter> commandParams)
        {
            SqlCommand comm = new SqlCommand(commandText);
            comm.CommandType = commandType;

            if (commandParams != null && commandParams.Count > 0)
            {
                foreach (SqlParameter param in commandParams)
                {
                    comm.Parameters.Add(param);
                }
            }

            return comm;
        }

        /// <summary>
        /// Just another overload for generic command creation 
        /// </summary>
        public SqlCommand GetCommand(string commandText, CommandType commandType)
        {
            return BuildCommand(commandText, commandType, null);
        }
    }
}
