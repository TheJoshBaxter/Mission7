using System;
using System.Linq;

namespace Mission7.Models
{
    //interface is not a class...its a template for a class. Ensures it's used correctly
    //when you use this interface, you must implement these particular methods
    public interface IBookstoreRepository
    {
        //alternative to a list
        IQueryable<Book> Books { get; } //readable, but not writeable
    }
}
