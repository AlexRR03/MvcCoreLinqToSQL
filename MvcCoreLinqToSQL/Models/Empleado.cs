﻿namespace MvcCoreLinqToSQL.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Apellido { get; set; }
        public string Oficio { get; set; }
        public int Salario { get; set; }
        public int IdDepartamento { get; set; }



    }
}
