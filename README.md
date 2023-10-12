### Trabajo Práctico N° 1.1 UTN
En el año 2508, una empresa de minería espacial bajo el acrónimo CEC nos pide
desarrollar un programa para catalogar y cuantificar los materiales que extraen de sus operaciones mineras.

La CEC tiene una flota de vehículos especializados para estas operaciones. Nuestro programa se instalará en cada uno de esos vehículos, o naves.

Las naves pueden desplazarse a diferentes sistemas, y en cada sistema hay una cantidad determinable de asteroides. Al entrar en un nuevo sistema, la nave debe procesar cada asteroide secuencialmente, y al minar cada asteroide obtener una cantidad de hierro, oro, platino y metales misceláneos.

Los asteroides vienen en 4 tipos de tamaños - pequeños, medianos, grandes, y
cataclísmicos. Según su tamaño tienen una composición - por motivos de este programa, aleatoria - de los 4 tipos de metales que pueden poseer, pero que sumados nos devuelven una carga procesada de exactamente 1000kg, 2000kg, 5000kg, y 10000kg.

Nos piden un programa que pueda cumplir con estas tareas, pero con una condición, como el programa está pensado para una computadora de 256kb de memoria, no podemos usar ni clases, ni objetos, ni listas dinámicas. Sin embargo, podemos usar enums.

Nos piden un programa que pueda hacer lo siguiente:
1) Simular un sistema y generarlo con una cantidad aleatoria de asteroides.

2) Procesar todos los asteroides del sistema.

3) Al salir del sistema, hagamos un reporte por pantalla de todos los metales adquiridos y nos dé la opción de entrar en otro sistema, o salir del programa.

4) Si en la opción anterior salimos del programa, entonces debemos hacer un reporte general de todos los metales coleccionados en todos los sistemas.

Un reporte debería verse como tal:

EN EL SISTEMA [45466XB] SE MINARON [3] ASTEROIDES:
- 2867 KG de hierro
- 1532 KG de oro
- 992 KG de platino
- 2609 KG de metales misceláneos

Por un total de 8000 KG de carga.

No hace falta mostrar el nombre del sistema en el reporte general.

