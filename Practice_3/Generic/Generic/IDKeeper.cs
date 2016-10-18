using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    
    public class Base
    {
        public Type type;
        public Dictionary<Guid, Object> GuidObjectPair;
        public Base(Type type, Dictionary<Guid, Object> guidObjectPair)
        {
            this.type = type;
            GuidObjectPair = guidObjectPair;
        }
    }
    public class IDKeeper
    {
        List<Base> guidBase = new List<Base>();
        public TObject CreateObject<TObject>()
            where TObject: new()
        {
            var type = typeof(TObject);
            var someObject = new TObject();
            var foundedBase = guidBase.FirstOrDefault(x => x.type == type);

            if(foundedBase == null)
            {
                foundedBase = new Base(typeof(TObject),new Dictionary<Guid,object>());
                guidBase.Add(foundedBase);
            }
            
            foundedBase.GuidObjectPair.Add(Guid.NewGuid(), someObject);

            return someObject;
        }

        public Dictionary<Guid, Object> GetPair<TObject>()
        {
            var result = guidBase.FirstOrDefault(x => x.type == typeof(TObject));
            if(result!= null)
                return result.GuidObjectPair;
            return null;
        }

        public Object GetObject(Guid guid)
        {
            foreach (var list in guidBase)
            {
                Object result;
                if (list.GuidObjectPair.TryGetValue(guid, out result))
                    return result;
            }
            return null;

           
        }

    }
}
