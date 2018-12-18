using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace CbeltRetake.Models
{
    public class Idea
    {
        [Key]
        public int ideaid{get;set;}
        [Required]
        public string description{get;set;}
        public User myuser{get;set;}
        public List<Like> likes{get;set;}

    }
}