using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Practice_4.Task1;
using Practice_4.Task2;

namespace Practice_4
{
    class Program
    {
        public static bool MyCheck(TransactionRequest request){ return true; }
        public static Transaction MyRegister(TransactionRequest request){ return new Transaction(); }
        public static void MySave(Transaction request) { }

        static void Main(string[] args)
        {
            // Task 1
            // var transactionProcessor= new TransactionProcessor((x) => MyCheck(x), (y) => MyRegister(y), (z)=> MySave(z));
            // transactionProcessor.Process(new TransactionRequest());

            // Task 2
        }
    }
}
