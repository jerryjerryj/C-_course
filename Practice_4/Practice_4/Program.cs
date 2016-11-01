using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Practice_4.Task1;
using Practice_4.Task3;

namespace Practice_4
{
    class Program
    {
        //public static bool MyCheck(TransactionRequest request){ return true; }
        //public static Transaction MyRegister(TransactionRequest request){ return new Transaction(); }
        //public static void MySave(Transaction request) { }
        //static void Main(string[] args)
        //{
        //    var transactionProcessor = new TransactionProcessor((x) => MyCheck(x), (y) => MyRegister(y), (z) => MySave(z));
        //    transactionProcessor.Process(new TransactionRequest());
        //}

        static void Main(string[] args)
        {
            var provider = new DataModel();

            var observer1 = new TableObserver("TableObserver");
            observer1.Subscribe(provider);
            var observer2 = new Logger("Logger");
            observer2.Subscribe(provider);

            Console.WriteLine("  Inserting zero row and column:");
            provider.InsertRow(0);
            provider.InsertColumn(0);

            Console.WriteLine("\n  Put value in existed cell:");
            provider.Put(0, 0, 10);

            Console.WriteLine("\n  Put value in non-existed cell:");
            provider.Put(10,10, 10);

            Console.WriteLine("\n  Unsubscribe second:");
            observer2.Unsubscribe();

            Console.WriteLine("\n  Inserting one more row:");
            provider.InsertRow(1);

            Console.ReadKey();

        }
    }
}
