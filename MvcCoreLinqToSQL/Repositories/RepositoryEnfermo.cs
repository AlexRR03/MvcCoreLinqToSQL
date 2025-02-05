using System.Data;
using Microsoft.Data.SqlClient;
using MvcCoreLinqToSQL.Models;

namespace MvcCoreLinqToSQL.Repositories
{
    public class RepositoryEnfermo
    {
        private DataTable tablaEnfermos;
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public RepositoryEnfermo()
        {
            string conecctionString= @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Encrypt=True;Trust Server Certificate=True";
            string sql = "select * from ENFERMO";
            SqlDataAdapter adapter = new SqlDataAdapter(sql,conecctionString);
            this.tablaEnfermos = new DataTable();
            adapter.Fill(this.tablaEnfermos);

            this.cn = new SqlConnection(conecctionString);
            this.com = new SqlCommand();
            this.com.Connection = cn;
        }

        public List<Enfermo> GetEnfermos() 
        {
            var consulta = from datos in this.tablaEnfermos.AsEnumerable() select datos;
            List<Enfermo> enfermos = new List<Enfermo>();
            foreach (var row in consulta) 
            {
                Enfermo enfermo = new Enfermo();
                enfermo.Inscripcion = row.Field<string>("INSCRIPCION");
                enfermo.Apellido = row.Field<string>("APELLIDO");
                enfermo.Direccion = row.Field<string>("DIRECCION");
                enfermo.FechaNacimiento = row.Field<DateTime>("FECHA_NAC");
                enfermo.Sexo = row.Field<string>("S");
                enfermo.Numero = row.Field<string>("NSS");
                enfermos.Add(enfermo);
            }
            return enfermos;
        }
        public Enfermo FindEnfermo(string inscripcion)
        {
            var consulta = from datos in this.tablaEnfermos.AsEnumerable() where  datos.Field<string>("INSCRIPCION") == inscripcion select datos;
            var row = consulta.First();
            Enfermo enfermo = new Enfermo();
            enfermo.Inscripcion = row.Field<string>("INSCRIPCION");
            enfermo.Apellido = row.Field<string>("APELLIDO");
            enfermo.Direccion = row.Field<string>("DIRECCION");
            enfermo.FechaNacimiento = row.Field<DateTime>("FECHA_NAC");
            enfermo.Sexo = row.Field<string>("S");
            enfermo.Numero = row.Field<string>("NSS");
            return enfermo;
        }

        public void DeleteHospital(string inscripcion)
        {
            string sql = "delete from ENFERMO where INSCRIPCION = @inscripcion";
            this.com.Parameters.AddWithValue("@inscripcion", inscripcion);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }
        
        
    }
}
