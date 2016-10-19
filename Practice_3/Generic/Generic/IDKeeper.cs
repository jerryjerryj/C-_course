using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
   
    public class IDKeeper
    {
        Dictionary<Type, Dictionary<Guid, Object>> guidBase = new Dictionary<Type, Dictionary<Guid, Object>>();
        public TObject CreateObject<TObject>()
            where TObject: new()
        {            
            var type = typeof(TObject);
            var someObject = new TObject();
            
            if(!guidBase.ContainsKey(type))
                guidBase.Add(type, new Dictionary<Guid,object>());

            guidBase[type].Add(Guid.NewGuid(),someObject);
            return someObject;
        }

        public Dictionary<Guid, Object> GetPair<TObject>()
        {
            var type = typeof(TObject);
            if (guidBase.ContainsKey(type))
                return guidBase[type];
            return null;
        }

        public Object GetObject(Guid guid)
        {
            foreach (var gBase in guidBase)
                if (gBase.Value.ContainsKey(guid))
                    return gBase.Value[guid];
            return null;

           
        }

    }
}
