using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Application.Exceptions
{
    public class ForbiddenAccessException : Exception
    {
        public ForbiddenAccessException() : base() { }
    }
}
