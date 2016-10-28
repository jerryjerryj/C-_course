using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4.Task2
{
    public class Order { }
    public class OrderRequest { }
    class OrderProcessor : Processor<OrderRequest, Order>
    {
        public OrderProcessor(Func<OrderRequest, bool> check, Func<OrderRequest, Order> register, Action<Order> save)
            : base(check, register, save) { }
    }
}
