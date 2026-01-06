using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayementAPI.Models;

namespace PayementAPI.Controllers
{
    //Added by Kunjal Mankame - 05-01-2026

    [Route("api/[controller]")]
    [ApiController]
    public class PaymetDetailController : ControllerBase
    {
        private readonly PaymentDetailContext _context;

        public PaymetDetailController(PaymentDetailContext context)
        {
            _context = context;
        }

        // GET: api/PaymetDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymetDetails>>> GetPaymentDetails()
        {
            return await _context.PaymentDetails.ToListAsync();
        }

        // GET: api/PaymetDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymetDetails>> GetPaymetDetails(int id)
        {
            var paymetDetails = await _context.PaymentDetails.FindAsync(id);

            if (paymetDetails == null)
            {
                return NotFound();
            }

            return paymetDetails;
        }

        // PUT: api/PaymetDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymetDetails(int id, PaymetDetails paymetDetails)
        {
            if (id != paymetDetails.PaymentDetailId)
            {
                return BadRequest();
            }

            _context.Entry(paymetDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymetDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _context.PaymentDetails.ToListAsync());
        }

        // POST: api/PaymetDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymetDetails>> PostPaymetDetails(PaymetDetails paymetDetails)
        {
            try
            {
                _context.PaymentDetails.Add(paymetDetails);
                await _context.SaveChangesAsync();

                // return CreatedAtAction("GetPaymetDetails", new { id = paymetDetails.PaymentDetailId }, paymetDetails);

                return Ok(await _context.PaymentDetails.ToListAsync());

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // DELETE: api/PaymetDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymetDetails(int id)
        {
            var paymetDetails = await _context.PaymentDetails.FindAsync(id);
            if (paymetDetails == null)
            {
                return NotFound();
            }

            _context.PaymentDetails.Remove(paymetDetails);
            await _context.SaveChangesAsync();

            return Ok(await _context.PaymentDetails.ToListAsync());
        }

        private bool PaymetDetailsExists(int id)
        {
            return _context.PaymentDetails.Any(e => e.PaymentDetailId == id);
        }
    }
}
