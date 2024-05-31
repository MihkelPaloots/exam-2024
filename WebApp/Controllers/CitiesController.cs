using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App.Contracts.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAL.EF;
using App.Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    [Authorize(Roles = "Admin")]

    public class CitiesController : Controller
    {
        private readonly IAppUnitOfWork _bll;

        public CitiesController(IAppUnitOfWork bll)
        {
            _bll = bll;
        }

        // GET: Cities
        public async Task<IActionResult> Index()
        {
     
            return View(await _bll.Cities.GetAllAsync());
        }

        // GET: Cities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(await _bll.Cities.FirstOrDefaultAsync(id.Value));
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_bll.Countries.GetAll(), "Id", "CountryName");
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityName,CountryId,Latitude,Longitude,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,Id")] App.DAL.DTO.City city)
        {
            if (ModelState.IsValid)
            {
                city.Id = Guid.NewGuid();
                city.UpdatedAt = city.UpdatedAt.ToUniversalTime();
                city.CreatedAt = city.CreatedAt.ToUniversalTime();
                _bll.Cities.Add(city);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_bll.Countries.GetAll(), "Id", "CountryName", city.CountryId);
            return View(city);
        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _bll.Cities.FirstOrDefaultAsync(id.Value);
            if (city == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_bll.Countries.GetAll(), "Id", "CountryName", city.CountryId);
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CityName,CountryId,Latitude,Longitude,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,Id")] App.DAL.DTO.City city)
        {
            city.UpdatedAt = city.UpdatedAt.ToUniversalTime();
            city.CreatedAt = city.CreatedAt.ToUniversalTime();
            if (id != city.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.Cities.Update(city);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_bll.Countries.GetAll(), "Id", "CountryName", city.CountryId);
            return View(city);
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(await _bll.Cities.FirstOrDefaultAsync(id.Value));
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _bll.Cities.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(Guid id)
        {
            return _bll.Cities.Exists(id);
        }
    }
}
