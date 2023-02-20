using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // DortIslem dortIslem = new DortIslem(2, 3);
            //Console.WriteLine(dortIslem.Topla());
            // Console.WriteLine(dortIslem.Topla2(3,4));
            var tip = typeof(DortIslem);
            //DortIslem dortIslem = (DortIslem)Activator.CreateInstance(tip,6,7);
            //Console.WriteLine(dortIslem.Topla());
            //Console.WriteLine(dortIslem.Topla2(3,4));
            var instance = Activator.CreateInstance(tip, 6, 7);
            MethodInfo methodInfo = instance.GetType().GetMethod("Topla");
            Console.WriteLine(methodInfo);
            Console.WriteLine(methodInfo.Invoke(instance, null));

            var metodlar = tip.GetMethods();
            foreach (var metodInfo in metodlar)
            {
                Console.WriteLine("Metod adı{0}",metodInfo.Name);
                foreach(var parametre in metodInfo.GetParameters())
                {
                    Console.WriteLine("parametreler {0}", parametre.Name);
                }
                foreach(var attribute in metodInfo.GetCustomAttributes())
                {
                    Console.WriteLine("---------->{0} -- {1}",metodlar,attribute.GetType().Name);
                }
            }
            Console.ReadLine();
        }
    }
    class DortIslem
    {
        private int _sayi1, _sayi2;
        public DortIslem(int sayi1, int sayi2)
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }
        public DortIslem()
        {

        }
        public int Topla()
        {
            return _sayi1 + _sayi2;
        }
        public int Carp()
        {
            return _sayi1 * _sayi2;
        }
        public int Topla2(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }
        [MethodName]
        public int Carp2(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }
    }
    class MethodNameAttribute : Attribute
    {

    }
}
