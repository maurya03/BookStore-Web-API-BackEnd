using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public interface ICartRepository
    {
        List<Cart> GetAllCarts();
        Cart GetCartById(int id);
        int AddCart(Cart cart);
        int updateCart(int id, Cart cart);
        int DaleteCart(int id);

       
    }
}