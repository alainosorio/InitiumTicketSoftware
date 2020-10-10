using InitiumTicketSoftwareEntity.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InitiumTicketSoftwareEntity.Service
{
    public class TicketService : ITicketService
    {
        private readonly IntiumTicketSoftwareContext _context;

        public TicketService(IntiumTicketSoftwareContext context)
        {
            _context = context;
        }

        public async Task<Ticket> AddAsync(Ticket ticket)
        {
            _ = ticket ?? throw new ArgumentNullException(nameof(ticket));

            try
            {
                int cola1 = _context.Ticket.Where(w => w.Queue == 1).Count() + 1 * 2;
                int cola2 = _context.Ticket.Where(w => w.Queue == 2).Count() + 1 * 3;

                await _context.Ticket.AddAsync(new Ticket
                {
                    Name = ticket.Name,
                    Queue = cola1 > cola2 ? 2 : 1,
                });

                await _context.SaveChangesAsync();

                return ticket;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeQueue(int queue)
        {
            try
            {
                Ticket delete = _context.Ticket.Where(w => w.Queue == queue).FirstOrDefault();

                _context.Ticket.Remove(delete);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
