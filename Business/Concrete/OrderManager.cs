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

        // Add
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

        // Delete
        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult(Messages.OrderDeleted);
        }

        // GetAll
        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(), Messages.OrdersListed);
        }

        //GetByCustomerId
        public IDataResult<List<Order>> GetByCustomerId(int CustomerId)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(order => order.CustomerId == CustomerId), Messages.OrdersListed);
        }

        //GetById
        public IDataResult<Order> GetById(int id)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(order => order.OrderId == id), Messages.OrderListed);
        }

        // GetByOrderDate
        public IDataResult<List<Order>> GetByOrderDate(DateTime orderDate)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(o => o.OrderDate == orderDate), Messages.OrdersListed);
        }

        // GetByProductId
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
