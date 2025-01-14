using Stripe;

namespace LapinCouvertAPI.Service;

public class UserService()
{
    public Customer Customer { get; set; }

    public Customer CreateCustomer() {

        StripeConfiguration.ApiKey = "sk_test_blablabla_votre_API_KEY_secrete";
        AddressOptions address = new AddressOptions() 
        {
            City = "Montreal",
            Country = "Canada",
            PostalCode = "J4H 4A9",
            State = "Quebec",
            Line1 = "945 Chambly"
        };


        var options = new CustomerCreateOptions
        {
            Email = "jim@nad.com",
            Name = "Jim Nad",
            Address = address
        };

        var service = new CustomerService();
        Customer customer = service.Create(options);

        Customer = customer;

        return customer;
    }

}