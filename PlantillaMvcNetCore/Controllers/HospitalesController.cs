using Microsoft.AspNetCore.Mvc;
using PlantillaMvcNetCore.Models;
using PlantillaMvcNetCore.Repositories;

namespace PlantillaMvcNetCore.Controllers {
    public class HospitalesController : Controller {

        IRepositoryHospitales repo;

        public HospitalesController(IRepositoryHospitales repo) {
            this.repo = repo;
        }

        public IActionResult ShowHospitales() {
            List<Hospital> hospitales = this.repo.GetHospitales();
            return View(hospitales);
        }

        public IActionResult Details(int hospital_cod) {
            Hospital hospital = this.repo.FindHospital(hospital_cod);
            return View(hospital);
        }

        [HttpGet]
        public IActionResult Insert() {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Hospital hospital) {
            this.repo.InsertHospital(hospital);
            return RedirectToAction("ShowHospitales");
        }        
        
        [HttpGet]
        public IActionResult Update(int hospital_cod) {
            Hospital hospital = this.repo.FindHospital(hospital_cod);
            return View(hospital);
        }

        [HttpPost]
        public IActionResult Update(Hospital hospital) {
            this.repo.UpdateHospital(hospital);
            return RedirectToAction("ShowHospitales");
        }        
        
        [HttpGet]
        public IActionResult Delete(int hospital_cod) {
            this.repo.DeleteHospital(hospital_cod);
            return RedirectToAction("ShowHospitales");
        }

    }
}
