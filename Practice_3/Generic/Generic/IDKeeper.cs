using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class Pair
    {
        public Guid guid { get; private set; }
        public dynamic someObject { get; private set; }
        public Pair(Guid guid, dynamic someObject)
        {
            this.guid = guid;
            this.someObject = someObject;
        }
    }
    class IDKeeper
    {
        private static Dictionary<Guid, dynamic> guidBase = new Dictionary<Guid,dynamic>();

        public TObject CreateObject<TObject>()
            where TObject: class, new()
        {
            var someObject = new TObject();
            guidBase.Add(Guid.NewGuid(), someObject);
            return someObject;
        }

        public Pair GetPair(dynamic someObject)
        {
            var key = guidBase.FirstOrDefault(x => x.Value == someObject).Key;
            return new Pair(key, someObject);
        }
        //public Pair GetPair<TObject>()
        //    where TObject : new()
        //{
        //    var someObject = new TObject();
        //    var key = guidBase.FirstOrDefault(x => x.Value == someObject ).Key;
        //    return new Pair(key, someObject);
        //}

        public dynamic GetObject(Guid guid)
        {
            try
            {
                return guidBase[guid];
            }
            catch(KeyNotFoundException)
            {
                return null;
            }
        }

    }
}
