# 3. Implementar Borrado Físico (Hard Delete) en el Repositorio JSON

Fecha: 2024-03-12

## Estado

Aceptado

## Contexto

Al implementar la funcionalidad `DeleteTask`, necesitamos un mecanismo para eliminar las tareas de la persistencia. La aplicación actualmente utiliza un archivo JSON simple por modelo para su almacenamiento de datos. Necesitamos decidir si implementar un "borrado lógico" (soft delete, agregando una bandera `IsDeleted`) o un "borrado físico" (hard delete, eliminándolo del arreglo JSON).

## Decisión

Implementaremos un Borrado Físico (Hard Delete) desde el `JsonFileTaskRepository`. Esto implicará cargar la lista JSON en la memoria, remover el elemento por completo y reescribir el arreglo en el disco.

## Consecuencias

* **Positivo:** Simplicidad. Concuerda con la naturaleza simplista y orientada a la kata de la estructura de persistencia JSON actual. Los archivos de datos no se inflarán con el tiempo.
* **Positivo:** Evita cambios en cascada en todas las Consultas existentes (ej. `ListTasksQuery`) para filtrar las tareas con `IsDeleted == true`.
* **Negativo:** Las eliminaciones son definitivas. Si un usuario elimina accidentalmente una tarea, no se puede recuperar.
* **Negativo:** No es ideal para un entorno de producción donde generalmente se requiere auditoría o retención de historial, pero es aceptable para esta kata.
