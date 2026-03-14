# 2. Agregar la opción de Eliminar Tarea

Fecha: 2026-03-12

## Estado

Aceptado

## Contexto

La app de tareas ya permite crear y editar notas, pero no tiene forma de borrarlas. Se necesita agregar esa funcionalidad como parte de un requerimiento académico.

## Decisión

Seguimos la misma estructura que ya teníamos para crear y editar tareas. Básicamente creamos las mismas piezas (modelo, caso de uso, comando, interfaz) pero orientadas a eliminar.

## Consecuencias

* **Positivo:** Como seguimos el mismo patrón, es fácil de entender para cualquiera que ya conozca el proyecto.

* **Negativo:** Se crean varios archivos nuevos solo para una operación de borrado, lo que puede sentirse repetitivo.
