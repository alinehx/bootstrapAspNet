using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces.Data;
using System.Collections;
using System.Data;

namespace Core.Data.Repositories
{
    public class OrderRepository : IOrderRepository<OrderRepository>
    {
        public IDatabase database { get; set; }
        public int orderId { get; set; }

        public OrderRepository(IDatabase _database)
        {
            database = _database;
        }
        private OrderRepository () { }

        public void Add(OrderRepository obj)
        {
            throw new NotImplementedException();
        }       

        public List<OrderRepository> GetAll()
        {
            List<OrderRepository> lOrderRepository = new  List<OrderRepository> ();
            try
            {
                string queryString = "SELECT * FROM TVEN_PEDIDO WHERE ROWNUM<=10";


                using (DataTable dataTable = database.ExecuteQueryReturnDataTable(queryString))
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        int order = Convert.ToInt32(dataRow["NI_PED"]);
                        lOrderRepository.Add(new OrderRepository() { orderId = order });
                    }                  
                    
                }
            }
            catch (Exception err)
            {

                throw new Exception("Error OrderRepository GetAll, " + err);
            }

            return lOrderRepository;
        }

        public OrderRepository GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(OrderRepository obj)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderRepository obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
