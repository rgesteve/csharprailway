using System.Linq;
using System.Collections.Generic;

using roptry.Domain;
using roptry.Rop;

namespace roptry.V4
{

  using static roptry.Rop.Result<roptry.Domain.SalesOrder, string[]>;

  public static class SalesOrderValidator
  {
    public static Result<SalesOrder, string[]> ValidateForInvoicing(SalesOrder salesOrder)
    {
      var errors = GetErrors(salesOrder).ToArray();

      return errors.Any() ?
          Failed(errors)
	: Succeeded(salesOrder);
    }

    private static IEnumerable<string> GetErrors(SalesOrder salesOrder)
    {
      if (salesOrder == null) {
        yield return "Order is null";
	yield break;
      }
      if (salesOrder.OrderPickDate == null) {
        yield return "Order has not been picked, cannot invoice";
      }
      if (salesOrder.Customer == null) {
        yield return "Order has no customer";
      } else if (salesOrder.Customer.Tariff == null) {
        yield return "Cannot determine tariff for customer";
      }
    }
  }
}