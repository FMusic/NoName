using System;

namespace Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string TableNumber { get; set; }
        public double TotalPrice { get; set; }
        public bool Charged { get; set; }
        public int UserId { get; set; }
        public int PlaceId { get; set; }
        public string Time
        {
            get
            {
                return $"{DateTime.Hour}:{DateTime.Minute}";
            }
        }
    }
}
