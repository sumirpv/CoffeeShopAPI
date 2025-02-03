public class CreateCoffeeShopRequest
{
    public string Name { get; set; } = string.Empty;
    public TimeSpan OpeningTime { get; set; }
    public TimeSpan ClosingTime { get; set; }
    public string Location { get; set; } = string.Empty; 
    public decimal Rating { get; set; }
}