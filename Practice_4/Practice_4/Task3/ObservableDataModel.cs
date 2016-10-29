using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4.Task3
{
    abstract class ObservableDataModel : IObservable<PerformedChangesInfo>
    {
        private List<IObserver<PerformedChangesInfo>> observers = new List<IObserver<PerformedChangesInfo>>();
        public IDisposable Subscribe(IObserver<PerformedChangesInfo> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<PerformedChangesInfo>> observers;
            private IObserver<PerformedChangesInfo> observer;

            public Unsubscriber(List<IObserver<PerformedChangesInfo>> observers, IObserver<PerformedChangesInfo> observer)
            {
                this.observers = observers;
                this.observer = observer;
            }
            public void Dispose()
            {
                if (observer != null && observers.Contains(observer))
                    observers.Remove(observer);
            }
        }
        protected void NotifyObserversOnChange(PerformedChangesInfo info)
        {
            foreach (var observer in observers)
                observer.OnNext(info);
        }

        protected void NotifyObserversOnError(Exception e)
        {
            foreach (var observer in observers)
                observer.OnError(e);
        }
    }
}
