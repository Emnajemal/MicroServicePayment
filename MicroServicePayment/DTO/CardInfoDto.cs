namespace MicroServicePayment.DTO
{
    public class CardInfoDto
    {
        public long Pk { get; set; }
        
        public DateTime? Deliverydate { get; set; }
        public DateTime? Expirydate { get; set; }
        public string Status { get; set; } = null!;
        public string? Cardnumber { get; set; }
        public decimal? Maxgab { get; set; }

        public decimal? Maxtpe { get; set; }
    }
}
