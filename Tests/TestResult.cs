using System;
using FluentAssertions;
using Xunit;

using roptry.Rop;

namespace Tests
{
    using IntResult = Result<int, string>;
    using BoolResult = Result<bool, string>;

    public class ResultTest
    {
        [Fact]
        public void SuccessesAndFailures()
        {
		int expected = 10;
		var suc = Result<int, bool>.Succeeded(expected);
		suc.IsSuccess.Should().BeTrue();
		suc.IsFailure.Should().BeFalse();

		suc.Success.Should().Be(expected);

		var fld = Result<int, bool>.Failed(true);
		fld.IsSuccess.Should().BeFalse();
		fld.IsFailure.Should().BeTrue();

		fld.Failure.Should().BeTrue();
        }

	[Fact]
	public void EitherSuccessTest()
	{
	   Func<IntResult, BoolResult> onSuccess = x => BoolResult.Succeeded(true);
   	   Func<IntResult, BoolResult> onFailure = x => BoolResult.Succeeded(false);

	   var sucInt = Result<int, string>.Succeeded(1);
	   var result = sucInt.Either(onSuccess, onFailure);

	   result.Success.Should().BeTrue();
	}

	[Fact]
	public void EitherFailTest()
	{
	   Func<IntResult, BoolResult> onSuccess = x => BoolResult.Succeeded(true);
   	   Func<IntResult, BoolResult> onFailure = x => BoolResult.Succeeded(false);

	   var failInt = Result<int, string>.Failed("It's the thought that counts");
	   var result = failInt.Either(onSuccess, onFailure);

	   result.Success.Should().BeFalse();
	}
	
	[Fact]
	public void ToFailureTest()
	{
	   var failure = Result<int, int[]>.Failed(new []{0, 1, 2});
	   var result = failure.ToFailure();

	   Assert.Equal(result.Failure, failure.Failure);
	}


    }
}
