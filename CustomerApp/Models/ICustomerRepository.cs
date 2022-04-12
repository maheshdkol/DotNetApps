using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CustomerApp.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer Get(string customerID);
        Customer Add(Customer item);
        bool Remove(string customerID);
        bool Update(Customer item);
    }
}