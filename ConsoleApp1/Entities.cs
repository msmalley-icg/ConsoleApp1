using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Entities
    {
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }
    }

    public class Order
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Quantity)}: {Quantity}, {nameof(UserId)}: {UserId}, {nameof(User)}: {User}";
        }
    }
}
