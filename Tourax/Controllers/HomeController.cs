using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Tourax.Models;
using Tourax.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Tourax.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ITouraxRepository _touraxRepository;
        private readonly IMapper _mapper;

        public HomeController(ITouraxRepository touraxRepository, IMapper mapper)
        {
            _touraxRepository = touraxRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<PartialViewResult> SimulationRechercheBobResult(CableModel model)
        {
            return PartialView("Result/_ResultRechercheBobPartial", model);
        }

        [HttpPost]
        public async Task<PartialViewResult> SimulationCapaciteBobResult(SimulatorModel model)
        {
            var bobine = await _touraxRepository.GetBobineById(model.Bobine.IdBobine).FirstOrDefaultAsync();
            model.Bobine = _mapper.Map<BobineModel>(bobine);

            return PartialView("Result/_ResultCapaciteBobPartial", model);
        }

        [HttpPost]
        public PartialViewResult SimulationDimensionBobResult(SimulatorModel model)
        {
            return PartialView("Result/_ResultCapaciteBobPartial", model);
        }

        public async Task<JsonResult> GetBobineRefForSelect2(string search = "")
        {
            var bobines = await _touraxRepository.GetBobines().ToListAsync();

            if (search != "")
                bobines.Where(b => b.Reference.ToLower().Contains(search.ToLower()));

            return Json(new { 
                results = bobines.Select(b => new {
                    id = b.IdBobine,
                    text = b.Reference
                })
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
