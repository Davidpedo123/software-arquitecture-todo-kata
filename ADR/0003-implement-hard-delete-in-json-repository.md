# 3. Usar borrado físico en el repositorio JSON

Fecha: 2026-03-12

## Estado

Aceptado

## Contexto

Al agregar la función de eliminar tareas, teníamos que decidir cómo manejar el borrado en el archivo JSON donde se guardan los datos. Las dos opciones eran: marcar la tarea como eliminada sin borrarla realmente (soft delete), o eliminarla por completo del archivo (hard delete).

## Decisión

Decidimos hacer un borrado físico: se carga la lista de tareas del JSON, se quita la tarea y se vuelve a guardar el archivo. Así de simple.

## Consecuencias

* **Positivo:** Es la opción más sencilla y encaja bien con el enfoque simple del proyecto. Además el archivo no se llena de tareas "borradas" que en realidad siguen ahí.
* **Positivo:** No hay que modificar las consultas existentes (como listar tareas) para que filtren las eliminadas.
* **Negativo:** Si borras algo por error, no hay forma de recuperarlo.
* **Negativo:** En un sistema real probablemente se necesitaría guardar historial, pero para este ejercicio académico está bien así.
