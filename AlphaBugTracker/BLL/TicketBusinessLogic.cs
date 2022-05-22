﻿using AlphaBugTracker.DAL;
using AlphaBugTracker.Models;

namespace AlphaBugTracker.BLL
{
    public class TicketBusinessLogic
    {
        IRepository<Ticket> repo;

        public TicketBusinessLogic(IRepository<Ticket> repoArg)
        {
            repo = repoArg;
        }

        public List<Ticket> ListTickets_ByDefault()
        {
            return repo.GetList(t => true).ToList();
        }

        public void AddTicket(Ticket ticket)
        {
            repo.Create(ticket);
            repo.Save();
        }
    }
}
