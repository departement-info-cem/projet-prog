# Préparation technique du projet

La préparation technique sert entre autre à mettre en place votre projet. Tout ce qui ne se retrouve pas dans les Sprints de développement doit se retrouver ici.

Pensez donc à tout ce qui n'a pas de valeur inhérente pour le client qui doit être fait pour permettre au projet de fonctionner.

Pendant la préparation du projet, vous allez:
- faire une planification de sprint
  - on veut un écran web qui prend un champ texte, quand on envoie le texte avec le bouton, l'application va au serveur et répond "bonjour " suivi du texte envoyé
  - on veut une application mobile qui effectue la même action
  - on veut le serveur et l'API nécessaire pour que cela fonctionne
- on fera des petites mêlées aux demi-journées pour voir où on en est
- on fera une revue de sprint à la fin pour voir si on a réussi à faire ce qu'on voulait
  - le coach d'équipe va jouer le rôle de PO pour cette revue
  - si le travail rencontre votre définition de terminé, c'est gagné sinon on continue

Chaque cérémonie est une version miniature de la vraie cérémonie. Toutefois cela vous permet
de se remémorer les étapes sur une fonctionnalité qui ne compte pas.

## Architecture

- Choisir une architecture parmi les suivantes :

TODO : Faire des diagrammes des différents architectures proposées

- Valider l'architecture de votre application avec le coach d'équipe et / ou les coach technique.

## Git

- Un Github a été créé par l'équipe d'enseignants. Demandez leur de vous y ajouter et de vous expliquer comment le rejoindre.
- Assurez vous que tous les membres de l'équipe ont accès à tous les repos
- Assurez vous que tous les coach techniques ainsi que votre coach d'équipe ont accès à tous les repos

## Backend

- Application .NET créée avec projets MVC, WebAPI, et Models.
:::danger ⚠️ ‼️ ☢️
Assurez vous de créer une seule application .NET avec tous projets (MVC, WebAPI, Models). **Ne faites pas 3 applications séparées**!!!
:::
- Application ajoutée dans le repo GitHub.
  - **.gitignore créé** : Aucun fichier compilé dans le repo.
:::danger ⚠️ ‼️ ☢️
``` bash
dotnet new gitignore
```
:::
- Le repo doit avoir :
  - Une branche pour le développement (dev par exemple)
  - Une branche pour les releases (main par exemple)
  - La base de données doit être en Postgresql
- Authentification (login / register) à l'aide d'Identity fonctionnel en MVC et en WebAPI.
- Swagger fonctionne les tokens d'authentification.
- Une action WebAPI ayant les spécifications suivantes :
  - `GET /api/TestController/monSuperTest`.
  - Prend en paramètre une chaîne de caractères.
  - Retourne la chaîne de caractères donnée en paramètre inversée en json : `{ "text": "dlroW olleH" }`.
  - Renvoie une erreur si la chaîne de caractères est vide
- Projet déployé sur Azure avec CD/CI sur la branche de release du repo

## Frontend (Angular et Flutter)

- Applications créée
- Applicationa ajoutée dans le repo GitHub.
- `.gitignore` crééa : aucun fichier compilé dans le repo.
- Les repos doivent avoir :
  - Une branche pour le développement (dev par exemple)
  - Une branche pour les releases (main par exemple)
- Page de connection / création de compte
- Page où on voit un champ de saisie de texte et un bouton
  - Route protégé à l'aide d'un guard. (Angular seulement)
  - À l'appuie sur le bouton, on récupère le contenu du champ texte et on l'envoie à l'appel d'API créé à l'étape sur le backend.
  - On affiche le résultat de l'appel dans un champ texte.
- Projet déployé sur Azure (ou Firebase) avec CD/CI sur la branche de release du repo. (Web seulement)
- Traductions Anglais / Français complétées
- Gestion d'erreur multilingue
