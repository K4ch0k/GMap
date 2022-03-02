using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace RIT_Automation
{
    class SQLInteractions
    {
        static string ConnStr = @"Server=PC-K4CH0K;Database=dbRITAutomation;Trusted_Connection=True;TrustServerCertificate=True";
        public async void mySql()
        {

        }

        public static async Task<bool> SqlCheckConn()
        {
            SqlConnection connection = new SqlConnection(ConnStr);
            try
            {
                await connection.OpenAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return true;
        }

        public static async Task<List<dbMarker>> SqlSelectAllMarkers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnStr))
                {
                    await connection.OpenAsync();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = "Select * from Markers";
                    SqlDataReader result = await sqlCommand.ExecuteReaderAsync();
                    if (result.HasRows)
                    {
                        List<dbMarker> AllMarkers = new List<dbMarker>();
                        while (await result.ReadAsync())
                        {
                            AllMarkers.Add(new dbMarker
                            {
                                ID = Convert.ToInt32(result.GetValue(0)),
                                Lat = Convert.ToDouble(result.GetValue(1)),
                                Long = Convert.ToDouble(result.GetValue(2)),
                                Desc = result.GetValue(3).ToString()
                            });
                        }
                        return AllMarkers;
                    }
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public static async Task<bool> SqlDeleteMarker(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnStr))
                {
                    await connection.OpenAsync();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = $"Delete From Markers Where ID = {id}";
                    int result = await sqlCommand.ExecuteNonQueryAsync();
                    if (result == 1)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static async Task<int> SqlInsertMarker(dbMarker NewMarker)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnStr))
                {
                    await connection.OpenAsync();

                    string CommandText = $"Insert Into Markers (Lat, Long, Description) Values (@Lat, @Long, @Desc)";
                    DBNull nullvalue = DBNull.Value;

                    SqlCommand sqlCommand = new SqlCommand(CommandText, connection);
                    SqlParameter LatParam = new SqlParameter("@Lat", NewMarker.Lat);
                    SqlParameter LongParam = new SqlParameter("@Long", NewMarker.Long);
                    SqlParameter DescParam = new SqlParameter();
                    if (NewMarker.Desc == null)
                    {
                        nullvalue = DBNull.Value;
                        DescParam = new SqlParameter("@Desc", nullvalue);
                    }
                    else
                    {
                        DescParam = new SqlParameter("@Desc", NewMarker.Desc);
                    }

                    sqlCommand.Parameters.Add(LatParam);
                    sqlCommand.Parameters.Add(LongParam);
                    sqlCommand.Parameters.Add(DescParam);

                    int res = await sqlCommand.ExecuteNonQueryAsync();
                    if (res == 1)
                    {
                        CommandText = $"Select * from Markers Where Lat = @Lat and Long = @Long";
                        sqlCommand = new SqlCommand(CommandText, connection);

                        SqlParameter LatParam2 = new SqlParameter("@Lat", NewMarker.Lat);
                        SqlParameter LongParam2 = new SqlParameter("@Long", NewMarker.Long);

                        sqlCommand.Parameters.Add(LatParam2);
                        sqlCommand.Parameters.Add(LongParam2);

                        SqlDataReader result = await sqlCommand.ExecuteReaderAsync();
                        if (result.HasRows)
                        {
                            int ID = 0;
                            while (await result.ReadAsync())
                            {
                                ID = Convert.ToInt32(result.GetValue(0));
                            }
                            return ID;
                        }
                        return 1;
                    }
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        public static async Task<bool> SqlUpdateMarker(dbMarker UpdMarker)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnStr))
                {
                    await connection.OpenAsync();
                    string CommandText = $"Update Markers Set Lat = @Lat, Long = @Long, Description = @Desc Where ID = @ID";
                    DBNull nullvalue = DBNull.Value;

                    SqlCommand sqlCommand = new SqlCommand(CommandText, connection);
                    SqlParameter LatParam = new SqlParameter("@Lat", UpdMarker.Lat);
                    SqlParameter LongParam = new SqlParameter("@Long", UpdMarker.Long);
                    SqlParameter DescParam = new SqlParameter();
                    if (UpdMarker.Desc == null)
                    {
                        nullvalue = DBNull.Value;
                        DescParam = new SqlParameter("@Desc", nullvalue);
                    }
                    else
                    {
                        DescParam = new SqlParameter("@Desc", UpdMarker.Desc);
                    }
                    SqlParameter IDParam = new SqlParameter("@ID", UpdMarker.ID);

                    sqlCommand.Parameters.Add(LatParam);
                    sqlCommand.Parameters.Add(LongParam);
                    sqlCommand.Parameters.Add(DescParam);
                    sqlCommand.Parameters.Add(IDParam);

                    int result = await sqlCommand.ExecuteNonQueryAsync();
                    if (result == 1)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
