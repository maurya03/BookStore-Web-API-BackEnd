using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Book
    {
        public int bookId { get; set; }
        public int ISBN { get; set; }
        public string Title { get; set; }
        public DateTime publicationYear { get; set; }
        public string bookDescription { get; set; }
        public int Price { get; set; }
        public int bookPosition { get; set; }
        public Boolean bookStatus { get; set; }
        public string imageName { get; set; }
        public string author { get; set; }
        public int catId { get; set; }

        public Book() { }

        public Book(int isbn, string Title, DateTime publicationYear, string bookDescription, int price, int bookPosition , Boolean bookStatus, string imageName, string author, int catId)
        {
            this.ISBN = isbn;
            this.Title = Title;
            this.publicationYear = publicationYear;
            this.bookDescription = bookDescription;
            this.Price = price;
            this.bookPosition = bookPosition;
            this.bookStatus = bookStatus;
            this.imageName = imageName;
            this.author = author;
            this.catId = catId;
        }
    }
}

