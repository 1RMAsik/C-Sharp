namespace lab_20;

internal static class Program
{
	public static void Main()
	{
		var houses = new IHouse[]
		{
			new ApartmentRent()
			{
				PriceMonth = 3.14,
				RentalPeriod = 5
			},
			new ApartmentSale()
			{
				PriceMeter = 3.60,
				Area = 5
			},
			new ApartmentRent()
			{
				PriceMonth = 5.16,
				RentalPeriod = 3
			}
		};
		SearchByPrice(houses);
	}

	private static void GetInfo<T>(T house) where T : IHouse
	{
		Console.WriteLine("-- House -- \n" +
		                  $"Type: {house.Type}\n" +
		                  $"Price: {house.GetPrice()}");
	}

	private static void SearchByPrice<T>(IEnumerable<T> houses) where T : IHouse
	{
		Console.Write("Write min price: ");
		var maxPrice = int.Parse(Console.ReadLine()!); 
		foreach (var gHouse in houses)
		{
			if (maxPrice < gHouse.GetPrice())
				GetInfo(gHouse);
		}
	}
}