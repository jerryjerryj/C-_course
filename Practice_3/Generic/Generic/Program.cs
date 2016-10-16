using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class Program
    {
        class MyEngine { }
        class MyEntity { }
        class MyLogger { }

        class Processor<TEngine, TEntity, TLogger> { }
        class Processor
        {
            public static Processor<TEngine> CreateEngine<TEngine>()
               where TEngine : class
            {
                return new Processor<TEngine>();
            }
        }
        class Processor<TEngine>
        {
            public Processor<TEngine, TEntity> For<TEntity>()
               where TEntity : class
            {
                return new Processor<TEngine, TEntity>();
            }

        }
        class Processor<TEngine, TEntity>
        {
            public Processor<TEngine, TEntity, TLogger> With<TLogger>()
             where TLogger : class
            {
                return new Processor<TEngine, TEntity, TLogger>();
            }
        }
        static void Main(string[] args)
        {
            var result = Processor.CreateEngine<MyEngine>().For<MyEntity>().With<MyLogger>();
        }
    }
}