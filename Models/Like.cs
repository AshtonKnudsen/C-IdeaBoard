using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace CbeltRetake.Models
{
    public class Like
    {
        public int likeid{get;set;}
        public int userid{get;set;}
        public User user{get;set;}
        public int ideaid{get;set;}
        public Idea idea{get;set;}
    }
}