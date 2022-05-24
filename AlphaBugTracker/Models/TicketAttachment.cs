﻿using Microsoft.AspNetCore.Identity;

namespace AlphaBugTracker.Models
{
    public class TicketAttachment
    {
        public int Id { get; set; }
        public Ticket Ticket;
        public string FilePath { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Users UserCreator { get; set; }
        public string FileUrl { get; set; }
    }
}
