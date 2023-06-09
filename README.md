# Animation procedural de tantacule

## But
Le but pour se project est de découvrir différent type d'animation de personnage.
En l'occurence j'ai créer une petite pieuvre qui suite la sourir. La pieuvre à trois tentacul indépendante qui se déplace derrière elle. 

## Installation

### Commandes
Pour accèdez à se project tapez les commandes suivantes dan git bash:
```bash
    mkdir projetTropCool
    cd projectTropCool
    git init --initial-branch=proc_tail_anim
    git remote add origin "https://github.com/anulax1225/unitygamecreation.git"
    git pull origin proc_tail_anim  
```

## Fonctionnement 
Les tentacule de la pieuvre sont générer via l'interpolation de plusieur point tout au long du tentacul.
Ceux-ci sont ensuite relié par des vecteur pour créer la forme du membre, puis il sont appliqué à l'écran d'aide d'un LineRender. Il est bon de savoir que le premier point du membre est toujour relié à l'extrémité du corp.