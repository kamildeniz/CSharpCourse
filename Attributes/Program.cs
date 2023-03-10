using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer { Id = 1, FirstName = "Kamil", Age = 28 };
            CustomerDal customerDal = new CustomerDal();
            customerDal.Add(customer);
            customerDal.AddNew(customer);
            Console.ReadLine();
        }
    }
    [ToTable("Customers")]
    [ToTable("TblCustomers")]
    public class Customer
    {
        public int Id { get; set; }
        [RequiredProperty]
        public string FirstName { get; set; }
        [RequiredProperty]
        public string LastName { get; set; }
        [RequiredProperty]
        public int Age { get; set; }
    }
    public class CustomerDal
    {
        [Obsolete("dont use Add, instead use AddNew Method")]
        public void Add(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} added!", customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }
        public void AddNew(Customer customer)
        {
            Console.WriteLine("{0},{1},{2},{3} added!", customer.Id, customer.FirstName, customer.LastName, customer.Age);
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    class RequiredPropertyAttribute : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    class ToTableAttribute : Attribute
    {
        private string  _tablename;

        public ToTableAttribute(string tablename)
        {
            _tablename = tablename;
        }
    }
}
