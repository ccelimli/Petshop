using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IResult Add(Order order)
        {
            if (order.OrderDate.ToString() == null)
            {
                return new ErrorResult(Messages.OrdersCanceled);
            }
            else
            {
                _orderDal.Add(order);
                return new SuccessResult(Messages.OrderAdded);
            }
        }

        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult(Messages.OrderDeleted);
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(), Messages.OrdersListed);
        }

        public IDataResult<List<Order>> GetByCustomerId(int CustomerId)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(o => o.CustomerId == CustomerId), Messages.OrdersListed);
        }

        public IDataResult<Order> GetById(int id)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(o => o.OrderId == id), Messages.OrderListed);
        }

        public IDataResult<List<Order>> GetByOrderDate(DateTime orderDate)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(o => o.OrderDate == orderDate), Messages.OrdersListed);
        }

        public IDataResult<List<Order>> GetByProductId(int ProductId)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(o => o.ProductId == ProductId), Messages.OrdersListed);
        }



        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult(Messages.OrderUpdated);
        }
    }
}
