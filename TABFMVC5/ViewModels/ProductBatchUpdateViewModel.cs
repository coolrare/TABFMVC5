using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TABFMVC5.ViewModels
{
    public class ProductBatchUpdateViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Decimal Stock { get; set; }
    }
}