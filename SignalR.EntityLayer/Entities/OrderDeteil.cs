using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.EntityLayer.Entities;

namespace SignalR.EntityLayer.Entities
{
    public class OrderDeteil
    {
        public int OrderDeteilID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public int UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}
