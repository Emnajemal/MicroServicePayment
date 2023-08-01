namespace MicroServicePayment.DTO
{
    public class PaymentcardDTO
    {
        public long Pk { get; set; }
        public DateTime? Deliverydate { get; set; }

        public DateTime? Expirydate { get; set; }

        public decimal? Maxgab { get; set; }
        public string? Cardnumber { get; set; }
    }
}
