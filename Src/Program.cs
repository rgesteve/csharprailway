using System;
using StructureMap;

using roptry.Config;
using roptry.Domain;

using roptry.V1;

namespace roptry
{
    class Program
    {
	private static readonly OrderShipped InvalidEvt = new OrderShipped
	{
	  OrderId = 2,
	  ShippingType = ShippingType.Teleport
	};
	
        static void Main(string[] args)
        {
	    Handle<V1.V1Registry>(InvalidEvt);
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
