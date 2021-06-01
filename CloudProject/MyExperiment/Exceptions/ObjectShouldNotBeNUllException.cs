using System;
using System.Collections.Generic;
using System.Text;

namespace MyExperiment.Exceptions
{
    public class ObjectShouldNotBeNUllException : Exception
    {
        public ObjectShouldNotBeNUllException(string message)
            : base(message)
        {

        }
    }
}
