using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T Data, string Message):base(Data,true,Message)
        {

        }
        public SuccessDataResult(T Data):base(Data,true)
        {

        }
        public SuccessDataResult(string Message):base(default,true,Message)
        {
                
        }
        public SuccessDataResult():base(default,true)
        {

        }
    }
}
