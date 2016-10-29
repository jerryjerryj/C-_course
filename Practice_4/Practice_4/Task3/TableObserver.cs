using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4.Task3
{
    class TableObserver : IObserver<PerformedChangesInfo>
    {
         public string name { get; private set; }
         private IDisposable unsubscriber;

         public TableObserver(string name)
         {
             this.name = name;
         }

         public virtual void Subscribe(IObservable<PerformedChangesInfo> provider)
         {
            if (provider != null) 
               unsubscriber = provider.Subscribe(this);
         }

         public virtual void OnCompleted()
         {
             PrintMessage("Completed");
             this.Unsubscribe();
         }
         public virtual void OnError(Exception e)
         {
             PrintMessage("Error : "+ e.Message);
         }
         public virtual void OnNext(PerformedChangesInfo value)
         {
             PrintMessage(value.GetType().Name);
         }
         public virtual void Unsubscribe()
         {
            PrintMessage("Unsubscribed");
            unsubscriber.Dispose();
         }
         private void PrintMessage(string actionMessage)
         {
             Console.WriteLine(name + " : " + actionMessage);
         }
    }
}
