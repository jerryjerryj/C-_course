using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4.Task2
{
    public class Transaction { }
    public class TransactionRequest { }
    class TransactionProcessor : Processor<TransactionRequest, Transaction>
    {
        public TransactionProcessor(Func<TransactionRequest, bool> check, Func<TransactionRequest, Transaction> register, Action<Transaction> save)
            : base(check, register, save) { }
    }
}
