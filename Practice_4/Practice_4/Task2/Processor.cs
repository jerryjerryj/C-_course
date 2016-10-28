using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4.Task2
{

    public class Processor<TObjectRequest, TObject> 
        where TObjectRequest : class
        where TObject : class
    {
        private Func<TObjectRequest, bool> check;
        private Func<TObjectRequest, TObject> register;
        private Action<TObject> save;

        public Processor(Func<TObjectRequest, bool> check, Func<TObjectRequest, TObject> register, Action<TObject> save)
        {
            this.check = check;
            this.register = register;
            this.save = save;
        }
        public TObject Process(TObjectRequest request)
        {
            if (!check(request))
                throw new ArgumentException();
            var result = register(request);
            save(result);
            return result;
        }
    }
}
