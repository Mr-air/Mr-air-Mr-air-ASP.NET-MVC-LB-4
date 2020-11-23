using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shoes_Store3.Models
{
    public class PagePag
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalShoes { get; set; }
        public int TotalPage
        {
            get { return (int)Math.Ceiling((double)TotalShoes / PageSize); }
        }
    }

    public class ViewShoes
    {
        public IEnumerable<Shoes> Shoess{ get; set; }
        public PagePag PagePag { get; set; }
    }
}