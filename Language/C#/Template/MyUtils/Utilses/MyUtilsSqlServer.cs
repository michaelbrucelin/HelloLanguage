using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace WindowsFormsApp0
{
    public static class MyUtilsSqlServer
    {
        private static readonly CommandType defCmdType = CommandType.Text;
        private static readonly int defCmdTimeout = 30;

        #region 同步方法
        #region ExecuteNonQuery
        public static int ExecuteNonQuery(string connStr, string sql, params SqlParameter[] pms)
        {
            return ExecuteNonQuery(connStr, defCmdType, sql, defCmdTimeout, pms);
        }

        public static int ExecuteNonQuery(string connStr, CommandType cmdType, string sql, params SqlParameter[] pms)
        {
            return ExecuteNonQuery(connStr, cmdType, sql, defCmdTimeout, pms);
        }

        public static int ExecuteNonQuery(string connStr, string sql, int cmdTimeout, params SqlParameter[] pms)
        {
            return ExecuteNonQuery(connStr, defCmdType, sql, cmdTimeout, pms);
        }

        public static int ExecuteNonQuery(string connStr, CommandType cmdType, string sql, int cmdTimeout, params SqlParameter[] pms)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
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
        public static object ExecuteScalar(string connStr, string sql, params SqlParameter[] pms)
        {
            return ExecuteScalar(connStr, defCmdType, sql, defCmdTimeout, pms);
        }

        public static object ExecuteScalar(string connStr, CommandType cmdType, string sql, params SqlParameter[] pms)
        {
            return ExecuteScalar(connStr, cmdType, sql, defCmdTimeout, pms);
        }

        public static object ExecuteScalar(string connStr, string sql, int cmdTimeout, params SqlParameter[] pms)
        {
            return ExecuteScalar(connStr, defCmdType, sql, cmdTimeout, pms);
        }

        public static object ExecuteScalar(string connStr, CommandType cmdType, string sql, int cmdTimeout, params SqlParameter[] pms)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
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
        public static SqlDataReader ExecuteReader(string connStr, string sql, params SqlParameter[] pms)
        {
            return ExecuteReader(connStr, defCmdType, sql, defCmdTimeout, pms);
        }

        public static SqlDataReader ExecuteReader(string connStr, CommandType cmdType, string sql, params SqlParameter[] pms)
        {
            return ExecuteReader(connStr, cmdType, sql, defCmdTimeout, pms);
        }

        public static SqlDataReader ExecuteReader(string connStr, string sql, int cmdTimeout, params SqlParameter[] pms)
        {
            return ExecuteReader(connStr, defCmdType, sql, cmdTimeout, pms);
        }

        public static SqlDataReader ExecuteReader(string connStr, CommandType cmdType, string sql, int cmdTimeout, params SqlParameter[] pms)
        {
            try
            {
                //由于SqlDataReader是面向连接的，所以SQLConnection不能Close，故没有写在using中
                SqlConnection conn = new SqlConnection(connStr);
                using (SqlCommand cmd = new SqlCommand(sql, conn))
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
        public static DataTable ExecuteDataTable(string connStr, string sql, params SqlParameter[] pms)
        {
            return ExecuteDataTable(connStr, defCmdType, sql, defCmdTimeout, pms);
        }

        public static DataTable ExecuteDataTable(string connStr, CommandType cmdType, string sql, params SqlParameter[] pms)
        {
            return ExecuteDataTable(connStr, cmdType, sql, defCmdTimeout, pms);
        }

        public static DataTable ExecuteDataTable(string connStr, string sql, int cmdTimeout, params SqlParameter[] pms)
        {
            return ExecuteDataTable(connStr, defCmdType, sql, cmdTimeout, pms);
        }

        public static DataTable ExecuteDataTable(string connStr, CommandType cmdType, string sql, int cmdTimeout, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connStr))
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
        public static DataSet ExecuteDataSet(string connStr, string sql, params SqlParameter[] pms)
        {
            return ExecuteDataSet(connStr, defCmdType, sql, defCmdTimeout, pms);
        }

        public static DataSet ExecuteDataSet(string connStr, CommandType cmdType, string sql, params SqlParameter[] pms)
        {
            return ExecuteDataSet(connStr, cmdType, sql, defCmdTimeout, pms);
        }

        public static DataSet ExecuteDataSet(string connStr, string sql, int cmdTimeout, params SqlParameter[] pms)
        {
            return ExecuteDataSet(connStr, defCmdType, sql, cmdTimeout, pms);
        }

        public static DataSet ExecuteDataSet(string connStr, CommandType cmdType, string sql, int cmdTimeout, params SqlParameter[] pms)
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connStr))
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

        #region ExecuteBulkCopy
        public enum BulkCopyOption { INSERT, TRUNCATE_INSERT };

        /// <summary>
        /// 直接INSERT或者先执行TRUNCATE再执行INSERT
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="tableName"></param>
        /// <param name="dataTable"></param>
        /// <param name="option"></param>
        /// <param name="columnMappings"></param>
        /// <returns></returns>
        public static bool ExecuteBulkCopy(string connStr, string tableName, DataTable dataTable, BulkCopyOption option, Dictionary<string, string> columnMappings = null)
        {
            return ExecuteBulkCopy(connStr, defCmdTimeout, tableName, dataTable, option, columnMappings);
        }

        public static bool ExecuteBulkCopy(string connStr, int timeout, string tableName, DataTable dataTable, BulkCopyOption option, Dictionary<string, string> columnMappings = null)
        {
            try
            {
                if (option == BulkCopyOption.INSERT)
                {
                    using (SqlBulkCopy sbc = new SqlBulkCopy(connStr, SqlBulkCopyOptions.UseInternalTransaction))
                    {
                        sbc.DestinationTableName = tableName;
                        if (columnMappings != null)
                        {
                            foreach (KeyValuePair<string, string> item in columnMappings)
                            {
                                sbc.ColumnMappings.Add(item.Key, item.Value);
                            }
                        }

                        sbc.WriteToServer(dataTable);
                    }

                    return true;
                }
                else if (option == BulkCopyOption.TRUNCATE_INSERT)
                {
                    return ExecuteBulkCopy(connStr, timeout, tableName, dataTable, $"truncate table {tableName}", columnMappings);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 先执行指定语句，例如带有WHERE条件的DELETE语句，然后再INSERT
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="tableName"></param>
        /// <param name="dataTable"></param>
        /// <param name="sql_dosomething"></param>
        /// <param name="columnMappings"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public static bool ExecuteBulkCopy(string connStr, string tableName, DataTable dataTable, string sql_dosomething, Dictionary<string, string> columnMappings = null, params SqlParameter[] pms)
        {
            return ExecuteBulkCopy(connStr, defCmdTimeout, tableName, dataTable, sql_dosomething, columnMappings, pms);
        }

        public static bool ExecuteBulkCopy(string connStr, int timeout, string tableName, DataTable dataTable, string sql_dosomething, Dictionary<string, string> columnMappings = null, params SqlParameter[] pms)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            // 先执行指定的操作
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.Transaction = tran;
                                cmd.CommandTimeout = timeout;
                                cmd.CommandText = sql_dosomething;
                                if (pms != null)
                                {
                                    cmd.Parameters.AddRange(pms);
                                }
                                cmd.ExecuteNonQuery();
                            }

                            // 然后将新的数据插入到目标表中
                            using (SqlBulkCopy sbc = new SqlBulkCopy(conn, SqlBulkCopyOptions.KeepIdentity, tran))
                            {
                                sbc.BulkCopyTimeout = timeout;
                                sbc.DestinationTableName = tableName;
                                if (columnMappings != null)
                                {
                                    foreach (KeyValuePair<string, string> item in columnMappings)
                                    {
                                        sbc.ColumnMappings.Add(item.Key, item.Value);
                                    }
                                }

                                sbc.WriteToServer(dataTable);
                            }

                            tran.Commit();
                        }
                        catch (Exception)
                        {
                            try
                            {
                                tran.Rollback();
                            }
                            catch (Exception)
                            {
                                throw;
                            }

                            throw;
                        }
                    }
                }

                return true;
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
        public async static Task<int> ExecuteNonQueryAsync(string connStr, string sql, params SqlParameter[] pms)
        {
            return await ExecuteNonQueryAsync(connStr, defCmdType, sql, defCmdTimeout, pms);
        }

        public async static Task<int> ExecuteNonQueryAsync(string connStr, CommandType cmdType, string sql, params SqlParameter[] pms)
        {
            return await ExecuteNonQueryAsync(connStr, cmdType, sql, defCmdTimeout, pms);
        }

        public async static Task<int> ExecuteNonQueryAsync(string connStr, string sql, int cmdTimeout, params SqlParameter[] pms)
        {
            return await ExecuteNonQueryAsync(connStr, defCmdType, sql, cmdTimeout, pms);
        }

        public async static Task<int> ExecuteNonQueryAsync(string connStr, CommandType cmdType, string sql, int cmdTimeout, params SqlParameter[] pms)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
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
        public async static Task<object> ExecuteScalarAsync(string connStr, string sql, params SqlParameter[] pms)
        {
            return await ExecuteScalarAsync(connStr, defCmdType, sql, defCmdTimeout, pms);
        }

        public async static Task<object> ExecuteScalarAsync(string connStr, CommandType cmdType, string sql, params SqlParameter[] pms)
        {
            return await ExecuteScalarAsync(connStr, cmdType, sql, defCmdTimeout, pms);
        }

        public async static Task<object> ExecuteScalarAsync(string connStr, string sql, int cmdTimeout, params SqlParameter[] pms)
        {
            return await ExecuteScalarAsync(connStr, defCmdType, sql, cmdTimeout, pms);
        }

        public async static Task<object> ExecuteScalarAsync(string connStr, CommandType cmdType, string sql, int cmdTimeout, params SqlParameter[] pms)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
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
        public async static Task<SqlDataReader> ExecuteReaderAsync(string connStr, string sql, params SqlParameter[] pms)
        {
            return await ExecuteReaderAsync(connStr, defCmdType, sql, defCmdTimeout, pms);
        }

        public async static Task<SqlDataReader> ExecuteReaderAsync(string connStr, CommandType cmdType, string sql, params SqlParameter[] pms)
        {
            return await ExecuteReaderAsync(connStr, cmdType, sql, defCmdTimeout, pms);
        }

        public async static Task<SqlDataReader> ExecuteReaderAsync(string connStr, string sql, int cmdTimeout, params SqlParameter[] pms)
        {
            return await ExecuteReaderAsync(connStr, defCmdType, sql, cmdTimeout, pms);
        }

        public async static Task<SqlDataReader> ExecuteReaderAsync(string connStr, CommandType cmdType, string sql, int cmdTimeout, params SqlParameter[] pms)
        {
            try
            {
                // 由于SqlDataReader是面向连接的，所以SQLConnection不能Close，故没有写在using中
                SqlConnection conn = new SqlConnection(connStr);
                using (SqlCommand cmd = new SqlCommand(sql, conn))
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
        public async static Task<DataTable> ExecuteDataTableAsync(string connStr, string sql, params SqlParameter[] pms)
        {
            return await ExecuteDataTableAsync(connStr, defCmdType, sql, defCmdTimeout, pms);
        }

        public async static Task<DataTable> ExecuteDataTableAsync(string connStr, CommandType cmdType, string sql, params SqlParameter[] pms)
        {
            return await ExecuteDataTableAsync(connStr, cmdType, sql, defCmdTimeout, pms);
        }

        public async static Task<DataTable> ExecuteDataTableAsync(string connStr, string sql, int cmdTimeout, params SqlParameter[] pms)
        {
            return await ExecuteDataTableAsync(connStr, defCmdType, sql, cmdTimeout, pms);
        }

        public async static Task<DataTable> ExecuteDataTableAsync(string connStr, CommandType cmdType, string sql, int cmdTimeout, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connStr))
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
        public async static Task<DataSet> ExecuteDataSetAsync(string connStr, string sql, params SqlParameter[] pms)
        {
            return await ExecuteDataSetAsync(connStr, defCmdType, sql, defCmdTimeout, pms);
        }

        public async static Task<DataSet> ExecuteDataSetAsync(string connStr, CommandType cmdType, string sql, params SqlParameter[] pms)
        {
            return await ExecuteDataSetAsync(connStr, cmdType, sql, defCmdTimeout, pms);
        }

        public async static Task<DataSet> ExecuteDataSetAsync(string connStr, string sql, int cmdTimeout, params SqlParameter[] pms)
        {
            return await ExecuteDataSetAsync(connStr, defCmdType, sql, cmdTimeout, pms);
        }

        public async static Task<DataSet> ExecuteDataSetAsync(string connStr, CommandType cmdType, string sql, int cmdTimeout, params SqlParameter[] pms)
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connStr))
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

        #region ExecuteBulkCopyAsync
        /// <summary>
        /// 直接INSERT或者先执行TRUNCATE再执行INSERT
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="tableName"></param>
        /// <param name="dataTable"></param>
        /// <param name="option"></param>
        /// <param name="columnMappings"></param>
        /// <returns></returns>
        public async static Task<bool> ExecuteBulkCopyAsync(string connStr, string tableName, DataTable dataTable, BulkCopyOption option, Dictionary<string, string> columnMappings = null)
        {
            return await ExecuteBulkCopyAsync(connStr, defCmdTimeout, tableName, dataTable, option, columnMappings);
        }

        public async static Task<bool> ExecuteBulkCopyAsync(string connStr, int timeout, string tableName, DataTable dataTable, BulkCopyOption option, Dictionary<string, string> columnMappings = null)
        {
            try
            {
                if (option == BulkCopyOption.INSERT)
                {
                    using (SqlBulkCopy sbc = new SqlBulkCopy(connStr, SqlBulkCopyOptions.UseInternalTransaction))
                    {
                        sbc.DestinationTableName = tableName;
                        if (columnMappings != null)
                        {
                            foreach (KeyValuePair<string, string> item in columnMappings)
                            {
                                sbc.ColumnMappings.Add(item.Key, item.Value);
                            }
                        }

                        await sbc.WriteToServerAsync(dataTable);
                    }

                    return true;
                }
                else if (option == BulkCopyOption.TRUNCATE_INSERT)
                {
                    return await ExecuteBulkCopyAsync(connStr, timeout, tableName, dataTable, $"truncate table {tableName}", columnMappings);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 先执行指定语句，例如带有WHERE条件的DELETE语句，然后再INSERT
        /// </summary>
        /// <param name="connStr"></param>
        /// <param name="tableName"></param>
        /// <param name="dataTable"></param>
        /// <param name="sql_dosomething"></param>
        /// <param name="columnMappings"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public async static Task<bool> ExecuteBulkCopyAsync(string connStr, string tableName, DataTable dataTable, string sql_dosomething, Dictionary<string, string> columnMappings = null, params SqlParameter[] pms)
        {
            return await ExecuteBulkCopyAsync(connStr, defCmdTimeout, tableName, dataTable, sql_dosomething, columnMappings, pms);
        }

        public async static Task<bool> ExecuteBulkCopyAsync(string connStr, int timeout, string tableName, DataTable dataTable, string sql_dosomething, Dictionary<string, string> columnMappings = null, params SqlParameter[] pms)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            // 先执行指定的操作
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.Transaction = tran;
                                cmd.CommandTimeout = timeout;
                                cmd.CommandText = sql_dosomething;
                                if (pms != null)
                                {
                                    cmd.Parameters.AddRange(pms);
                                }
                                await cmd.ExecuteNonQueryAsync();
                            }

                            // 然后将新的数据插入到目标表中
                            using (SqlBulkCopy sbc = new SqlBulkCopy(conn, SqlBulkCopyOptions.KeepIdentity, tran))
                            {
                                sbc.BulkCopyTimeout = timeout;
                                sbc.DestinationTableName = tableName;
                                if (columnMappings != null)
                                {
                                    foreach (KeyValuePair<string, string> item in columnMappings)
                                    {
                                        sbc.ColumnMappings.Add(item.Key, item.Value);
                                    }
                                }

                                await sbc.WriteToServerAsync(dataTable);
                            }

                            tran.Commit();
                        }
                        catch (Exception)
                        {
                            try
                            {
                                tran.Rollback();
                            }
                            catch (Exception)
                            {
                                throw;
                            }

                            throw;
                        }
                    }
                }

                return true;
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
