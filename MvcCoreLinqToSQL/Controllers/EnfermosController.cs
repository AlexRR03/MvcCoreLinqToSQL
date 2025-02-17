﻿using Microsoft.AspNetCore.Mvc;
using MvcCoreLinqToSQL.Models;
using MvcCoreLinqToSQL.Repositories;

namespace MvcCoreLinqToSQL.Controllers
{
    public class EnfermosController : Controller
    {
        RepositoryEnfermo repo;
        public EnfermosController()
        {
            this.repo = new RepositoryEnfermo();
        }
        public IActionResult Index()
        {
            List<Enfermo> enfermos = this.repo.GetEnfermos();
            return View(enfermos);
        }
        public IActionResult Details(string inscripcion)
        {
            Enfermo enfermo = this.repo.FindEnfermo(inscripcion);
            return View(enfermo);
        }
     
        public IActionResult Delete(string inscripcion)
        {
            this.repo.DeleteHospital(inscripcion);
            return RedirectToAction("Index");



        }
    }
}
