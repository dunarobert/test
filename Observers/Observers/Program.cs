using ObserversLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Observers
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //incarcare produse
            var nokiaPhone = new ProductSubject("Nokia 3310", 100);
            var iphonePhone = new ProductSubject("iPhone 9", 10000);

            //incarcare clienti
            var ionCustomer = new Customer("Ion");
            var mariaCustomer = new Customer("Maria");
            var ioanaCustomer = new Customer("Ioana");
            var vasileCustomer = new Customer("Vasile");

            // clienti aleg notificari
            var ionCustomerObserver = new EmailCustomerObserver(ionCustomer);
            var mariaCustomerObserver = new EmailCustomerObserver(mariaCustomer);
            nokiaPhone.OnPriceChanged += ionCustomerObserver.PriceChanged;
            nokiaPhone.OnPriceChanged += mariaCustomerObserver.PriceChanged;
            //nokiaPhone.AddObserver(new EmailCustomerObserver(ionCustomer));
            //nokiaPhone.AddObserver(new EmailCustomerObserver(mariaCustomer));
            nokiaPhone.AddObserver(new SmsCustomerObserver(ioanaCustomer));
            iphonePhone.AddObserver(new SmsCustomerObserver(ioanaCustomer));
            iphonePhone.AddObserver(new EmailCustomerObserver(vasileCustomer));

            //modificam preturi
            iphonePhone.Price = 999;
            nokiaPhone.Price = 99;

            //
            nokiaPhone.RemoveObserver(new EmailCustomerObserver(mariaCustomer));
            iphonePhone.AddObserver(new EmailCustomerObserver(mariaCustomer));

            //
            iphonePhone.Price = 9999;
            nokiaPhone.Price = 49;



            Console.ReadKey();
        }
    }
}
