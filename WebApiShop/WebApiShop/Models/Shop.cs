﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiShop.Models
{
    public class Shop
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public Nullable<DateTime> Date { get; set; }
        [Required]
        public Double Value { get; set; }
        public String Descripion { get; set; }
        [Required]
        public String Category { get; set; }
        [Required]
        public int User_id { get; set; }

    }
}