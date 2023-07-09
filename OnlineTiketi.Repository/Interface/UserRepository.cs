using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTiketi.Repository.Interface
{
    public interface UserRepository
    {
        IEnumerable<TicketShopApplicationUser> GetAll();
        TicketShopApplicationUser Get(string id);
        void Insert(TicketShopApplicationUser entity);
        void Update(TicketShopApplicationUser entity);
        void Delete(TicketShopApplicationUser entity);
    }
}
