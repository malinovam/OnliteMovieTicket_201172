using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTiketi.Services.Interface
{
    
    
        public interface IShoppingCartService
        {
            ShoppingCartDTO GetShoppingCartInfo(string userId);

            bool DeleteTicketFromShoppingCart(string userId, Guid id);

            bool OrderNow(string userId);
        }
    
}
