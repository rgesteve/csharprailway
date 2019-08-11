using System;
using StructureMap;

using roptry.Config;
using roptry.Domain;

using roptry.V1;

namespace roptry
{
    class Program
    {

	private static readonly OrderShipped SafeEvt = new OrderShipped
	{
	  OrderId = 1,
	  ShippingType = ShippingType.Standard
	};

	// Problem: Teleportation not yet cracked!
	private static readonly OrderShipped InvalidEvt = new OrderShipped
	{
	  OrderId = 2,
	  ShippingType = ShippingType.Teleport
	};
	
        static void Main(string[] args)
        {
	    // Handle<V1.V1Registry>(SafeEvt);
	    // Handle<V1.V1Registry>(InvalidEvt);
	    // Handle<V4.V4Registry>(SafeEvt);
    	    Handle<V4.V4Registry>(InvalidEvt);
            Console.WriteLine("Done!");
        }

	private static void Handle<T>(OrderShipped evt) where T: Registry, new()
	{
	  Ioc.Configure<T>();
	  var handler = Ioc.Container.GetInstance<IHandler<OrderShipped>>();
	  handler.Handle(evt);
	}
    }
}
