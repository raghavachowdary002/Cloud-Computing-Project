using System;
using System.Collections.Generic;
using System.Text;

namespace MyExperiment.Utilities
{
    public static class StringUtilities
    {
        public static bool isBlankOrNull(string fileName)
        {
            return fileName == null || fileName.Trim().Length == 0;
        }
    }
}
