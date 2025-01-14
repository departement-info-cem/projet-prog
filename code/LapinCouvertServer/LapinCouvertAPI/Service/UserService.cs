using LapinCouvertModels.Data;
using LapinCouvertModels.Models;
using Stripe;

namespace LapinCouvertAPI.Service;

public class UserService()
{
    public Customer Customer { get; set; }

    public Customer CreateCustomer() {

        StripeConfiguration.ApiKey = "sk_test_51QfOqBQWucU8YVtBiIzRZuz9lABjqG0UgZPAteyKSrYRBJzjTBd6qtJN94G3Vw1LFFPiBWqDm5zSM00ZRUSdCKvi00687JtwMk";
        AddressOptions address = new AddressOptions() 
        {
            City = "Montreal",
            Country = "Canada",
            PostalCode = "H2J0B1",
            State = "Quebec",
            Line1 = "5225 Resther"
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