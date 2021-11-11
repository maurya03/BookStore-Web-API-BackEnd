using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Cart
    {
        public int cartId { get; set; }
        public int userId { get; set; }
        public int bookId { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }


        public Cart() { }

        public Cart(int uid,int bid, int qn, int t)
        {
             
            userId = uid;
            bookId = bid;
            Quantity = qn;
            Total = t;
        }
    }
}