using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TrackerModel
{
    public class TrackerItem
    {
        #region Properties
        public string Client { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public KeyValuePair<int, string> Task { get; set; }
        public DateTime DueDate { get; set; }
        #endregion

        public static IEnumerable<TrackerItem> GetOpenItems()
        {
            using (var conn = SqlHelper.GetSqlConnection())
            using (var cmd = new SqlCommand
            {
                CommandText = "dbo.SelectOpenTrackerItems",
                CommandType = CommandType.StoredProcedure,
                Connection = conn
            })
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    var items = new List<TrackerItem>();
                    while (dr.Read())
                    {
                        items.Add(new TrackerItem
                        {
                            Client = Convert.ToString(dr["Client"]),
                            Name = Convert.ToString(dr["Name"]),
                            Address = Convert.ToString(dr["Address"]),
                            Phone = Convert.ToString(dr["Phone"]),
                            Task= new KeyValuePair<int, string>(Convert.ToInt32(dr["TaskId"]), Convert.ToString(dr["TaskString"])),
                            DueDate = Convert.ToDateTime(dr["DueDate"])
                        });
                    }
                    return items;
                }
            }
        }

        public int Add()
        {
            using (var conn = SqlHelper.GetSqlConnection())
            using (var cmd = new SqlCommand
            {
                CommandText = "dbo.InsertTrackerItem",
                Connection = conn,
                CommandType = CommandType.StoredProcedure,
                Parameters =
                {
                    new SqlParameter("@Client", Client),
                    new SqlParameter("@Name", Name),
                    new SqlParameter("@Address", Address),
                    new SqlParameter("@Phone", Phone),
                    new SqlParameter("@TaskId", Task.Key),
                    new SqlParameter("@TaskString", Task.Value),
                    new SqlParameter("@DueDate", DueDate) 
                }
            })
            {
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
