using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace TicketShop.Services.Interface
{
    public interface IProductService
    {
        List<Ticket> GetAllProducts();
        Ticket GetDetailsForProduct(Guid? id);
        void CreateNewProduct(Ticket p);
        void UpdeteExistingProduct(Ticket p);
        AddToShoppingCardDto GetShoppingCartInfo(Guid? id);
        void DeleteProduct(Guid id);
        bool AddToShoppingCart(AddToShoppingCardDto item, string userID);
    }
}

