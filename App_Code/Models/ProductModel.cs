﻿using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
namespace jpdemo1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}