using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace travelApp.Models.Classes
{
    public class Blog
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string BlogImg { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}