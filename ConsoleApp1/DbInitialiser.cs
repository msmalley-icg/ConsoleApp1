using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;

namespace ConsoleApp1
{
    class DbInitialiser
    {
        private readonly ILogger<DbInitialiser> _logger;
        private readonly MyContext _context;

        public DbInitialiser(ILogger<DbInitialiser> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void Initialise()
        {
            _context.Database.EnsureCreated();
            _logger.LogInformation("Db creation ensured");
            //SimpleObjectCreate();
            ComplexObjectCreate();
        }

        public void ComplexObjectCreate()
        {
            string input = "msmalley,100\nmsmalley,200";
            string[] lines = input.Split("\n");
            foreach (string line in lines)
            {
                string[] fields = line.Split(",");
                string userName = fields[0];
                var user = _context.Users.FirstOrDefault(u => u.Name == userName);
                if (user == null)
                {
                    user = new User {Name = userName};
                }

                var order = new Order {Quantity = Int32.Parse(fields[1]), User = user};
                _context.Orders.Add(order);
                _logger.LogInformation($"Added order: {order}");
                _context.SaveChanges();
            }

            _context.SaveChanges();

        }

        private void SimpleObjectCreate()
        {

            User user1 = new User
            {
                Name = "First User"
            };

            _logger.LogInformation($"Just created the user: {user1}");
            Order order1 = new Order
            {
                Quantity = 100, User = user1
            };
            _logger.LogInformation($"Added to order:\nUser is: {user1}\nOrder is: {order1}");

            _context.Orders.Add(order1);

            _logger.LogInformation($"Added to dbset:\nUser is: {user1}\nOrder is: {order1}");


            _context.SaveChanges();
            _logger.LogInformation($"Saved dbset:\nUser is: {user1}\nOrder is: {order1}");

        }
    }
}
