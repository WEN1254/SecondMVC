using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScendMvc.Models;

namespace ScendMvc.Controllers
{
    public class Proposals1Controller : Controller
    {
        private readonly ScendMVCContext _context;

        public Proposals1Controller(ScendMVCContext context)
        {
            _context = context;
        }

        // GET: Proposals1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Proposal.ToListAsync());
        }

        // GET: Proposals1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proposal = await _context.Proposal
                .FirstOrDefaultAsync(m => m.ProposalId == id);
            if (proposal == null)
            {
                return NotFound();
            }

            return View(proposal);
        }

        // GET: Proposals1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proposals1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProposalId,IsFavorite,Title,Summary,ProjectCover,TimeStart,TimeEnd,Category,Target,Video,Content,Principal,Email,Tel,Identity,ImgTeam,DisplayName,Resume,FanPage,Web,CurrentAmount,Game_show")] Proposal proposal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proposal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proposal);
        }

        // GET: Proposals1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proposal = await _context.Proposal.FindAsync(id);
            if (proposal == null)
            {
                return NotFound();
            }
            return View(proposal);
        }

        // POST: Proposals1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProposalId,IsFavorite,Title,Summary,ProjectCover,TimeStart,TimeEnd,Category,Target,Video,Content,Principal,Email,Tel,Identity,ImgTeam,DisplayName,Resume,FanPage,Web,CurrentAmount,Game_show")] Proposal proposal)
        {
            if (id != proposal.ProposalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proposal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProposalExists(proposal.ProposalId))
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
            return View(proposal);
        }

        // GET: Proposals1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proposal = await _context.Proposal
                .FirstOrDefaultAsync(m => m.ProposalId == id);
            if (proposal == null)
            {
                return NotFound();
            }

            return View(proposal);
        }

        // POST: Proposals1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proposal = await _context.Proposal.FindAsync(id);
            _context.Proposal.Remove(proposal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProposalExists(int id)
        {
            return _context.Proposal.Any(e => e.ProposalId == id);
        }
    }
}
