using System.Xml;
using LapinCouvertAPI.Service;
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
        // Cr�er un client au besoin (utiliser les clients est facultatif, �a permet de suivre plus facilement les paiements sur le dashboard de Stripe)
        Customer customer = userService.CreateCustomer();


        // Ajouter la cl� secr�te de Stripe ici
        StripeConfiguration.ApiKey = "sk_test_blablabla_votre_API_KEY_secrete";

        // On choisi les options de notre paiement
        var options = new PaymentIntentCreateOptions 
        { 
            Amount = 6969, 
            Currency = "cad",
            AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions() { Enabled = true },
            Customer = customer.Id,
        };

        // On cr�e l'intention de paiement � partir de nos options
        var service = new PaymentIntentService();
        PaymentIntent pi = service.Create(options);

        // Une fois l'intention de paiement cr��e, on envoie les informations importantes au client
        PaymentIntentDTO dto = new PaymentIntentDTO();
        dto.ClientSecret = pi.ClientSecret;
        dto.Customer = pi.CustomerId;

        return Ok(dto);
    }
}