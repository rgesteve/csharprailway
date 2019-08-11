using System;

namespace roptry.Domain
{
    public class RandomDbException : Exception
    {
        public RandomDbException() : base("Something went wrong with the DB")
	{
	  /* empty */
	}
    }
}