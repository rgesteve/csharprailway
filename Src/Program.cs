using System;
using StructureMap;

using roptry.Config;
using roptry.Domain;

namespace roptry
{
    class Program
    {
        static void Main(string[] args)
        {
	    //Handle<V1.V1Registry>(InvalidEvt);
            Console.WriteLine("Hello World!");
        }

	private static void Handle<T>(OrderShipped evt) where T: Registry, new()
	{
	  Ioc.Configure<T>();
	  var handler = Ioc.Container.GetInstance<IHandler<OrderShipped>>();
	  //handler.handle(evt);
	}
    }
}
