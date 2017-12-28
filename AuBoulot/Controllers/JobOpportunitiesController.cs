using AuBoulot.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AuBoulot.Web.Controllers
{
    public class JobOpportunitiesController : Controller
    {
        private readonly AuBoulotContext _context;

        public JobOpportunitiesController(AuBoulotContext context)
        {
            _context = context;
        }


        public IActionResult Create(Guid? companyId, string companyName )
        {
            if(companyId==null)
            {
                return NotFound();
            }
            ViewData["company"] = new Company() { Id=companyId.Value,SimpleName=companyName };
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//Bind("ParentCompany.Id,Title")
        public async Task<IActionResult> Create(
         [FromForm] JobOpportunity jobOpportunity)
        {
           
            if(ModelState.IsValid)
            {
                jobOpportunity.Id = new Guid();
                _context.Add(jobOpportunity);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details","Companies",new { id = jobOpportunity.ParentCompanyId });
            }
            
            return View(jobOpportunity);
        }



        #region Delete
        //GET
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var jobOpportunity = await _context.JobOpportunities
                .SingleOrDefaultAsync(j => j.Id == id);
            if (jobOpportunity == null)
                return NotFound();
            return View(jobOpportunity);
        }

        //POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var jobOpportunity = await _context.JobOpportunities
                .SingleOrDefaultAsync(j => j.Id == id);
            var companyId = jobOpportunity.ParentCompanyId;
            _context.JobOpportunities.Remove(jobOpportunity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Companies", new { id = companyId });
        }
        #endregion


    }
}