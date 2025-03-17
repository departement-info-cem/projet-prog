# Évaluation du code côté client

- Évaluation individuelle
- La correction est faite par le coach client si c'est du web ou par le coach mobile si c'est mobile
- Pendant les sprints 1 2 3, il faut que tu t'assures de prendre une fonctionnalité client
- Tu peux vérifier avec le coach programmation client si c'est assez gros / complexe / suffisant

## Évaluation formative

- Quoi? le prof remplit la [grille](_09-grilles/Grille-Code-Client.xlsx) de correction et te revient avec des commentaires
- Quand? dès que tu as complété une fonctionnalité client, tu peux demander la correction formative
- Combien? le prof te donne une note globale sur 10. Tu peux avoir tout qui fonctionne mais une énorme faille de sécurité tu pourrais avoir en dessous de 60% quand même.

Si ta note de formatif te convient et que tu ne penses pas reprendre ton code, la note deviendra finale.

## Évaluation sommative

- Quoi? la même fonctionnalité qu'au sommatif avec la même [grille](_09-grilles/Grille-Code-Client.xlsx)
- Quand? quand tu as complété les modifications demandées au formatif, idéalement avant le jour des présentations
finales. ABSOLUMENT avant de dernier jour de stage.
- Combien? En général plus haut que ton formatif. La cible c'est 100% et du code digne d'un professionnel.

## Grille d'évaluation


| **Correction Client**                                                        |                    |
| ---------------------------------------------------------------------------- | ------------------ |
| Fonctionnalité choisie: ____________________________________________         |  **Commentaires**  |
| **Découplage vue code**                                                      |                    |
| Le code logique n'est pas mélangé avec le code de l'interface                |                    |
| Les éléments visuels sont réutilisés                                         |                    |
| **Structure du projet client**                                               |                    |
| Appels HTTP regroupés (service)                                              |                    |
| Structure et noms homogènes et standards                                     |                    |
| Réutilisation du code (pas de copié-collé)                                   |                    |
| Lisibilité du code (1 fonction < 1 page, etc.)                               |                    |
| **Stabilité**                                                                |                    |
| Crash application                                                            |                    |
| Validation des données                                                       |                    |
| Ne pas multiplier inutilement les requêtes HTTP                              |                    |
| Données du client toujours à jour avec les données de la BD                  |                    |
| **Sécurité**                                                                 |                    |
| Gestion des tokens (ou cookies)                                              |                    |
| Utilisation des APIs externes (Firebase/ Supabase/ etc.)                     |                    |
| Autre                                                                        |                    |
| **Interface utilisateur**                                                    |                    |
| Utilisation de la nomenclature du glossaire                                  |                    |
| Messages d'erreur (indique clairement une solution à l'utilisateur)          |                    |
| Indicateurs d'attente                                                        |                    |
| Traductions anglais et français (champs de la page / messages d'erreur)      |                    |
| **Total**                                                                    | /10                |