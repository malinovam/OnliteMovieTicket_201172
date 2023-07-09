using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTiketi.Domain.DTO
{
    internal class ShoppingCartDTO
    {
        public List<TicketInShoppingCart> Products { get; set; }
        public double TotalPrice { get; set; }
    }
}
