using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Category
    {
        public int catId { get; set; }
        public string catName { get; set; }
        public string description { get; set; }
        public string imageName { get; set; }
        public int position { get; set; }
        public Boolean catStatus { get; set; }
        public DateTime createdAt { get; set; }



        public Category() { }

        public Category(int catId, string catName, string desc, string img, int position, Boolean catStatus, DateTime createdAt )
        {
            this.catId = catId;
            this.catName = catName;
            this.description = desc;
            this.imageName = img;
            this.position = position;
            this.catStatus = catStatus;
            this.createdAt = createdAt;
        }
    }

     


}



 