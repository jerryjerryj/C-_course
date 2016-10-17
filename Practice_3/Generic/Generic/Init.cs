using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class Init
    {
        class MyEngine { }
        class MyEntity { }
        class MyLogger { }

        class Processor<TEngine, TEntity, TLogger> { }
        class Processor
        {
            public static ProcessorWithEngine<TEngine> CreateEngine<TEngine>()
               where TEngine : class
            {
                return new ProcessorWithEngine<TEngine>();
            }
        }
        class ProcessorWithEngine<TEngine>
        {
            public ProcessorWithEngineAndEntity<TEngine, TEntity> For<TEntity>()
               where TEntity : class
            {
                return new ProcessorWithEngineAndEntity<TEngine, TEntity>();
            }

        }
        class ProcessorWithEngineAndEntity<TEngine, TEntity>
        {
            public Processor<TEngine, TEntity, TLogger> With<TLogger>()
             where TLogger : class
            {
                return new Processor<TEngine, TEntity, TLogger>();
            }
        }
        static void main()
        {
            var result = Processor.CreateEngine<MyEngine>().For<MyEntity>().With<MyLogger>();
        }
    }
}