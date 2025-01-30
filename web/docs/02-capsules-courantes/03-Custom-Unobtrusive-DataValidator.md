# Validation Personnalisée C# et jQuery Unobtrusive

Ce code met en place un **Data Validator personnalisé** permettant de valider un mot de passe selon des critères spécifiques **à la fois côté serveur et côté client**. Cette approche assure une validation robuste et empêche la soumission de données non conformes. Ce cas est un exemple simple de validation de mot de passe. Bien entendu il est possible de faire toute sorte de validation. 

L'intégration avec **jQuery Validation Unobtrusive** permet d'ajouter automatiquement la validation côté client en fonction des attributs définis dans le modèle, sans nécessiter d'écriture de code JavaScript supplémentaire.

---

## 1. Validation côté serveur avec une Annotation Personnalisée

L'objectif est de créer une **annotation C#** qui valide le mot de passe directement au niveau du **back-end** et génère automatiquement la validation **côté client** grâce aux attributs HTML générés.

### Définition de l'annotation `CustomPasswordAttribute`

```csharp
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CustomUnobtrusiveDataValidator.Validator
{
    public class CustomPasswordAttribute : ValidationAttribute, IClientModelValidator
    {
        public override bool IsValid(object value)
        {
            var password = value as string;
            if (password == null) return false;

            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasLowerCase = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);

            return hasUpperCase && hasLowerCase && hasDigit;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-custompassword", ErrorMessage ?? "Le mot de passe doit contenir au moins une lettre majuscule, une lettre minuscule et un chiffre.");
        }
    }
}
```

### Explication :
- **`IsValid(object value)`** : 
  - Vérifie si la valeur fournie est une chaîne de caractères.
  - Vérifie qu’elle contient **au moins une majuscule, une minuscule et un chiffre**.
  - Retourne `true` si ces critères sont remplis, sinon `false`.

- **`AddValidation(ClientModelValidationContext context)`** :
  - Ajoute **automatiquement** un attribut HTML `data-val-custompassword` pour déclencher la validation côté client avec **jQuery Validation Unobtrusive**.
  - L’attribut généré contiendra le **message d’erreur** correspondant.

---

## 2. Utilisation de la validation dans un Modèle `Utilisateur`

Une fois l'annotation créée, il suffit de l'appliquer à une propriété de modèle pour qu'elle fonctionne automatiquement.

```csharp
using CustomUnobtrusiveDataValidator.Validator;
using System.ComponentModel.DataAnnotations;

namespace CustomUnobtrusiveDataValidator.Models
{
    public class Utilisateur
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string Name { get; set; }

        [Required(ErrorMessage = "L'adresse e-mail est obligatoire")]
        [EmailAddress(ErrorMessage = "Format de l'adresse e-mail invalide")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        [CustomPassword(ErrorMessage = "Le mot de passe doit contenir au moins une lettre majuscule, une lettre minuscule et un chiffre")]
        public string Password { get; set; }
    }
}
```

### Pourquoi cette approche est utile ?
- **Validation automatique** : Dès qu'un mot de passe est saisi dans un formulaire, la validation est déclenchée.
- **Uniformité** : Les mêmes règles sont appliquées côté **client** et **serveur**.
- **Facilité de maintenance** : Si on modifie la validation dans `CustomPasswordAttribute`, cela est répercuté partout.

---

## 3. Validation côté client avec jQuery Validation Unobtrusive

### Qu'est-ce que **jQuery Validation Unobtrusive** ?
C'est une **extension de jQuery Validation** qui permet de **générer automatiquement** la validation côté client en fonction des **attributs HTML générés** par ASP.NET.

👉 **Avantage** : Plus besoin d'écrire du code JavaScript manuel pour gérer la validation.

---

### Ajout d'un adaptateur de validation pour jQuery

```js
$.validator.unobtrusive.adapters.add("custompassword", [], function (options) {
    options.rules['custompassword'] = true;
    options.messages['custompassword'] = options.message;
});
```

- **Ajoute une nouvelle règle de validation (`custompassword`) à jQuery Validation**.
- **Le message d'erreur est défini dynamiquement** en fonction de l’attribut HTML généré (`data-val-custompassword`).

### Définition de la méthode de validation

```js
$.validator.addMethod("custompassword", function (value, element) {
    if (!value) {
        return false; // Ne pas valider si le champ est vide
    }

    let hasUpperCase = /[A-Z]/.test(value);
    let hasLowerCase = /[a-z]/.test(value);
    let hasDigit = /[0-9]/.test(value);

    return hasUpperCase && hasLowerCase && hasDigit;
});
```

- Cette fonction **valide le champ** en s’assurant que :
  - Il contient **au moins une majuscule** (`/[A-Z]/`)
  - Il contient **au moins une minuscule** (`/[a-z]/`)
  - Il contient **au moins un chiffre** (`/[0-9]/`)

- Si toutes ces conditions sont respectées, **le champ est validé**, sinon un message d'erreur est affiché.

---

## 4. Inclusion des scripts pour la validation côté client

Pour que la validation côté client fonctionne, il faut inclure le script suivants :

```html
<script src="~/js/validator.js"></script>
```

dans **_ValidationScriptsPartial.cshtml** et le charger dans la vue qui l'utilisera

```csharp
@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}
```

Dans _ValidationScriptsPartial.cshtml nous devrions retrouver 3 référence .js 

- `jquery.validate.min.js` : Bibliothèque de validation de jQuery.
- `jquery.validate.unobtrusive.min.js` : Ajoute la gestion **automatique** des règles de validation en fonction des attributs HTML.
- `validator.js` : Contient notre validation personnalisée `custompassword`.

---

## 5. Résumé et Avantages de cette Méthode

✅ **Validation unifiée** :
- Un seul `CustomPasswordAttribute` assure la validation **côté serveur** et **côté client**.

✅ **Facilité d'utilisation** :
- Une simple annotation `[CustomPassword]` dans le modèle `Utilisateur` suffit.

✅ **Meilleure expérience utilisateur** :
- L'erreur s'affiche **instantanément** côté client grâce à **jQuery Validation Unobtrusive**.
- Si JavaScript est désactivé, la validation est toujours assurée **côté serveur**.

✅ **Code réutilisable et centralisé** :
- Si on doit changer la règle de validation, **il suffit de modifier `CustomPasswordAttribute`**, et cela sera appliqué **partout**.

---

## Conclusion

Ce code met en place une **validation de mot de passe robuste et intégrée**. Grâce à l’utilisation conjointe de **jQuery Validation Unobtrusive** et de **C# DataAnnotations**, on assure une validation **efficace**, **automatique** et **facile à maintenir**. 🚀
