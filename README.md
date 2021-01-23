# Scape Room 

Eduardo Díaz Hernández

Sergio Guerra Arencibia

Esther Jorge Paramio

## Descripción

En este proyecto se ha desarrollado una aplicación de Realidad virtual para *Google CardBoards*. 

Hemos elegido desarrollar un juego basado en un *scape room* en el que se tiene que escapar de una cabaña realizando diferentes puzzles, desde puzzles deslizantes hasta laberintos. También hay que resolver enigmas o cuestiones interactuando con el medio.

## Cuestiones importantes para el uso

Para el uso del programa es importante disponer de un mando que disponga de un joystick y dos o más botones. El joystick permitirá el movimiento del personaje y los botones la interacción con el entorno. Además se necesitará (obviamente) unas gafas VR ya que es un juego de realidad virtual.

La interacción con el juego se realizará haciendo uso de la retícula y los botones del mando para interactuar con los objetos del entorno. Es importante destacar que, cuando un objeto es interactivo se indica con la retícula. Es decir, cuando el jugador mira a un objeto interactivo la retícula se expande para indicar la funcionalidad. 
La interacción se detecta mediante el uso de *RayCast*, permitiéndonos detectar si el usuario está mirando a dicho objeto. En esta situación, si se pulsa el botón *A* se activa la respectiva acción que tiene que ver con dicho objeto.

Adicionalmente, por comodidad de desarrollo el juego también admite como controles el teclado y ratón. Esto es principalmente para que sea cómodo de interactuar a la hora de probarlo durante el desarrollo.

## Hitos de programación [logrados relacionándolos con los contenidos que se han impartido]  

En primer lugar hemos logrado el desarrollo de una aplicación en realidad virtual que es cómoda de usar. Esto es importante destacarlo ya que a la hora 
de desarrollar una aplicacion de este tipo hay que tener en cuenta varias características importantes.  
  - Uso del menú para permitir al usuario iniciar el juego cuando él decida, nunca automáticamente.
  - Velocidad constante en el juego, evitando discrepancias entre la percepción virtual y real.
  - Uso de la retícula para proporcionar información (indicando si un elemento es interactuable por ejemplo)
  - Transiciones entre escenas de manera progresiva para evitar la pérdida del seguimiento de cabeza.  

  
Adicionalmente, se han implementado diferentes mecánicas gracias a los contenidos impartidos en clase.  
Uno de los más importantes es el uso de delegados. Sabesmos que este es un recurso aplicado a estas situaciones donde un elemento necesita interactuar con dos o más. 
Así, nos ha simplificado la interacción entre elementos en situaciones donde, por ejemplo, debemos encender un conjunto de luces a partir de un solo interruptor.  

Respecto los sensores explicados en clase hemos incluido el uso de la brújula.  
El objetivo de este sensor dentro del juego es permitir al jugador a relacionar direcciones con colores, dando así el conocimiento para resolver uno de los engimas planteados.


## Gifs de la ejecución


## Acta de acuerdos
### Reparto de tareas  
- **Tareas:**
  -  Puzzles:
     - Laberinto
     - Piezas corazón
     - Candado final
     - Puzzle deslizante

  - Diseño habitaciones:
    - Primera habitación
    - Segunda habitación
    - Laberinto
    - Menú

  - Muebles en blender:
    - Armario pequeño
    - Piezas corazón
    - Candado
    - Espejo con sábana
    - Sofá con sábana
    - Lámparas
  
  - Animaciones:
    - Abrir candado
    - Abrir armario pequeño
    - Esconder paredes

  - Programación:
    - Deslizar puzzle
    - Abrir puerta laberinto
    - Controlar jugador
    - Posicionar piezas corazón
    - Esconder paredes laberinto
    - Controlar menú
    - Cambios de escena 

### Tareas desarrolladas individualmente

- **Blender:** Eduardo Díaz Hernández
  
### Tareas desarrolladas en grupo

- Diseño y programación en Unity
