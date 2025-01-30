# Introduction aux IIFE (Immediately Invoked Function Expression) en JavaScript Pour Razor

## Qu'est-ce qu'une IIFE ?
Une **IIFE** (*Immediately Invoked Function Expression*) est une fonction anonyme en JavaScript qui s'exécute immédiatement après sa définition. Elle est utilisée pour encapsuler du code et éviter la pollution de l’espace de noms global.

### Syntaxe d'une IIFE
```javascript
(function () {
    // Code exécuté immédiatement
})();
```

Elle est utile pour :
- Empêcher les conflits de variables globales.
- Créer des modules auto-contenus.
- Organiser le code en modules indépendants.

---

# Exemple d'utilisation des IIFE dans une application MVC .NET
Dans une architecture **MVC .NET**, chaque modèle peut avoir son propre fichier JavaScript structuré en IIFE, et un fichier global `site.js` qui contient les fonctions générales de l'application.

## 1. **Fichier site.js** (Méthodes générales)
Le fichier `site.js` contiendra des fonctions utilitaires générales accessibles à toute l'application.

```javascript
var Site = (function () {
    var _args = {};

    return {
        init: function (Args) { _args = Args; },

        eventHandler: function () {
            console.log("Gestion des événements généraux");
        },

        formatDate: function (date) {
            return new Date(date).toLocaleDateString();
        }
    };
})();

// Initialisation de l'objet global
Site.init({});
```

---

## 2. **Explication et exemple de la fonction init()**
La fonction `init()` permet d'initialiser le module avec des paramètres spécifiques. Elle est utilisée pour stocker des configurations, des options ou des dépendances qui seront utilisées par le module.

### **Accès aux variables dans `_args`**
Les variables stockées dans `_args` sont accessibles depuis n'importe quelle fonction du module.

Exemple :

```javascript
var UserController = (function () {
    var _args = {};

    return {
        init: function (Args) {
            _args = Args;
            console.log("Initialisation du module User avec :", _args);
        },

        getSaveUrl: function () {
            return _args.saveUrl || "URL par défaut";
        },

        eventHandler: function () {
            document.getElementById("btnSave").addEventListener("click", function () {
                UserController.saveUser();
            });
        },

        saveUser: function () {
            console.log("Sauvegarde de l'utilisateur avec l'URL:", UserController.getSaveUrl());
        }
    };
})();

// Initialisation du module avec des options spécifiques
UserController.init({ saveUrl: "/api/user/save", debug: true });
UserController.eventHandler();
```

Dans cet exemple, la méthode `getSaveUrl()` récupère la valeur de `_args.saveUrl`. Si la valeur n'est pas définie, elle retourne une valeur par défaut.

---

## 3. **Exemple d'un modèle en MVC .NET avec une IIFE**
Supposons que nous avons un modèle `User` en MVC .NET. Nous allons créer un fichier `user.js` qui gère les interactions utilisateur avec une IIFE.

### **Fichier user.js** (Gestion des utilisateurs)
```javascript
var UserController = (function () {
    var _args = {};

    return {
        init: function (Args) { _args = Args; },

        eventHandler: function () {
            document.getElementById("btnSave").addEventListener("click", function () {
                UserController.saveUser();
            });
        },

        saveUser: function () {
            console.log("Sauvegarde de l'utilisateur...");
        }
    };
})();

// Initialisation du module User
UserController.init({});
UserController.eventHandler();
```

---

## 4. **Exemple d'un autre modèle : Produits**
Nous avons maintenant un modèle `Product` avec un fichier `product.js` qui gère les produits de l'application.

### **Fichier product.js** (Gestion des produits)
```javascript
var ProductController = (function () {
    var _args = {};

    return {
        init: function (Args) { _args = Args; },

        eventHandler: function () {
            document.getElementById("btnAddProduct").addEventListener("click", function () {
                ProductController.addProduct();
            });
        },

        addProduct: function () {
            console.log("Ajout d'un produit...");
        }
    };
})();

// Initialisation du module Product
ProductController.init({});
ProductController.eventHandler();
```

---

## 5. **Initialisation du JavaScript dans les vues avec RenderScript**
Dans une application MVC .NET, il est important de charger et d'exécuter les scripts spécifiques à chaque page. Pour cela, nous pouvons utiliser `@section Scripts` avec `RenderSection` dans le layout principal.

### **Ajout dans `_Layout.cshtml`**
```html
<!DOCTYPE html>
<html>
<head>
    <title>Mon Application MVC</title>
    <script src="~/js/site.js"></script>
</head>
<body>
    <div class="container">
        @RenderBody()
    </div>
    @RenderSection("Scripts", required: false)
</body>
</html>
```

### **Ajout dans une vue spécifique (ex: `Index.cshtml`)**
```html
@section Scripts {
    <script src="~/js/user.js"></script>
    <script>
        $(document).ready(function() {
            UserController.init({ saveUrl: "/api/user/save", debug: true });
            UserController.eventHandler();
        });
    </script>
}
```

Ce code permet de s'assurer que les scripts sont bien chargés et exécutés uniquement dans les vues concernées, évitant ainsi un chargement global inutile.

---

# Conclusion
- **Chaque modèle MVC .NET a son propre fichier JavaScript encapsulé dans une IIFE.**
- **Le fichier `site.js` contient les méthodes générales de l’application.**
- **Les événements sont centralisés dans la méthode `eventHandler()` de chaque module.**
- **Les scripts spécifiques à chaque vue sont initialisés via `@section Scripts`.**
- **La fonction `init()` permet de configurer chaque module avec des paramètres dynamiques.**
- **Les valeurs stockées dans `_args` sont accessibles à travers des méthodes dédiées.**
- **Cette approche améliore la modularité, la maintenabilité et la lisibilité du code.**

En suivant cette organisation, nous évitons les conflits globaux et facilitons la gestion des événements dans notre application MVC .NET.

