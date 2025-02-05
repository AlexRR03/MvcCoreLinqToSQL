using System.Data;
using Microsoft.Data.SqlClient;
using MvcCoreLinqToSQL.Models;

namespace MvcCoreLinqToSQL.Repositories
{
    public class RepositoryEmpleados
    {
        private DataTable tablaEmpleados;

        public RepositoryEmpleados()
        {
            string conecctionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Encrypt=True;Trust Server Certificate=True";
            string sql = "select * from EMP";
            SqlDataAdapter adEmp = new SqlDataAdapter(sql,conecctionString);
            this.tablaEmpleados = new DataTable();
            adEmp.Fill(this.tablaEmpleados);
        }

        public List<Empleado> GetEmpleados()
        {
           var consulta = from datos in this.tablaEmpleados.AsEnumerable() select datos;
            List<Empleado> empelados = new List<Empleado>();
            foreach(var row in consulta)
            {
                Empleado empleado = new Empleado();
                empleado.Id = row.Field<int>("EMP_NO");
                empleado.Apellido = row.Field<string>("APELLIDO");
                empleado.Oficio = row.Field<string>("OFICIO");
                empleado.Salario = row.Field<int>("SALARIO");
                empleado.IdDepartamento = row.Field<int>("DEPT_NO");
                empelados.Add(empleado);
            }
            return empelados;
        }

        public Empleado FindEmpleado(int id)
        {
            var consulta = from datos in this.tablaEmpleados.AsEnumerable() where datos.Field<int>("EMP_NO")==id select datos;
             
            var row = consulta.First();
            Empleado empleado = new Empleado();
            empleado.Id = row.Field<int>("EMP_NO");
            empleado.Apellido = row.Field<string>("APELLIDO");
            empleado.Oficio = row.Field<string>("OFICIO");
            empleado.Salario = row.Field<int>("SALARIO");
            empleado.IdDepartamento = row.Field<int>("DEPT_NO");
            return empleado;
        }
        public List<Empleado> GetEmpleadosOficioSalario(string oficio, int salario) 
        { 
            var consulta = from datos in this.tablaEmpleados.AsEnumerable() where datos.Field<string>("OFICIO") == oficio && datos.Field<int>("SALARIO")>= salario select datos;
            if(consulta.Count() == 0)
            {
                return null;
            }
            else {  
            List<Empleado> empleados = new List<Empleado>();
            foreach(var row in consulta)
            {
                Empleado empleado = new Empleado();
                empleado.Id = row.Field<int>("EMP_NO");
                empleado.Apellido = row.Field<string>("APELLIDO");
                empleado.Oficio = row.Field<string>("OFICIO");
                empleado.Salario = row.Field<int>("SALARIO");
                empleado.IdDepartamento = row.Field<int>("DEPT_NO");
                empleados.Add(empleado);
            }
            return empleados;
            }

        }

    }
}
