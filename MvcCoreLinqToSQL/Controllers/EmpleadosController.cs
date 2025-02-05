using Microsoft.AspNetCore.Mvc;
using MvcCoreLinqToSQL.Models;
using MvcCoreLinqToSQL.Repositories;

namespace MvcCoreLinqToSQL.Controllers
{
    public class EmpleadosController : Controller
    {
        RepositoryEmpleados repo;
        public EmpleadosController()
        {
            this.repo = new RepositoryEmpleados();
        }
        public IActionResult Index()
        {
            List<Empleado> empleados = this.repo.GetEmpleados();
            return View(empleados);
        }
        public IActionResult Details(int id) 
        {
            Empleado empleado = this.repo.FindEmpleado(id);
            return View(empleado);
        }
        public IActionResult Search()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Search(string oficio,int salario) 
        { 
            List<Empleado> empleados = this.repo.GetEmpleadosOficioSalario(oficio, salario);
            if (empleados == null)
            {
                ViewData["MENSAJE"] = "NO existen empleados con oficio:" + oficio+" y salario superior a " +salario;
                return View();
            }
            else { 
            return View(empleados);
            }
        }
    }
}
