using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helper.GuidHelper
{
    public class GuidHelpers
    {
        public static string CreateGuid()
        {

            return Guid.NewGuid().ToString();
        }
    }
}
