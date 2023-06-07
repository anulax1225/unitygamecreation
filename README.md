# Procedural environnnement

## But
Le but de ce projet est de créer un generateur procédural d'environnnement<br>
virtuel. Qui servira à la generation de terrain en 2D.

## Installation
### Prérequis
Pour pouvoir utilisé l'application il faut tout d'abord installé unity.
Et la librérie C# qui contient toute les classes dédié à unity, c'est pour cela que je vous conseille d'utilisé l'IDE visual studio 2022<br> 
car il  contient un runtime C# et les librérie neccessaire à l'utilisation de unity.

### Commandes
Pour installer le repo tapez les commandes suivante dans git bash :
```bash 
    mkdir projetTropCool
    cd projectTropCool
    git init --initial-branch=perlinMap
    git remote add origin "https://github.com/anulax1225/unitygamecreation.git"
    git pull origin perlinMap
```
Puis ouvrez le unity hub et ouvré le dossier depuis celui-ci.

## Fonctionnement
Se projet est principalement basé sur un type de bruit bien<br>
particulier, le bruit de perlin. Il s'agit d'un bruit comme le bruit blanc qui forme des image de bruit qui on des patterns bien précise mais qui ne se répaît jamais.<br>
Un exemple :
<div align="center">
    <img src="./readmeimg/perlin_noise_map.png" width="100" height="100">
</div>
<br>
Puis l'on par du principe que sur le plan en deux dimension plus un point est foncé plus il est hauteur sur la carte<br>
donc on peux créer une variation des couleurs en fonction de la hauteur du terrain. La hauteur du terrain à été normalizé à une valeur entre 0-1.<br>
Donc j'ai choisi ces paramètres:
<div align="center">
    <img src="./readmeimg/param_couleur_map.png" width="25%" height="25%">
</div>
<br>
Et voilà le résultat pour la même carte que au dessus :
<div align="center">
    <img src="./readmeimg/colour_map.png" width="100" height="100">
</div>
<br>
