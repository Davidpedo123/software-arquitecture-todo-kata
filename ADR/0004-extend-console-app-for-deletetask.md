# 4. Agregar la opción de eliminar en la consola

Fecha: 2026-03-12

## Estado

Aceptado

## Contexto

Ya tenemos la lógica de eliminar tareas lista, pero falta que el usuario pueda usarla desde la consola. La app usa un menú con un bucle y un switch-case para manejar las opciones.

## Decisión

Agregamos una nueva opción "dt" (delete task) al menú de la consola. Se inyecta el caso de uso de eliminar directamente en la clase principal de la app, y se muestra una confirmación antes de borrar (el típico "¿Estás seguro? y/N"). No cambiamos la forma en que funciona el menú.

## Consecuencias

* **Positivo:** Es rápido de implementar y no hay que reestructurar toda la app.
* **Positivo:** La app sigue siendo igual de sencilla y fácil de entender.
* **Negativo:** El constructor de la clase principal sigue creciendo con cada funcionalidad nueva. Si se siguen agregando más opciones, esa clase va a terminar haciendo demasiadas cosas.
