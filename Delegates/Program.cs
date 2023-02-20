using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate void MyDelegate();
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            //customerManager.SendMessage();
            //customerManager.ShowAlert();

            MyDelegate myDelegate = customerManager.SendMessage;
            myDelegate += customerManager.ShowAlert;
            myDelegate();
            Console.WriteLine("Few A Later...");
            myDelegate-=customerManager.SendMessage;
            myDelegate();
            Console.ReadLine();
        }
    }
    public class CustomerManager
    {
        public void SendMessage()
        {
            Console.WriteLine("hello!");
        }
        public void ShowAlert()
        {
            Console.WriteLine("Be Careful!");
        }
    }
}
