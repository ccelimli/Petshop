using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T Data,string Message):base(Data,false,Message)
        {

        }
        public ErrorDataResult(T Data):base(Data,false)
        {

        }
        public ErrorDataResult():base(default,false)
        {

        }
        public ErrorDataResult(string Message):base(default,false,Message)
        {

        }
    }
}
