using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNetCorePractica.Helpers;
using AdoNetCorePractica.Models;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

#region STORED PROCEDURES
//create procedure SP_HOSPITALES
//as
//	select NOMBRE from HOSPITAL
//go

//create procedure SP_EMPLEADOS_HOSPITAL_OUT 
//    (@nombre nvarchar(50),
// @suma int OUT,
// @media int OUT,
// @personas int OUT)
//as
//    declare @idHospital int;

//select @idHospital = HOSPITAL_COD from HOSPITAL where NOMBRE=@nombre;

//select APELLIDO, SALARIO, ESPECIALIDAD as Rol from DOCTOR where DOCTOR.HOSPITAL_COD = @idHospital
//    union
//    select APELLIDO, SALARIO, FUNCION as Rol from PLANTILLA where PLANTILLA.HOSPITAL_COD = @idHospital;

//select @suma = SUM(SALARIO), @media = AVG(SALARIO), @personas = COUNT(APELLIDO) from (select SALARIO, APELLIDO from DOCTOR where HOSPITAL_COD = @idHospital 
//	union all 
//	select SALARIO, APELLIDO from PLANTILLA where HOSPITAL_COD = @idHospital) as Empleados;
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

        public async Task <EmpleadosHospital> MostrarEmpleadosAsync(string nombre)
        {
            string sql = "SP_EMPLEADOS_HOSPITAL_OUT";
            this.com.Parameters.AddWithValue("@nombre", nombre);
            SqlParameter pamSuma = new SqlParameter();
            pamSuma.ParameterName = "@suma";
            pamSuma.Value = 0;
            pamSuma.Direction = System.Data.ParameterDirection.Output;
            this.com.Parameters.Add(pamSuma);
            SqlParameter pamMedia = new SqlParameter();
            pamMedia.ParameterName = "@media";
            pamMedia.Value = 0;
            pamMedia.Direction = System.Data.ParameterDirection.Output;
            this.com.Parameters.Add(pamMedia);
            SqlParameter personas = new SqlParameter();
            personas.ParameterName = "@personas";
            personas.Value = 0;
            personas.Direction = System.Data.ParameterDirection.Output;
            this.com.Parameters.Add(personas);
            this.com.CommandType = System.Data.CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            EmpleadosHospital empleado = new EmpleadosHospital();
            List<string> datosEmpleados = new List<string>();
            while (await this.reader.ReadAsync())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                string funcion = this.reader["Rol"].ToString();
                int salario = int.Parse(this.reader["SALARIO"].ToString());

                datosEmpleados.Add(apellido + " - " + funcion + " - " + salario); ;
            }
            await this.reader.CloseAsync();
            empleado.DatosEmpleados = datosEmpleados;
            empleado.SumaSalarial = int.Parse(pamSuma.Value.ToString());
            empleado.MediaSalarial = int.Parse(pamMedia.Value.ToString());
            empleado.Personas = int.Parse(personas.Value.ToString());

            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return empleado;
        }
    }
}
