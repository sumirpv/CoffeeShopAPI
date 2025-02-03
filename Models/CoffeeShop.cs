namespace CoffeeShopAPI.Models
{
    public class CoffeeShop
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
         public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }
        public string Location { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public bool IsOpen()
        {
            var currentTime = DateTime.Now.TimeOfDay;
            return currentTime >= OpeningTime && currentTime < ClosingTime;
        }
    }
}