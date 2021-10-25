using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;

namespace Service1.Interface
{
    public interface ITicketService
    {
        public Task CreateTicket(Ticket ticket);
        public Task DeleteTicket(int id);
        public Task<Ticket> UpdateTicket(Ticket ticket);
        public Task<List<Ticket>> GetAllTicket();
        public Task<Ticket> GetTicketById(int id);
    }
}
