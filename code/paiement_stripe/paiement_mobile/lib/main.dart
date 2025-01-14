import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:flutter_dotenv/flutter_dotenv.dart';
import 'package:flutter_stripe/flutter_stripe.dart';

const PK = "PUBLIC_KEY";

void main() async {

  WidgetsFlutterBinding.ensureInitialized();

  // Charger les variables d'environnement du fichier .env
  await dotenv.load(fileName: ".env");
  
  // Assigner la clé publique (Publishable Key) de Stripe
  Stripe.publishableKey = dotenv.env[PK]!;
  
  // Assigner un identifiant de marchant, ceci est nécessaire pour les paiement iOS entre autre
  Stripe.merchantIdentifier = 'info.cegepmontpetit.ca';
  
  // On applique les configurations
  await Stripe.instance.applySettings();

  runApp(const MyApp());
}



class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.deepPurple),
        useMaterial3: true,
      ),
      home: const MyHomePage(title: 'Super Flutter_Stripe Demo Infini'),
    );
  }
}

class MyHomePage extends StatefulWidget {
  const MyHomePage({super.key, required this.title});
  final String title;

  @override
  State<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  bool completed = false;

  Future<Map<String, dynamic>> getPaymentIntent() async {
    var response  = await Dio().get('http://10.0.2.2:5194/api/Stripe/CreatePaymentIntent');

    return response.data;
  }

  Future<void> initPaymentSheet(data) async {
    try {
      
      // Créer la Feuille de paiement avec les bonnes options
     await Stripe.instance.initPaymentSheet(
        paymentSheetParameters: SetupPaymentSheetParameters(
          // On veut utiliser le processus de paiement par défaut
          customFlow: false,
          merchantDisplayName: 'Super Flutter_Stripe Demo Infini',
          // Le client_secret permet d'identifier l'intention de paiement
          paymentIntentClientSecret: data['client_secret'],
          // On ajoute le ID du client (si nous utilisons un client, ce n'est pas obligatoire)
          customerId: data['customer'],
          // On ajoute Google Pay et Apple Pay
          applePay: const PaymentSheetApplePay(
            merchantCountryCode: 'CA',
          ),
          googlePay: const PaymentSheetGooglePay(
            merchantCountryCode: 'CA',
            testEnv: true,
          ),
          style: ThemeMode.dark,
        ),
      );
      setState(() {

      });
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(content: Text('Error: $e')),
      );
      rethrow;
    }
  }

  buyStuff() async {
    
    // On récupère l'intention de paiement du serveur
    var data = await getPaymentIntent(); 

    // On initialise la feuille de paiement
    await initPaymentSheet(data);

    try {
      // On affiche la feuille de paiement
      await Stripe.instance.presentPaymentSheet();
    } catch(e) {
      print(e);
    }

    setState(() {
      completed = true;
    });

  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Theme.of(context).colorScheme.inversePrimary,
        title: Text(widget.title),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            buildText(context),
          ],
        ),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: buyStuff,
        tooltip: 'Checkout',
        child: const Icon(Icons.shopping_cart_checkout),
      ),
    );
  }

  Widget buildText(BuildContext context) {
    if(completed) {
      return Row(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Text(
            'Paiement complété!',
            style: Theme.of(context).textTheme.headlineMedium,
          ),
          const Padding(
            padding: EdgeInsets.all(8.0),
            child: Icon(Icons.thumb_up_off_alt_sharp),
          ),
        ]
      );
    }
    return Text(
            'Effectuer le paiement',
            style: Theme.of(context).textTheme.headlineMedium,
          );
  }
}


