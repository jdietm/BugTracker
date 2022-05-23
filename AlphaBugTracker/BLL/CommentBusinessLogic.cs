using AlphaBugTracker.DAL;
using AlphaBugTracker.Models;

namespace AlphaBugTracker.BLL
{
    public class CommentBusinessLogic
    {
        IRepository<TicketComment> repo;

        public CommentBusinessLogic(IRepository<TicketComment> repoArg)
        {
            repo = repoArg;
        }

        public List<TicketComment> ListComments_ByTicketId(int id)
        {
            return repo.GetList(c => c.Id == id).ToList();  // jUST REPLACE THEN
        }

        public TicketComment Get(int id)
        {
            return repo.Get(t => t.Id ==id);
        }

        public void AddTicketComment(TicketComment ticketComment)
        {
            repo.Create(ticketComment);
            repo.Save();
        }
    }
}
