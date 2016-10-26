using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4
{
    class Program
    {
        public static bool MyCheck(TransactionRequest request)
        {
            return true;
        }
        public static Transaction MyRegister(TransactionRequest request)
        {
            return new Transaction();
        }
        public static void MySave(Transaction request)
        {
        }
        static void Main(string[] args)
        {
            var transactionProcessor= new TransactionProcessor(new Check(MyCheck), new Register(MyRegister), new Save(MySave));
            transactionProcessor.Process(new TransactionRequest());
        }
    }
}
