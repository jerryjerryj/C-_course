using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4.Task3
{
    class Logger: IObserver<PerformedChangesInfo>
    {
         public string instanceName { get; private set; }
         private IDisposable unsubscriber;

         public Logger(string instanceName)
         {
             this.instanceName = instanceName;
         }

         public virtual void Subscribe(IObservable<PerformedChangesInfo> provider)
         {
            if (provider != null) 
               unsubscriber = provider.Subscribe(this);
         }

         public virtual void OnCompleted()
         {
             PrintMessage("Completed.");
             this.Unsubscribe();
         }
         public virtual void OnError(Exception e)
         {
             PrintMessage("Error : "+ e.Message);
         }

         public virtual void OnNext(PerformedChangesInfo value)
         {
             if(value is ChangedRowField)
             {
                 var smth = (ChangedRowField)value;
                 PrintMessage("Inserted row : " + smth.insertedFieldIndex);
             }
             else if (value is ChangedColumnField)
             {
                 var smth = (ChangedColumnField)value;
                 PrintMessage("Inserted Column : " + smth.insertedFieldIndex);
             }
             else if (value is ChangedCell)
             {
                 var smth = (ChangedCell)value;
                 PrintMessage("Cell [" + smth.row + ";" + smth.column + "] has changed it's value to" + smth.changedValue);
             }
         }
         public virtual void Unsubscribe()
         {
            PrintMessage("Unsubscribed");
            unsubscriber.Dispose();
         }
         private void PrintMessage(string actionMessage)
         {
             Console.WriteLine(instanceName + " : " + actionMessage);
         }
    }
}
