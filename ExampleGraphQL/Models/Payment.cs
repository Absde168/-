namespace HotelGraphQL.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public int GuestId { get; set; }
        public Guest Guest { get; set; }

        public decimal Amount { get; set; } // Сумма платежа

        public DateTime Date { get; set; } // Дата платежа
    }
}
