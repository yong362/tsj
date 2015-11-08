using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
    public class Asset
    {
        public int ID { get; set; }
         [Display(Name = "Created By")]
        public string CreatedBy {get;set;}
        [Display(Name = "Equipment Name")]
        public string Name { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Type of Assets")]
        public string Type { get; set; } 
        public string Barcode { get; set; } 
        public string Location { get; set; }
        [Display(Name = "Room Name")]
        public string roomName { get; set; }
      
    }
    public class test
    {
        public int ID { get; set; }
        public String CustomerName { get; set; }
        [Display(Name = "Created By")]
        public string Email { get; set; }
        [Display(Name = "Equipment Name")]
        public string Residence { get; set; }
        public string SalesPerson { get; set; }
        public string ItemBought { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MonthBought { get; set; }
        [Display(Name = "Type of Assets")]
        public string Price { get; set; }
        [Display(Name = "Room Name")]
        public int Qty { get; set; }
        public int Sales { get; set; }
    }
    public class MovieDBContext : DbContext
    {
        public MovieDBContext()
            : base("name=DefaultConnection")
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public System.Data.Entity.DbSet<MvcMovie.Models.test> test { get; set; }
        public System.Data.Entity.DbSet<MvcMovie.Models.Asset> Assets { get; set; }
    }
   
}