using System;
using System.Collections.Generic;
using System.Linq;

namespace roptry.Rop
{
	public static class ResultExtensions
	{
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
	}
}
