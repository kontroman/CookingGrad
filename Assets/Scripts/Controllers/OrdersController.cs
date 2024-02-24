using Devotion.Scripts.GameData;
using Devotion.Scripts.Orders;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Devotion.Scripts.Controllers
{
	public sealed class OrdersController : BaseController
	{
		public static OrdersController Instance { get; private set; }

		public List<Order> Orders = new List<Order>();
		public List<OrderPlace> Places = new List<OrderPlace>();

		bool isInit = false;

		void Awake()
		{
			if (Instance != null) return;
			else Instance = this;
		}

		void OnDestroy()
		{
			if (Instance == this)
			{
				Instance = null;
			}
		}

		public override Task InitComponent(LevelData levelData)
		{
			if (isInit)
				return Task.CompletedTask;

			var ordersConfig = levelData.AvailableOrders;
			var ordersXml = new XmlDocument();

			using (var reader = new StringReader(ordersConfig.ToString()))
			{
				ordersXml.Load(reader);
			}

			var rootElem = ordersXml.DocumentElement;

			foreach (XmlNode node in rootElem.SelectNodes("order"))
			{
				var order = ParseOrder(node);
				Orders.Add(order);
			}

			isInit = true;

			foreach (var item in Places)
			{
				item.Init();
			}

			return Task.CompletedTask;
		}

		Order ParseOrder(XmlNode node)
		{
			var foods = new List<Order.OrderFood>();
			foreach (XmlNode foodNode in node.SelectNodes("food"))
			{
				foods.Add(new Order.OrderFood(foodNode.InnerText, foodNode.SelectSingleNode("@needs")?.InnerText));
			}
			return new Order(node.SelectSingleNode("@name").Value, foods);
		}

		public Order FindOrder(List<string> foods)
		{
			return Orders.Find(x =>
			{
				if (x.Foods.Count != foods.Count)
				{
					return false;
				}

				foreach (var food in x.Foods)
				{
					if (x.Foods.Count(f => f.Name == food.Name) != foods.Count(f => f == food.Name))
					{
						return false;
					}
				}
				return true;
			});
		}

	}
}