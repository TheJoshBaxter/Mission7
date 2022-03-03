using System;
using System.Linq;


//this file sets up the interface
//EF file implements the interface

namespace Mission7.Models
{
    public interface IOrderRepository
    {
        
        IQueryable<Order> Orders { get; } //default is public, so since I didn't specify here, its public

        void SaveOrder(Order order);
    }
}
