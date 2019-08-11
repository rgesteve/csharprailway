using System;

namespace roptry.Rop
{
    public class Result<TSuccess, TFailure>
    {
	private bool IsSuccessful { get; set; }
	private Result()
	{
	  /* empty, we don't want people instantiating this directly */
	}

	public bool IsSuccess => IsSuccessful;
	public bool IsFailure => !IsSuccessful;

	public TSuccess Success { get; private set; }
	public TFailure Failure { get; private set; }

	// Static factory methods

	public static Result<TSuccess, TFailure> Succeeded(TSuccess success)
	{

	  if (success == null) throw new ArgumentNullException(nameof(success));
	  return new Result<TSuccess, TFailure>
	  {
	    IsSuccessful = true,
	    Success = success
	  };
	}

	public static Result<TSuccess, TFailure> Failed(TFailure failure)
	{
	  if (failure == null) throw new ArgumentNullException(nameof(failure));
	  return new Result<TSuccess, TFailure>
	  {
	    IsSuccessful = false,
	    Failure = failure
	  };
	}

    }
}