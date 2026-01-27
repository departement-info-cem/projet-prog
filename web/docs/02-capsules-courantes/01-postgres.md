# Base de données Postgres

Ce n'est pas toujours facile de trouver un hébergement gratuit pour un serveur de BD SQL et pour le projet on a décidé d'utiliser une BD Postgres. En plus, ça vous permet d'apprendre quelque chose! Ça reste du SQL, donc ce que vous avez appris en cours fonctionne toujours, mais chaque technologie à ses propres fonctionnalités, subtilités et ses propres outils.

Voici donc comment faire la configuration dans votre projet:

- Ajouter la librairie pour entity avec Postgres
- Tant qu'à jouer dans les librairies, on ajoute tout de suite celle pour le support de la géo localisation

![alt text](image-2.png)

Dans Program.cs, il faut indiquer qu'on utilise Postgres, de la même façon que normalement ont indiquait sql server. On veut donc **remplacer** l'ancien code par celui-ci. Encore une fois, on en profite pour activer le support des données de géo localisation.

![alt text](image-3.png)

Il reste seulement à mettre à jour votre string pour la connexion avec le nom de votre BD.
Le mot de passe est vraiment Passw0rd et le username postgres.

![alt text](image-4.png)

Une fois que c'est fait, add-migration et update-database vont fonctionner de la même façon.

:::warning
Si vous voulez effacer votre BD (ou faire des Select ou autres opérations de BD), vous ne pouvez pas utiliser SQL Server Management Studio ou l'explorateur d'objects SQL Server intégré dans Visual Studio.
:::

:::danger
Si vous changez de technologie de BD (par exemple de MS SQL SERVER vers Postgres) et que vous avez déjà des migrations, il faut les effacer et les refaire toutes! Pourquoi? Ces fichiers contiennent des commandes spécifiques à la technologie de BD qui sont suffisament différentes pour que ça ne soit pas compatible.
:::

Pour gérer vos BDs Postgres, il y a un outil de ligne de commande déjà installé sur vos postes:

![alt text](image-6.png)

Voici comment on se connecte à la BD et que l'on efface une BD avec cet outil.

![alt text](image-5.png)

:::warning
Au moment de taper le mot de passe, rien ne s'affiche pendant que vous tapez, mais ça fonctionne quand même!
:::

:::danger
C'est normal de se connecter à la BD **postgres** dans ce cas, on ne **peut pas** effacer la BD sur laquelle on est présentement connecté!
:::