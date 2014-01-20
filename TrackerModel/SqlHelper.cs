using System.Configuration;
using System.Data.SqlClient;

namespace TrackerModel
{
    internal class SqlHelper
    {
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["RealTime"].ConnectionString);
        }
    }
}
