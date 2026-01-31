using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class OrderDeteilManeger : IOrderDeteilService
    {
        private readonly IOrderDeteilDal _orderDeteilDal;
        public OrderDeteilManeger(IOrderDeteilDal orderDeteilDal)
        {
            _orderDeteilDal = orderDeteilDal;
        }



        public void TAdd(OrderDeteil entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(OrderDeteil entity)
        {
            throw new NotImplementedException();
        }

        public OrderDeteil TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderDeteil> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(OrderDeteil entity)
        {
            throw new NotImplementedException();
        }
    }
}
