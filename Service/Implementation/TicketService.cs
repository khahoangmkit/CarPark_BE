using Service1.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;
using Model.Repository;

namespace Service1.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly IGenericRepository<Ticket> _ticketRepository;

        public TicketService(IGenericRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task CreateTicket(Ticket ticket)
        {
            await _ticketRepository.Create(ticket);
        }

        public async Task DeleteTicket(int id)
        {
            var _ticket = await _ticketRepository.GetById(id).ConfigureAwait(false);
            await _ticketRepository.Delete(_ticket);
        }

        public async Task<Ticket> UpdateTicket(Ticket ticket)
        {
            var _ticket = await _ticketRepository.GetById(ticket.Id).ConfigureAwait(false);
            if (_ticket != null)
            {
                _ticket.Car = ticket.Car;
                _ticket.Trip = ticket.Trip;
                _ticket.BookingTime = ticket.BookingTime;
                _ticket.CustomerName = ticket.CustomerName;
                _ticket.LicensePlate = ticket.LicensePlate;

                await _ticketRepository.Update(_ticket).ConfigureAwait(false);
            }

            return _ticket;
        }

        public async Task<List<Ticket>> GetAllTicket()
        {
            return await _ticketRepository.GetAll().ConfigureAwait(false);
        }

        public async Task<Ticket> GetTicketById(int id)
        {
            return await _ticketRepository.GetById(id).ConfigureAwait(false);
        }
    }
}