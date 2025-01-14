namespace Models.Models.Dtos;

public class PaymentIntentDTO
{
    public string ClientSecret { get; set; }
    //public string EphemeralKey { get; set; }
    public string Customer { get; set; }
}