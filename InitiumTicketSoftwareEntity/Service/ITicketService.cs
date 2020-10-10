using InitiumTicketSoftwareEntity.Model;
using System.Threading.Tasks;

namespace InitiumTicketSoftwareEntity.Service
{
    public interface ITicketService
    {
        Task<Ticket> AddAsync(Ticket ticket);
        Task DeQueue(int queue);
    }
}