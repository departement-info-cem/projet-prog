# Paiement avec Stripe


<Row>

<Column>

:::info Capsule

Dans cette capsule, il nous verrons comment créer un module de paiement en utilisant l'API de Stripe.

Nous aurons 3 grandes étapes de réalisation.

**Créer un compte Stripe**

Ici, nous voudrons créer le compte, mais pas au complet pour ne pas avoir à donner un compte bancaire.

Si la création cu compte n'est pas complété, nous pourrons tout utiliser Stripe, mais nous devrons rester en mode test.

**Créer le module de paiement pour le serveur**

Le serveur sera utiliser pour créer l'intention de paiement et un client Stripe au besoin.

L'intention de paiement inclue entre autre les éléement suivent:
- Le montant à payer
- La devise utilisée
- Le client qui sera facturé
- Les moyens de paiement possible

**Créer le module de paiement pour le client**

Au niveau client, nous utiliserons l'intention de paiement créé par le serveur pour pour générer la fenêtre de paiement.

:::

</Column>

</Row>

Mis à jour en janvier 2025

## Exemple de code

Vous pouvez regarder l'exemple de code **[paiement_stripe](https://github.com/departement-info-cem/projet-prog/tree/main/code/paiement)**.

## Compte Stripe

### Créer le compte

### Récupérer les clés publique et privée

### Créer un Sandbox et configurer le compte

- dans un navigateur ouvrir https://supabase.com/
- si nécessaire, se créer un compte
- se connecter



## Supabase, création du projet

- suivre les captures d'écran

<Row>
  <Column size="8">
    ![Creer le projet](_27-supabase/create2.png)
  </Column>
  <Column size="8">
    ![Creer le projet](_27-supabase/create3.png)
  </Column>
  <Column size="8">
    ![Creer le projet](_27-supabase/create4.png)
  </Column>
  <Column size="8">
    ![Creer le projet](_27-supabase/create5.png)
  </Column>
  <Column size="8">
    ![Creer le projet](_27-supabase/create6.png)
  </Column>
</Row>

## Supabase, configurer les droits d'accès

- suivre les captures d'écran

#### Ajouter les droits pour les buckets 

<Row>

  <Column size="8">
    ![Creer le projet](_27-supabase/storage1.png)
  </Column>
  <Column size="8">
    ![Creer le projet](_27-supabase/storage2.png)
  </Column>
  <Column size="8">
    ![Creer le projet](_27-supabase/storage3.png)
  </Column>
  <Column size="8">
    ![Creer le projet](_27-supabase/storage4.png)
  </Column>
  <Column size="8">
    ![Creer le projet](_27-supabase/storage5.png)
  </Column>
  <Column size="8">
    ![Creer le projet](_27-supabase/storage6.png)
  </Column>
  
</Row>

#### Ajouter les droits pour les objets (images) dans les buckets

<Row>

  <Column size="8">
    ![Creer le projet](_27-supabase/objects1.png)
  </Column>
  <Column size="8">
    ![Creer le projet](_27-supabase/objects2.png)
  </Column>
  <Column size="8">
    ![Creer le projet](_27-supabase/objects3.png)
  </Column>
  
</Row>

## Supabase, créer un bucket public

Vous pouvez créer votre bucket de 2 façons
- avec du code
- avec l'interface de Supabase

#### Créer le bucket par le code

```dart
final supabase = Supabase.instance.client;

await supabase
        .storage
        .createBucket('le-nom-de-mon-bucket', BucketOptions(public: true));
```

#### Créer le bucket par l'interface

<Row>

  <Column size="8">
    ![Creer le projet](_27-supabase/bucket1.png)
  </Column>
  <Column size="8">
    ![Creer le projet](_27-supabase/bucket2.png)
  </Column>
  
</Row>


## Ajouter une image

```dart
final supabase = Supabase.instance.client;

//TODO doc: https://supabase.com/docs/reference/dart/storage-from-upload
final String fullPath = await supabase
  .storage
  .from('le-nom-de-mon-bucket')
  .upload(
    //TODO Mettre un nom unique
    "nom-du-fichier",
    File("path-du-fichier")
  );
```

## Récupérer une image

```dart
final supabase = Supabase.instance.client;

//TODO doc: https://supabase.com/docs/reference/dart/storage-from-getpublicurl
string url = supabase
  .storage
  .from('le-nom-de-mon-bucket')
  // TODO le bucket doit être public pour qu'on puisse récupérer l'URL public
  .getPublicUrl("nom-du-fichier");
```

## Exemple de code

Vous pouvez regarder l'exemple de code **[supabase_storage](https://github.com/departement-info-cem/5N6-mobile-2/tree/main/code/supabase_storage)**.