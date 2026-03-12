# Propuesta: Refactorizar Lógica de Archivos JSON hacia un BaseRepository Genérico

Fecha: 2024-03-12

## Estado

Propuesto

## Contexto

Actualmente, el proyecto cuenta con un `JsonFileUserRepository` y un `JsonFileTaskRepository`. Al observar sus implementaciones, ambos comparten exactamente el mismo mecanismo de lectura (`File.OpenRead`, `JsonSerializer.DeserializeAsync`) y escritura (`Directory.CreateDirectory`, `File.Create`, `JsonSerializer.SerializeAsync`) de archivos JSON. 

Esta redundancia implica que cualquier cambio necesario en cómo se almacenan, serializan (por ejemplo, cambiar opciones de mayúsculas y minúsculas) de los JSONs requiere la modificación manual en **n** repositorios distintos.

## Decisión Propuesta

Se propone crear una clase base abstracta genérica, por ejemplo `JsonFileBaseRepository<TEntity>`, que abstraiga las operaciones fundamentales de cargar y guardar listas desde/hacia archivos de texto JSON. Los repositorios concretos heredarían de esta clase, encapsulando solo su lógica de consulta específica ("GetByUserId", "GetByUsername") y delegando todo el I/O al padre.

## Consecuencias

* **Positivo:** Adhesión estricta al principio DRY (Don't Repeat Yourself). Las mecánicas de lectura y escritura estarían centralizadas en una única vez en todo el sistema.
* **Positivo:** Facilidad para aplicar actualizaciones transversales a la persistencia en formato JSON.
* **Negativo:** El uso de herencia puede volverse rígido si entidades en el futuro requieren serializaciones JSON sumamente diferentes u opciones que no aplican a la clase padre. (Aunque esto puede mitigarse inyectando las `JsonSerializerOptions`).
