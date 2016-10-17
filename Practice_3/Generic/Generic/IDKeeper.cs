using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    public class IDKeeper
    {
        private Dictionary<Guid, Object> guidBase = new Dictionary<Guid,Object>();
        
        public TObject CreateObject<TObject>()
            where TObject: new()
        {
            var someObject = new TObject();
            guidBase.Add(Guid.NewGuid(), someObject);
            return someObject;
        }

        public Dictionary<Guid, Object> GetPair<TObject>()
        {
            return guidBase.Where(x => x.Value.GetType()== typeof(TObject)).ToDictionary(x=>x.Key, x=>x.Value);
        }

        public Object GetObject(Guid guid)
        {
           return guidBase.FirstOrDefault(x => x.Key == guid).Value;
        }

    }
}
