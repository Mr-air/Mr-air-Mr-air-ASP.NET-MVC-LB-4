using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shoes_Store3.Models
{
    public class ShoesFilterList
    {
        public IEnumerable<Shoes> Shoes { get; set; }
        public SelectList Firma { get; set; }
    }
}