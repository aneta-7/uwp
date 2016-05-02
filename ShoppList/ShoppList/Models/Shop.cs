﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppList.Models
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


        public Nullable<DateTime> From;
        public Nullable<DateTime> To;

        public void showHistory(Nullable<DateTime> From, Nullable<DateTime> To)
        {
           
        }


    }
}
