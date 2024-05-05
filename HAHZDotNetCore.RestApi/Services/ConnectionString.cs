using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAHZDotNetCore.RestApi.Services
{
    internal static class ConnectionString
    {
        public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            InitialCatalog = "DotNetTrainingBth4",
            UserID = "sa",
            Password = "ZwehtetZ@18",
            TrustServerCertificate = true
        };

        public static object SqlConnectionStringBuilder { get; internal set; }
    }
}
