using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4.Task1
{
    public class Order { }
    public class OrderRequest { }
    public class OrderProcessor
    {
        private Func<OrderRequest, bool> check;
        private Func<OrderRequest, Order> register;
        private Action<Order> save;

        public OrderProcessor(Func<OrderRequest, bool> check, Func<OrderRequest, Order> register, Action<Order> save)
        {
            this.check = check;
            this.register = register;
            this.save = save;
        }
        public Order Process(OrderRequest request)
        {
            if (!check(request))
                throw new ArgumentException();
            var result = register(request);
            save(result);
            return result;
        }
    }
}
