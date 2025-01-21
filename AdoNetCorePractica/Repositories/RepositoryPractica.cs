using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNetCorePractica.Helpers;
using Microsoft.Data.SqlClient;

#region STORED PROCEDURES
    //create procedure SP_HOSPITALES
    //as
	   // select NOMBRE from HOSPITAL
    //go
#endregion

namespace AdoNetCorePractica.Repositories
{
    public class RepositoryPractica
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryPractica()
        {
            string connectionString = HelperConfiguration.GetConnectionString();
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public async Task<List<string>> GetHospitalesAsync()
        {
            string sql = "SP_HOSPITALES";
            this.com.CommandType = System.Data.CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<string> hospitales = new List<string>();
            while(await this.reader.ReadAsync())
            {
                string nombreHosp = this.reader["NOMBRE"].ToString();
                hospitales.Add(nombreHosp);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return hospitales;
        }
    }
}
