using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TABFMVC5.ViewModels
{
    public class OrderStatusBatchUpdateViewModel
    {
        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
    }
}