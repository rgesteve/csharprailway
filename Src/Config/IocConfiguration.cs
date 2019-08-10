//using roptry.Domain;
using StructureMap;

namespace roptry.Config
{
  public class Ioc
  {
    public static IContainer Container { get; private set; }

    public static void Configure<T>() where T : Registry, new()
    {
      Container = new Container(x => x.AddRegistry<T>());
    }
  }
}