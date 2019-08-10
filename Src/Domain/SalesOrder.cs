namespace roptry.Domain
{
/*
  public class SalesOrder : IPersisted
  {
  }
  */

  public class Customer
  {
	public Customer(string name, Tariff tariff)
	{
	    Name = name;
	    Tariff = tariff;
	}
	
	public string Name { get; private set; }
	public Tariff Tariff { get; private set; }
  }
}
