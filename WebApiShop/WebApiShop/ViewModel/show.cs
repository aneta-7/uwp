﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiShop.Models;

namespace WebApiShop.ViewModel
{
    public class show
    {

        private WebApiShopContext db = new WebApiShopContext();
        public void showHistory(Nullable<DateTime> From, Nullable<DateTime> To) {

            var result = from shop in db.Shops where (shop.Date>From && shop.Date<To) select shop;

        }


        public void calculateToNotyficate(int id)
        {
            var now = DateTime.Today;
       //     var from = db.Settings.Where(a => a.User_id == id).Select()

          


        }


        }
    }
