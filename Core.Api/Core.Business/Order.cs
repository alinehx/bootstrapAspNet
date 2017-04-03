using Core.Data.Repositories;
using Core.Interfaces;
using Core.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public class Order 
    {
        public OrderRepository orderRepository { get; private set; }
        public Order(OrderRepository _orderRepository)
        {
          orderRepository = _orderRepository;
        }

        public List<OrderRepository> getAll()
        {
            return orderRepository.GetAll();
        }


    }
}
