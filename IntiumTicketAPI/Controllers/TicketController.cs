using InitiumTicketSoftwareEntity.Model;
using InitiumTicketSoftwareEntity.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace IntiumTicketAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("ticket")]
        public async Task<ActionResult> SaveTicket([FromBody] Ticket ticket)
        {
            try
            {
                var savedTicket = await _ticketService.AddAsync(ticket);

                return Ok(savedTicket);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}
