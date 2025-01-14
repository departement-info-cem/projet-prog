using System.Xml;
using LapinCouvertAPI.Service;
using LapinCouvertModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Models.Dtos;
using Stripe;

namespace LapinCouvertAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class StripeController(UserService userService) : Controller
{
    [HttpGet]
    public ActionResult<PaymentIntentDTO> CreatePaymentIntent()
    {
        // Set your secret key. Remember to switch to your live secret key in production.
        // See your keys here: https://dashboard.stripe.com/apikeys
        StripeConfiguration.ApiKey = "sk_test_51QfOqBQWucU8YVtBiIzRZuz9lABjqG0UgZPAteyKSrYRBJzjTBd6qtJN94G3Vw1LFFPiBWqDm5zSM00ZRUSdCKvi00687JtwMk";

        var options = new PaymentIntentCreateOptions 
        { 
            Amount = 6969, 
            Currency = "cad",
            AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions() { Enabled = true },
            Customer = userService.Customer.Id,
        };
        var service = new PaymentIntentService();
        PaymentIntent pi = service.Create(options);

        PaymentIntentDTO dto = new PaymentIntentDTO();
        dto.ClientSecret = pi.ClientSecret;
        dto.Customer = pi.CustomerId;
        
        


        /* paymentIntentClientSecret: data['client_secret'],
          // Customer keys
          customerEphemeralKeySecret: data['ephemeralKey'],
          customerId: data['customer'], */

        return Ok(dto);
    }
    
    
    [HttpGet]
    public ActionResult CreateCustomer()
    {
        Customer c = userService.CreateCustomer();

        return Ok(c);
    }
}