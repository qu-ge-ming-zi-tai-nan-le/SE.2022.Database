using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class MySqlHelper
    {
        public static string connStr = "Database=sysdb;Data Source=127.0.0.1;User Id=root;Password=Sjw20020109*;pooling=true;CharSet=utf8;port=3306";
        public static bool ExecSql(string sqlStr, params MySqlParameter[] para)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlCommand command = new MySqlCommand(sqlStr, conn))
                {
                    try
                    {
                        conn.Open();
                        if (para != null)
                        {
                            foreach (MySqlParameter p in para)
                            {
                                command.Parameters.AddWithValue(p.ParameterName, p.Value);
                            }
                        }
                        return command.ExecuteNonQuery() > 0;

                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
        }
        public static DataSet ExecSqlQuery(string sqlStr, params MySqlParameter[] para)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlCommand command = new MySqlCommand(sqlStr, conn))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        if (para != null)
                        {
                            foreach(MySqlParameter p in para)
                            {
                                command.Parameters.AddWithValue(p.ParameterName, p.Value);
                            }
                        }
                        MySqlDataAdapter da = new MySqlDataAdapter(command);
                        da.Fill(ds);
                        return ds;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }
        }

    }
}
