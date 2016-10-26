using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4
{
    public delegate bool Check(TransactionRequest request);
    public delegate Transaction Register(TransactionRequest request);
    public delegate void Save(Transaction transaction);
    public class Transaction { }
    public class TransactionRequest { }
    public class TransactionProcessor
    {
        Check check;
        Register register;
        Save save;

        public TransactionProcessor( Check check,Register register,Save save)
        {
            this.check = check;
            this.register = register;
            this.save = save;
        }
        public Transaction Process(TransactionRequest request)
        {
            if (!check(request))
                throw new ArgumentException();
            var result = register(request);
            save(result);
            return result;
        }
    }
}
