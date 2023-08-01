namespace MicroServicePayment.DTO
{
    public class AccountcontractDTO
    {
        public string? Accountcode { get; set; }
        public bool? Accountmig { get; set; }
        public string Accountnumber { get; set; } = null!;
    }
}
