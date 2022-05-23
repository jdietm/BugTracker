using AlphaBugTracker.Data;
using AlphaBugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AlphaBugTracker.DAL
{
    public class CommentRepository : IRepository<TicketComment>
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(TicketComment? entity)
        {
            _context.TicketComment.Add(entity);
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public TicketComment? Get(Func<TicketComment, bool>? firstFunction)
        {
            throw new NotImplementedException();
        }

        public ICollection<TicketComment>? GetList(Func<TicketComment, bool>? whereFunction)
        {
            List<TicketComment> ticketComment = null;
            if (whereFunction != null)
            {
                ticketComment = _context.TicketComment.Where(whereFunction).ToList();

                Ticket ticket = new Ticket();
                ticket = _context.Ticket.Where(t => t.Id == 1).First();
                ticketComment = _context.TicketComment.Where(t=> t.Ticket.Id == ticket.Id).ToList();  /// Rebuild!!!
            }
            return ticketComment;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(TicketComment? entity)
        {
            throw new NotImplementedException();
        }
    }
}
