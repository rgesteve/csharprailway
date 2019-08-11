using System;
using System.Collections.Generic;
using System.Linq;

namespace roptry.Rop
{
	public static class ResultExtensions
	{
		/**
		*/
		public static void Handle<TSuccess, TFailure>
		(this Result<TSuccess, TFailure> result,
		 Action<TSuccess> onSuccess,
		 Action<TFailure> onFailure)
		{
			if (result.IsSuccess) {
			  onSuccess(result.Success);
			} else {
			  onFailure(result.Failure);
			}
		}
	
		/**
		`Either` takes two callbacks, one to be dispatch on success, the other
		on failure.  Think nodejs-style  continuation handling.
		*/
		public static Result<TSuccess2, TFailure2> Either<TSuccess, TFailure, TSuccess2, TFailure2>
		(this Result<TSuccess, TFailure> x,
 		 Func< Result<TSuccess, TFailure>, Result<TSuccess2, TFailure2> > onSuccess,
		 Func< Result<TSuccess, TFailure>, Result<TSuccess2, TFailure2> > onFailure
	  	 )
		 {
		   return x.IsSuccess ? onSuccess(x) : onFailure(x);
		 }

		 /**
		 Force :param Result x: to be a failure.

		 Implementation note: we have TFailure here be an array type,
		 so that it can be made an empty array failure.
		 */
		 public static Result<TSuccess, TFailure[]> ToFailure<TSuccess, TFailure>
		 (this Result<TSuccess, TFailure[]> x)
		 {
		   return x.Either(
		     a => Result<TSuccess, TFailure[]>.Failed(new TFailure[0]),
		     b => b
		   );
		 }

		 /**
		 Join (merge) two `Result`s together.  If they're both success, the
		 combined `Result` is also a success.  Otherwise, they result in a
		 failure.
		 */
		 public static Result<TSuccess[], TFailure[]> Merge<TSuccess, TFailure>
		 (this Result<TSuccess[], TFailure[]> accumulator,
 		  Result<TSuccess, TFailure[]> next)
		 {
		   if (accumulator.IsSuccess && next.IsSuccess) {
		     return Result<TSuccess[], TFailure[]>.Succeeded(
		       accumulator.Success.Concat(new List<TSuccess>() { next.Success }).ToArray());
		   }
		   return Result<TSuccess[], TFailure[]>.Failed(accumulator.ToFailure().Failure.Concat(next.ToFailure().Failure).ToArray());
		 }

		 /**
		 Aggregate an array of results together.
		 If any of the results fail, return combined failures
		 Will only return success if all results succeed
		 */
		 public static Result<TSuccess[], TFailure[]> Aggregate<TSuccess, TFailure>(this IEnumerable< Result<TSuccess, TFailure[]> > accumulator) {
		 	var emptySuccess = Result<TSuccess[], TFailure[]>.Succeeded(new TSuccess[0]);
			return accumulator.Aggregate(emptySuccess, (acc, o) => acc.Merge(o));
		 }

		 /**
		 Functional map
		 */
		 public static Result<TSuccessNew, TFailure> Map<TSuccess, TFailure, TSuccessNew>
		 (this Result<TSuccess, TFailure> x, Func<TSuccess, TSuccessNew> f)
		 {
		   return x.IsSuccess?
		       Result<TSuccessNew, TFailure>.Succeeded(f(x.Success))
		     : Result<TSuccessNew, TFailure>.Failed(x.Failure);
		 }

		 /**
		 Functional bind
		 */
		 public static Result<TSuccessNew, TFailure> Bind<TSuccess, TFailure, TSuccessNew>
		 (this Result<TSuccess, TFailure> x,
		  Func<TSuccess, Result<TSuccessNew, TFailure> > f)
		 {
		   return x.IsSuccess?
		       f(x.Success)
		     : Result<TSuccessNew, TFailure>.Failed(x.Failure);
		 }

		 /**
		 Capture intermediate value in a pipeline and feed it to a
		 side-effecting function
		 */
		 public static Result<TSuccess, TFailure> Tee<TSuccess, TFailure>
		 (this Result<TSuccess, TFailure> x, Action<TSuccess> f)
		 {
		   if (x.IsSuccess) {
		     f(x.Success);
		   }
		   return x;
		 }
	}
}
