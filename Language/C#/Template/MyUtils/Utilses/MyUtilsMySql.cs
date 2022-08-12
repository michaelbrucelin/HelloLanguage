using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace WindowsFormsApp0
{
    public static class MyUtilsMySql
    {
        private static readonly CommandType defCmdType = CommandType.Text;
        private static readonly int defCmdTimeout = 30;

        #region 同步方法
        #region ExecuteNonQuery
        public static int ExecuteNonQuery(string connStr, string sql, bool compress = false, params SqlParameter[] pms)
        {
            return ExecuteNonQuery(connStr, defCmdType, sql, defCmdTimeout, compress, pms);
        }

        public static int ExecuteNonQuery(string connStr, CommandType cmdType, string sql, bool compress = false, params SqlParameter[] pms)
        {
            return ExecuteNonQuery(connStr, cmdType, sql, defCmdTimeout, compress, pms);
        }

        public static int ExecuteNonQuery(string connStr, string sql, int cmdTimeout, bool compress = false, params SqlParameter[] pms)
        {
            return ExecuteNonQuery(connStr, defCmdType, sql, cmdTimeout, compress, pms);
        }

        public static int ExecuteNonQuery(string connStr, CommandType cmdType, string sql, int cmdTimeout, bool compress, params SqlParameter[] pms)
        {
            if (compress)
            {
                MySqlConnectionStringBuilder mysqlsb = new MySqlConnectionStringBuilder(connStr);
                mysqlsb.UseCompression = true;
                connStr = mysqlsb.ConnectionString;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.CommandType = cmdType;
                        cmd.CommandTimeout = cmdTimeout;
                        if (pms != null)
                        {
                            cmd.Parameters.AddRange(pms);
                        }
                        conn.Open();

                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region ExecuteScalar
        public static object ExecuteScalar(string connStr, string sql, bool compress = false, params SqlParameter[] pms)
        {
            return ExecuteScalar(connStr, defCmdType, sql, defCmdTimeout, compress, pms);
        }

        public static object ExecuteScalar(string connStr, CommandType cmdType, string sql, bool compress = false, params SqlParameter[] pms)
        {
            return ExecuteScalar(connStr, cmdType, sql, defCmdTimeout, compress, pms);
        }

        public static object ExecuteScalar(string connStr, string sql, int cmdTimeout, bool compress = false, params SqlParameter[] pms)
        {
            return ExecuteScalar(connStr, defCmdType, sql, cmdTimeout, compress, pms);
        }

        public static object ExecuteScalar(string connStr, CommandType cmdType, string sql, int cmdTimeout, bool compress, params SqlParameter[] pms)
        {
            if (compress)
            {
                MySqlConnectionStringBuilder mysqlsb = new MySqlConnectionStringBuilder(connStr);
                mysqlsb.UseCompression = true;
                connStr = mysqlsb.ConnectionString;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.CommandType = cmdType;
                        cmd.CommandTimeout = cmdTimeout;
                        if (pms != null)
                        {
                            cmd.Parameters.AddRange(pms);
                        }
                        conn.Open();

                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region ExecuteReader
        public static MySqlDataReader ExecuteReader(string connStr, string sql, bool compress = false, params SqlParameter[] pms)
        {
            return ExecuteReader(connStr, defCmdType, sql, defCmdTimeout, compress, pms);
        }

        public static MySqlDataReader ExecuteReader(string connStr, CommandType cmdType, string sql, bool compress = false, params SqlParameter[] pms)
        {
            return ExecuteReader(connStr, cmdType, sql, defCmdTimeout, compress, pms);
        }

        public static MySqlDataReader ExecuteReader(string connStr, string sql, int cmdTimeout, bool compress = false, params SqlParameter[] pms)
        {
            return ExecuteReader(connStr, defCmdType, sql, cmdTimeout, compress, pms);
        }

        public static MySqlDataReader ExecuteReader(string connStr, CommandType cmdType, string sql, int cmdTimeout, bool compress, params SqlParameter[] pms)
        {
            if (compress)
            {
                MySqlConnectionStringBuilder mysqlsb = new MySqlConnectionStringBuilder(connStr);
                mysqlsb.UseCompression = true;
                connStr = mysqlsb.ConnectionString;
            }

            try
            {
                // 由于SqlDataReader是面向连接的，所以SQLConnection不能Close，故没有写在using中
                MySqlConnection conn = new MySqlConnection(connStr);
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandTimeout = cmdTimeout;
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    conn.Open();

                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region ExecuteDataTable
        public static DataTable ExecuteDataTable(string connStr, string sql, bool compress = false, params SqlParameter[] pms)
        {
            return ExecuteDataTable(connStr, defCmdType, sql, defCmdTimeout, compress, pms);
        }

        public static DataTable ExecuteDataTable(string connStr, CommandType cmdType, string sql, bool compress = false, params SqlParameter[] pms)
        {
            return ExecuteDataTable(connStr, cmdType, sql, defCmdTimeout, compress, pms);
        }

        public static DataTable ExecuteDataTable(string connStr, string sql, int cmdTimeout, bool compress = false, params SqlParameter[] pms)
        {
            return ExecuteDataTable(connStr, defCmdType, sql, cmdTimeout, compress, pms);
        }

        public static DataTable ExecuteDataTable(string connStr, CommandType cmdType, string sql, int cmdTimeout, bool compress, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();

            if (compress)
            {
                MySqlConnectionStringBuilder mysqlsb = new MySqlConnectionStringBuilder(connStr);
                mysqlsb.UseCompression = true;
                connStr = mysqlsb.ConnectionString;
            }

            try
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connStr))
                {
                    adapter.SelectCommand.CommandType = cmdType;
                    adapter.SelectCommand.CommandTimeout = cmdTimeout;
                    if (pms != null)
                    {
                        adapter.SelectCommand.Parameters.AddRange(pms);
                    }
                    adapter.Fill(dt);

                    return dt;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region ExecuteDataSet
        public static DataSet ExecuteDataSet(string connStr, string sql, bool compress = false, params SqlParameter[] pms)
        {
            return ExecuteDataSet(connStr, defCmdType, sql, defCmdTimeout, compress, pms);
        }

        public static DataSet ExecuteDataSet(string connStr, CommandType cmdType, string sql, bool compress = false, params SqlParameter[] pms)
        {
            return ExecuteDataSet(connStr, cmdType, sql, defCmdTimeout, compress, pms);
        }

        public static DataSet ExecuteDataSet(string connStr, string sql, int cmdTimeout, bool compress = false, params SqlParameter[] pms)
        {
            return ExecuteDataSet(connStr, defCmdType, sql, cmdTimeout, compress, pms);
        }

        public static DataSet ExecuteDataSet(string connStr, CommandType cmdType, string sql, int cmdTimeout, bool compress, params SqlParameter[] pms)
        {
            DataSet ds = new DataSet();

            if (compress)
            {
                MySqlConnectionStringBuilder mysqlsb = new MySqlConnectionStringBuilder(connStr);
                mysqlsb.UseCompression = true;
                connStr = mysqlsb.ConnectionString;
            }

            try
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connStr))
                {
                    adapter.SelectCommand.CommandType = cmdType;
                    adapter.SelectCommand.CommandTimeout = cmdTimeout;
                    if (pms != null)
                    {
                        adapter.SelectCommand.Parameters.AddRange(pms);
                    }
                    adapter.Fill(ds);

                    return ds;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #endregion

        #region 异步方法
        #region ExecuteNonQueryAsync
        public async static Task<int> ExecuteNonQueryAsync(string connStr, string sql, bool compress = false, params SqlParameter[] pms)
        {
            return await ExecuteNonQueryAsync(connStr, defCmdType, sql, defCmdTimeout, compress, pms);
        }

        public async static Task<int> ExecuteNonQueryAsync(string connStr, CommandType cmdType, string sql, bool compress = false, params SqlParameter[] pms)
        {
            return await ExecuteNonQueryAsync(connStr, cmdType, sql, defCmdTimeout, compress, pms);
        }

        public async static Task<int> ExecuteNonQueryAsync(string connStr, string sql, int cmdTimeout, bool compress = false, params SqlParameter[] pms)
        {
            return await ExecuteNonQueryAsync(connStr, defCmdType, sql, cmdTimeout, compress, pms);
        }

        public async static Task<int> ExecuteNonQueryAsync(string connStr, CommandType cmdType, string sql, int cmdTimeout, bool compress, params SqlParameter[] pms)
        {
            if (compress)
            {
                MySqlConnectionStringBuilder mysqlsb = new MySqlConnectionStringBuilder(connStr);
                mysqlsb.UseCompression = true;
                connStr = mysqlsb.ConnectionString;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.CommandType = cmdType;
                        cmd.CommandTimeout = cmdTimeout;
                        if (pms != null)
                        {
                            cmd.Parameters.AddRange(pms);
                        }
                        conn.Open();

                        return await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region ExecuteScalarAsync
        public async static Task<object> ExecuteScalarAsync(string connStr, string sql, bool compress = false, params SqlParameter[] pms)
        {
            return await ExecuteScalarAsync(connStr, defCmdType, sql, defCmdTimeout, compress, pms);
        }

        public async static Task<object> ExecuteScalarAsync(string connStr, CommandType cmdType, string sql, bool compress = false, params SqlParameter[] pms)
        {
            return await ExecuteScalarAsync(connStr, cmdType, sql, defCmdTimeout, compress, pms);
        }

        public async static Task<object> ExecuteScalarAsync(string connStr, string sql, int cmdTimeout, bool compress = false, params SqlParameter[] pms)
        {
            return await ExecuteScalarAsync(connStr, defCmdType, sql, cmdTimeout, compress, pms);
        }

        public async static Task<object> ExecuteScalarAsync(string connStr, CommandType cmdType, string sql, int cmdTimeout, bool compress, params SqlParameter[] pms)
        {
            if (compress)
            {
                MySqlConnectionStringBuilder mysqlsb = new MySqlConnectionStringBuilder(connStr);
                mysqlsb.UseCompression = true;
                connStr = mysqlsb.ConnectionString;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.CommandType = cmdType;
                        cmd.CommandTimeout = cmdTimeout;
                        if (pms != null)
                        {
                            cmd.Parameters.AddRange(pms);
                        }
                        conn.Open();

                        return await cmd.ExecuteScalarAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region ExecuteReaderAsync
        public async static Task<MySqlDataReader> ExecuteReaderAsync(string connStr, string sql, bool compress = false, params SqlParameter[] pms)
        {
            return await ExecuteReaderAsync(connStr, defCmdType, sql, defCmdTimeout, compress, pms);
        }

        public async static Task<MySqlDataReader> ExecuteReaderAsync(string connStr, CommandType cmdType, string sql, bool compress = false, params SqlParameter[] pms)
        {
            return await ExecuteReaderAsync(connStr, cmdType, sql, defCmdTimeout, compress, pms);
        }

        public async static Task<MySqlDataReader> ExecuteReaderAsync(string connStr, string sql, int cmdTimeout, bool compress = false, params SqlParameter[] pms)
        {
            return await ExecuteReaderAsync(connStr, defCmdType, sql, cmdTimeout, compress, pms);
        }

        public async static Task<MySqlDataReader> ExecuteReaderAsync(string connStr, CommandType cmdType, string sql, int cmdTimeout, bool compress, params SqlParameter[] pms)
        {
            if (compress)
            {
                MySqlConnectionStringBuilder mysqlsb = new MySqlConnectionStringBuilder(connStr);
                mysqlsb.UseCompression = true;
                connStr = mysqlsb.ConnectionString;
            }

            try
            {
                // 由于SqlDataReader是面向连接的，所以SQLConnection不能Close，故没有写在using中
                MySqlConnection conn = new MySqlConnection(connStr);
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandTimeout = cmdTimeout;
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    conn.Open();

                    return await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region ExecuteDataTableAsync
        public async static Task<DataTable> ExecuteDataTableAsync(string connStr, string sql, bool compress = false, params SqlParameter[] pms)
        {
            return await ExecuteDataTableAsync(connStr, defCmdType, sql, defCmdTimeout, compress, pms);
        }

        public async static Task<DataTable> ExecuteDataTableAsync(string connStr, CommandType cmdType, string sql, bool compress = false, params SqlParameter[] pms)
        {
            return await ExecuteDataTableAsync(connStr, cmdType, sql, defCmdTimeout, compress, pms);
        }

        public async static Task<DataTable> ExecuteDataTableAsync(string connStr, string sql, int cmdTimeout, bool compress = false, params SqlParameter[] pms)
        {
            return await ExecuteDataTableAsync(connStr, defCmdType, sql, cmdTimeout, compress, pms);
        }

        public async static Task<DataTable> ExecuteDataTableAsync(string connStr, CommandType cmdType, string sql, int cmdTimeout, bool compress, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();

            if (compress)
            {
                MySqlConnectionStringBuilder mysqlsb = new MySqlConnectionStringBuilder(connStr);
                mysqlsb.UseCompression = true;
                connStr = mysqlsb.ConnectionString;
            }

            try
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connStr))
                {
                    adapter.SelectCommand.CommandType = cmdType;
                    adapter.SelectCommand.CommandTimeout = cmdTimeout;
                    if (pms != null)
                    {
                        adapter.SelectCommand.Parameters.AddRange(pms);
                    }

                    return await Task.Run(() =>
                    {
                        adapter.Fill(dt);
                        return dt;
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region ExecuteDataSetAsync
        public async static Task<DataSet> ExecuteDataSetAsync(string connStr, string sql, bool compress = false, params SqlParameter[] pms)
        {
            return await ExecuteDataSetAsync(connStr, defCmdType, sql, defCmdTimeout, compress, pms);
        }

        public async static Task<DataSet> ExecuteDataSetAsync(string connStr, CommandType cmdType, string sql, bool compress = false, params SqlParameter[] pms)
        {
            return await ExecuteDataSetAsync(connStr, cmdType, sql, defCmdTimeout, compress, pms);
        }

        public async static Task<DataSet> ExecuteDataSetAsync(string connStr, string sql, int cmdTimeout, bool compress = false, params SqlParameter[] pms)
        {
            return await ExecuteDataSetAsync(connStr, defCmdType, sql, cmdTimeout, compress, pms);
        }

        public async static Task<DataSet> ExecuteDataSetAsync(string connStr, CommandType cmdType, string sql, int cmdTimeout, bool compress, params SqlParameter[] pms)
        {
            DataSet ds = new DataSet();

            if (compress)
            {
                MySqlConnectionStringBuilder mysqlsb = new MySqlConnectionStringBuilder(connStr);
                mysqlsb.UseCompression = true;
                connStr = mysqlsb.ConnectionString;
            }

            try
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connStr))
                {
                    adapter.SelectCommand.CommandType = cmdType;
                    adapter.SelectCommand.CommandTimeout = cmdTimeout;
                    if (pms != null)
                    {
                        adapter.SelectCommand.Parameters.AddRange(pms);
                    }

                    return await Task.Run(() =>
                    {
                        adapter.Fill(ds);
                        return ds;
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #endregion
    }
}
