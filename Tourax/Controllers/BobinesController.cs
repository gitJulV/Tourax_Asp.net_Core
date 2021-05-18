using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tourax.Data;
using Tourax.Data.Entities;
using Tourax.Models;
using Tourax.Repositories;
using Tourax.Repositories.Interfaces;

namespace Tourax.Controllers
{
    [Authorize]
    public class BobinesController : Controller
    {
        private readonly ITouraxRepository _touraxRepository;
        private readonly IMapper _mapper;

        public BobinesController(ITouraxRepository touraxRepository, IMapper mapper)
        { 
            _mapper = mapper;
            _touraxRepository = touraxRepository;
        }

        // GET: Bobines
        public async Task<IActionResult> Index()
        {
            var bobines = await _touraxRepository.GetBobines().ToListAsync();
            return View(_mapper.Map<List<BobineModel>>(bobines));
        }

        // GET: Bobines/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var bobine = await _touraxRepository.GetBobineById(id).FirstOrDefaultAsync();

            if (bobine == null)
                return NotFound();

            return View(_mapper.Map<BobineModel>(bobine));
        }

        // GET: Bobines/Create
        public IActionResult Create()
        {
            ViewData["IdMatiere"] = new SelectList(_touraxRepository.GetMatieres(), "IdMatiere", "LibelleMatiere");
            return View();
        }

        // POST: Bobines/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BobineModel bobine)
        {
            if (ModelState.IsValid)
            {
                await _touraxRepository.AddBobine(_mapper.Map<BobineEntity>(bobine));
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdMatiere"] = new SelectList(_touraxRepository.GetMatieres(), "IdMatiere", "LibelleMatiere", bobine.IdMatiere);
            return View(bobine);
        }

        // GET: Bobines/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var bobine = await _touraxRepository.GetBobineById(id).FirstOrDefaultAsync();

            if (bobine == null)
                return NotFound();

            ViewData["IdMatiere"] = new SelectList(_touraxRepository.GetMatieres(), "IdMatiere", "LibelleMatiere", bobine.IdMatiere);
            return View(_mapper.Map<BobineModel>(bobine));
        }

        // POST: Bobines/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BobineModel bobine)
        {
            if (ModelState.IsValid)
            {
                await _touraxRepository.UpdateBobine(_mapper.Map<BobineEntity>(bobine));
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdMatiere"] = new SelectList(_touraxRepository.GetMatieres(), "IdMatiere", "IdMatiere", bobine.IdMatiere);
            return View(bobine);
        }

        // GET: Bobines/Delete/5
        public async Task<PartialViewResult> Delete(int id)
        {
            var bobine = await _touraxRepository.GetBobineById(id).FirstOrDefaultAsync();

            return PartialView("_ModalDeleteContent", _mapper.Map<BobineModel>(bobine));
        }

        // POST: Bobines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _touraxRepository.DeleteBobine(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
