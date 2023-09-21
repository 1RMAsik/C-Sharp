namespace lab_20;

public enum Type
{
	Sale, Rent
}

public interface IHouse
{
	public Type Type { get; }
	public double GetPrice();
}

public class ApartmentSale : IHouse
{
	public double PriceMeter { get; init; }
	public double Area { get; init; }
	public Type Type { get; set; } = Type.Sale;
	public double GetPrice() => PriceMeter * Area;
}

public class ApartmentRent : IHouse
{
	public double PriceMonth { get; init; }
	public int RentalPeriod { get; init; }
	public Type Type { get; set; } = Type.Rent;
	public double GetPrice() => RentalPeriod * PriceMonth;
}