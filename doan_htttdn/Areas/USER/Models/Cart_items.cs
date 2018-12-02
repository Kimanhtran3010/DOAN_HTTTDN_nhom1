using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using doan_htttdn.FF;

namespace doan_htttdn.Areas.USER.Models
{
    [Serializable]
    public class Cart_items
    {
        public PRODUCT product { get; set; }
        public int Quantity { get; set; }
    }
}