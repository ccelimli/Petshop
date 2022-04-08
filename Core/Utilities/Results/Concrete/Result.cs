using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public bool Success { get; }

        public string Message { get; }
        public Result(bool Success)
        {
            this.Success = Success;
        }
        public Result(bool Success, string Message) : this(Success)
        {
            this.Message = Message;
        }
    }
}
