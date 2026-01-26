# Planification initiale

## 1. Processus
### Processus Agile Scrum du projet

Le projet suit la méthodologie Agile SCRUM.

**Les 4 Valeurs du manifeste Agile :**
1.  **Les individus et leurs interactions** plus que les processus et les outils.
2.  **Du logiciel qui fonctionne** plus qu'une documentation exhaustive.
3.  **La collaboration avec les clients** plus que la négociation contractuelle.
4.  **L'adaptation au changement** plus que le suivi d'un plan.

**Application dans le cours :**
* Suivre les processus Agile Scrum.
* Vous impliquer dans les rencontres.
* Ne pas perdre de vue l'objectif des rencontres, des itérations, du projet !
* Itération (Sprint) d'une durée d'une semaine (Sprint 0 à 5).

### Le Cycle Scrum (Résumé)
* **Préparation du projet :** Document de Vision, Backlog produit initial, Architecture.
* **Sprint 1 à 5 :**
    * **Grooming :** Lundi (20 min / 2 analystes / équipe).
    * **Planification de sprint :** Mardi-Mercredi.
    * **Mêlée quotidienne (Daily) :** Chaque jour à heure fixe.
    * **Exécution du Sprint.**
    * **Revue de sprint :** Mardi-Mercredi (itération de la semaine passée).
    * **Rétrospective de sprint :** À faire entre vous (Inspect & Adapt).
    * **Livraison :** Nécessaire 3 heures avant la revue, même si l'itération n'est pas complétée à 100%.

### Rôles Agile dans votre équipe
À chaque sprint (1 à 5), vous devrez choisir un membre différent de votre équipe qui prendra les rôles suivants (tout en restant développeur à temps plein) :
* Scrum Master
* Analyste d'affaire
* Assurance Qualité (QA)

> **Note :** Vous devrez vous partager également les présentations (Revue, Release, etc.).

---

## 2. Le manifeste des Tests

Nous valorisons :
* **Tester au fil de l'eau** PLUS QUE Tester à la fin.
* **Éviter les bugs** PLUS QUE Trouver les bugs.
* **Tester la bonne compréhension** PLUS QUE Vérifier la fonctionnalité.
* **Construire le meilleur système** PLUS QUE Casser le système.
* **La responsabilité de l'équipe sur la qualité** PLUS QUE La responsabilité du testeur.

> *Pensez également aux jeux de données !*

### La Dette Technique
Il faut éviter la dette technique pour garder une bonne vélocité ("Bien faire dès le début").

**Types de dette :**
* **Irréfléchie / Intentionnelle :** "Nous n'avons pas le temps pour la conception".
* **Prudente / Intentionnelle :** "Nous devons déployer maintenant et assumer les conséquences".
* **Irréfléchie / Involontaire :** "Qu'est-ce que la structuration en couches ?".
* **Prudente / Involontaire :** "Maintenant nous savons comment nous aurions dû le faire".

---

## 3. Analyse du projet (Exigences)

### Livrables d'analyse et Outils
Les documents et suivis se font via **Teams** et **Azure DevOps**.

**Documents requis (Wiki / Fichiers) :**
> Gestion de projet 
* Communication et  Rôles
> Préparation du projet (Vision)
* Énoncé du problème
* Les Utilisateurs Cibles (Acteurs Clés)
* MVP
* Choix technologique
* Diagramme de classe
* Standards programmation
* Maquettes
* Définition de terminé

**Utilisation d'Azure DevOps :**
* **Wiki :** Standards, Document de vision, Architecture, Glossaire.
* **Boards :** Backlog Produit / Sprint (Priorisé, estimé, assigné), Tests fonctionnels.

### Évaluation du processus
L'évaluation se base sur des grilles (Formatives et Sommatives) couvrant :
* **Cérémonies :** Mêlée, Planification, Revue, Rétro.
* **Organisation :** Utilisation des outils, pas de distractions.
* **Attitude :** Respect, écoute, participation active.
* **Contenu :** Améliorations identifiées, qualité du français, pertinence.

**Points clés de vérification :**
* *Avant la planification :* US triées par priorité, pré-estimées, détaillées avec conditions de satisfaction.
* *Pendant la planification :* Définition du but du sprint.
* *Après la planification :* Découpage en sous-tâches, vérification de la vélocité.
* *Revue de sprint :* Application déployée 3h avant, scénario de présentation clair, jeux de données pertinents.

---

## 4. Planification initiale

### Préparation du premier Sprint

| Aspect | Description |
| :--- | :--- |
| **But** | Aligner l'équipe (outils, standards, méthodes, rôles). Clarifier la forme du projet, le but et les implantations possibles (Quoi/Pourquoi/Comment). |
| **Durée** | Pour notre projet : ~ 2 jours. |
| **Résultat** | Réalisation d'un "Hello World". Environnements prêts. Déploiements fonctionnels. Architecture haut niveau. Backlog produit commencé et priorisé. |

### Analyse préliminaire

| Étape | Action | Bien livrable | Pourquoi? |
| :--- | :--- | :--- | :--- |
| **1** | **Présentation du client/PO** | Description projet, Notes communes | S'assurer que l'équipe a la même compréhension. Clarifier les points avec le PO. |
| **2** | **Analyse textuelle** | Document de vision | Identifier les concepts fondamentaux. Acquérir le vocabulaire. Éviter les erreurs de synonymes.|
| **3** | **Démarrage du backlog** | Fonctionnalités / User Stories | Identifier les acteurs et les systèmes extérieurs. Déterminer les fonctionnalités. |
| **4** | **Déterminer les acteurs** | Acteurs et rôles, Diagramme d'architecture | Déterminer le "En tant que" des US. Aider à écrire le QUOI et POURQUOI. |
| **5** | **Raffiner le découpage** | Backlog de produit | Prioriser le travail. Déterminer les US à raffiner. |
| **6** | **Raffiner les US prioritaires** | MVP (Minimum Viable Product) | S'entendre sur les règles d'affaires. Faire la planification de sprint. |

### Les biens livrables de la planification initiale (Checklist)

* [ ] **Installation physique :** Voir `Planification initiale - Technique et Infrastructure - Checklist.docx`
* [ ] **Rôles :** Membres des équipes Sprint 1 assignés.
* [ ] **Standards :** Définis.
* [ ] **Définition de terminé (DoD) :** Définie.
* [ ] **Backlog :** Fonctionnalités principales définies, Récits utilisateurs prioritaires rédigés.
* [ ] **Technique :** Application déployée fonctionnelle ("Hello World").
* [ ] **Documentation :**   * Voir `Planification initiale - Analyse et Conception - Cheklist.docx`

---

## 5. Récits Utilisateurs (User Stories)

### Critères INVEST
* **I**ndépendante
* **N**égociable
* **V**aleur ajoutée
* **E**stimable
* **S**uccincte (petite)
* **T**estable

### Format Standard
> **En tant que** `<type d'utilisateur>`
> **Je veux** `<action / objectif immédiat>`
> **Afin de** `<valeur d'affaire>`

*C'est un contrat entre l'équipe et le PO. Le PO accepte l'implémentation sur la base des critères d'acceptation.*

### Critères d'acceptation (Gherkin)
Chaque fonctionnalité doit inclure des scénarios de test (Base, Variantes, Exceptions).

**Format Gherkin :**
```gherkin
Scénario : Titre du scénario
    Étant donné (Given) ... [Préconditions / État initial]
    Lorsque (When) ... [Élément déclencheur / Action]
    Alors (Then) ... [Résultat attendu / Postconditions]