using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Devotion.Scripts.Orders
{
    public sealed class Order
    {
        public class OrderFood
        {
            public string Name { get; } = null;
            public string Dopings { get; } = null;

            public OrderFood(string name, string dopings)
            {
                Name = name;
                Dopings = dopings;
            }
        }

        public readonly string name;

        List<OrderFood> _foods;

        public ReadOnlyCollection<OrderFood> Foods { get { return _foods.AsReadOnly(); } }

        public Order(string _name, List<OrderFood> foods)
        {
            name = _name;
            _foods = foods;
        }
    }
}
