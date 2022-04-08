using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IResult Add(Order order);
        IResult Delete(Order order);
        IResult Update(Order order);
        IDataResult<List<Order>> GetAll();
        IDataResult<Order> GetById(int id);
        IDataResult<List<Order>> GetByProductId(int ProductId);
        IDataResult<List<Order>> GetByCustomerId(int CustomerId);
        IDataResult<List<Order>> GetByOrderDate(DateTime orderDate);


    }
}
