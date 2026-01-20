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

<style>
  @media print {
    /* Cache les éléments de navigation de Docusaurus à l'impression */
    nav, footer, .navbar, .pagination-nav, .theme-doc-sidebar-container {
      display: none !important;
    }
    /* Force le conteneur principal à prendre toute la largeur */
    .main-wrapper, main, div[class^="docItemContainer"] {
      width: 100% !important;
      max-width: 100% !important;
      margin: 0 !important;
      padding: 0 !important;
    }
    /* Enlève les ombres et bordures inutiles à l'impression */
    .table-wrapper { box-shadow: none !important; }
    body { font-size: 12pt; }
  }

  /* Style du tableau pour l'affichage écran */
  .grading-table {
    width: 100%;
    border-collapse: collapse;
  }
  .grading-table th, .grading-table td {
    border: 1px solid var(--ifm-table-border-color); /* Utilise la couleur de bordure du thème */
    padding: 8px;
    vertical-align: top;
  }
  /* Force la hauteur des lignes vides pour l'écriture manuscrite */
  .comment-cell {
    height: 40px; 
  }
</style>

<table class="grading-table">
  <colgroup>
    <col style="width: 40%;" /> 
    <col style="width: 60%;" />
  </colgroup>
  <thead>
    <tr>
      <th><strong>Correction Client</strong></th>
      <th></th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td colspan="2"><strong>Fonctionnalité choisie :</strong> __________________________________________________</td>
    </tr>
    <tr>
      <td style="background-color: var(--ifm-table-stripe-background); text-align:center;"><strong>Découplage vue code</strong></td>
      <td style="background-color: var(--ifm-table-stripe-background);"><strong>Commentaires</strong></td>
    </tr>
    <tr>
      <td>Le code logique n'est pas mélangé avec le code de l'interface</td>
      <td class="comment-cell"></td>
    </tr>
    <tr>
      <td>Les éléments visuels sont réutilisés</td>
      <td class="comment-cell"></td>
    </tr>
    <tr>
      <td style="background-color: var(--ifm-table-stripe-background); text-align:center;"><strong>Structure du projet client</strong></td>
      <td style="background-color: var(--ifm-table-stripe-background);"></td>
    </tr>
    <tr>
      <td>Appels HTTP regroupés (service)</td>
      <td class="comment-cell"></td>
    </tr>
    <tr>
      <td>Structure et noms homogènes et standards</td>
      <td class="comment-cell"></td>
    </tr>
    <tr>
      <td>Réutilisation du code (pas de copié-collé)</td>
      <td class="comment-cell"></td>
    </tr>
    <tr>
      <td>Lisibilité du code (1 fonction < 1 page, etc.)</td>
      <td class="comment-cell"></td>
    </tr>
    <tr>
      <td style="background-color: var(--ifm-table-stripe-background); text-align:center;"><strong>Stabilité</strong></td>
      <td style="background-color: var(--ifm-table-stripe-background);"></td>
    </tr>
    <tr>
      <td>Crash application</td>
      <td class="comment-cell"></td>
    </tr>
    <tr>
      <td>Validation des données</td>
      <td class="comment-cell"></td>
    </tr>
    <tr>
      <td>Ne pas multiplier inutilement les requêtes HTTP</td>
      <td class="comment-cell"></td>
    </tr>
    <tr>
      <td>Données du client toujours à jour avec les données de la BD</td>
      <td class="comment-cell"></td>
    </tr>
    <tr>
      <td style="background-color: var(--ifm-table-stripe-background); text-align:center;"><strong>Sécurité</strong></td>
      <td style="background-color: var(--ifm-table-stripe-background);"></td>
    </tr>
    <tr>
      <td>Gestion des tokens (ou cookies)</td>
      <td class="comment-cell"></td>
    </tr>
    <tr>
      <td>Utilisation des APIs externes (Firebase/Supabase/etc.)</td>
      <td class="comment-cell"></td>
    </tr>
    <tr>
      <td>Autre</td>
      <td class="comment-cell"></td>
    </tr>
    <tr>
      <td style="background-color: var(--ifm-table-stripe-background); text-align:center;"><strong>Interface utilisateur</strong></td>
      <td style="background-color: var(--ifm-table-stripe-background);"></td>
    </tr>
    <tr>
      <td>Utilisation de la nomenclature du glossaire</td>
      <td class="comment-cell"></td>
    </tr>
    <tr>
      <td>Messages d'erreur (indique clairement une solution)</td>
      <td class="comment-cell"></td>
    </tr>
    <tr>
      <td>Indicateurs d'attente</td>
      <td class="comment-cell"></td>
    </tr>
    <tr>
      <td>Traductions anglais et français (champs/messages)</td>
      <td class="comment-cell"></td>
    </tr>
    <tr>
      <td style="text-align: right;"><strong>Total</strong></td>
      <td><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; / 10</strong></td>
    </tr>
  </tbody>
</table>

| **Correction Client**                                                        |                    |
| ---------------------------------------------------------------------------- | ------------------ |
| Fonctionnalité choisie: ____________________________________________         |  **Commentaires**  |
| <center>**Découplage vue code**</center>                                     |                    |
| Le code logique n'est pas mélangé avec le code de l'interface                |                    |
| Les éléments visuels sont réutilisés                                         |                    |
| <center>**Structure du projet client**</center>                              |                    |
| Appels HTTP regroupés (service)                                              |                    |
| Structure et noms homogènes et standards                                     |                    |
| Réutilisation du code (pas de copié-collé)                                   |                    |
| Lisibilité du code (1 fonction < 1 page, etc.)                               |                    |
| <center>**Stabilité**</center>                                               |                    |
| Crash application                                                            |                    |
| Validation des données                                                       |                    |
| Ne pas multiplier inutilement les requêtes HTTP                              |                    |
| Données du client toujours à jour avec les données de la BD                  |                    |
| <center>**Sécurité**</center>                                                |                    |
| Gestion des tokens (ou cookies)                                              |                    |
| Utilisation des APIs externes (Firebase/ Supabase/ etc.)                     |                    |
| Autre                                                                        |                    |
| <center>**Interface utilisateur**</center>                                   |                    |
| Utilisation de la nomenclature du glossaire                                  |                    |
| Messages d'erreur (indique clairement une solution à l'utilisateur)          |                    |
| Indicateurs d'attente                                                        |                    |
| Traductions anglais et français (champs de la page / messages d'erreur)      |                    |
| <center>**Total**</center>                                                   | /10                |
