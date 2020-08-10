using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScendMvc.Models;

namespace ScendMvc.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalsController : ControllerBase
    {
        private readonly ScendMVCContext _context;

        public ProposalsController(ScendMVCContext context)
        {
            _context = context;
        }

        // GET: api/Proposals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proposal>>> GetProposal()
        {
            return await _context.Proposal.ToListAsync();
        }

        // GET: api/Proposals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proposal>> GetProposal(int id)
        {
            var proposal = await _context.Proposal.FindAsync(id);

            if (proposal == null)
            {
                return NotFound();
            }

            return proposal;
        }

        // PUT: api/Proposals/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProposal(int id, Proposal proposal)
        {
            if (id != proposal.ProposalId)
            {
                return BadRequest();
            }

            _context.Entry(proposal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProposalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Proposals
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Proposal>> PostProposal(Proposal proposal)
        {
            _context.Proposal.Add(proposal);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProposalExists(proposal.ProposalId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProposal", new { id = proposal.ProposalId }, proposal);
        }

        // DELETE: api/Proposals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Proposal>> DeleteProposal(int id)
        {
            var proposal = await _context.Proposal.FindAsync(id);
            if (proposal == null)
            {
                return NotFound();
            }

            _context.Proposal.Remove(proposal);
            await _context.SaveChangesAsync();

            return proposal;
        }

        private bool ProposalExists(int id)
        {
            return _context.Proposal.Any(e => e.ProposalId == id);
        }
    }
}
