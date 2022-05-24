using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaBugTracker.Models
{
    public class Users : IdentityUser
    {
        public virtual ICollection<TicketComment> TicketComments { get; set; }
        public virtual ICollection<ProjectUser> ProjectUsers { get; set; }
        public virtual ICollection<TicketHistory> TicketHistories { get; set; }
        public virtual ICollection<TicketAttachment> TicketAttachments { get; set; }
        [InverseProperty("OwnerUser")]
        public virtual ICollection<Ticket> OwnedTickets { get; set; }

        [InverseProperty("AssignedToUser")]
        public virtual ICollection<Ticket> AssignedTickets { get; set; }

        public Users()
        {
            this.TicketComments = new HashSet<TicketComment>();
            this.ProjectUsers = new HashSet<ProjectUser>();
            this.TicketHistories = new HashSet<TicketHistory>();
            this.TicketAttachments = new HashSet<TicketAttachment>();
        }
    }
}
