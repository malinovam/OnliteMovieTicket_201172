using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Domain.DomainModels;

namespace OnlineTiketi.Domain.DTO
{
    internal class AddToCardDto
    {
        public Ticket SelectedTicket { get; set; }
        public Guid TicketId { get; set; }
         public int Quantity { get; set; }
}
}
