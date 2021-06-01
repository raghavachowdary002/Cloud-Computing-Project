﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyExperiment.Exceptions
{
    public class EmptyStringException : System.Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public EmptyStringException(string message)
            : base(message)
        {
        }
    }
}
