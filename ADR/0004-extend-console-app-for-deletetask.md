# 4. Extender el Enrutamiento Directo de la Consola para DeleteTask

Fecha: 2024-03-12

## Estado

Aceptado

## Contexto

Necesitamos proporcionar una interfaz de usuario para desencadenar el nuevo `DeleteTaskUseCase`. La aplicación de consola original se ejecuta completamente en `TodoConsoleApp.cs` con inyección directa de dependencias en `Program.cs` y un mecanismo de enrutamiento interno que utiliza bucles `while(true)` y switch-cases (o estructuras if/else).

## Decisión

Inyectaremos `IUseCase<DeleteTaskRequest, DeleteTaskResult>` directamente en `TodoConsoleApp`, agregaremos un nuevo enum `LandingAction.DeleteTask`, añadiremos `"dt"` al menú, e implementaremos `DoDeleteTaskAsync` directamente en la aplicación de consola, confirmando la eliminación con un prompt `(y/N)`. No refactorizaremos el sistema de enrutamiento de la Consola.

## Consecuencias

* **Positivo:** Implementación rápida. Evita una refactorización potencialmente masiva para introducir verdaderos controladores o un framework de enrutamiento CLI como `System.CommandLine`.
* **Positivo:** Mantiene la consistencia pedagógica de la Kata. La simplicidad de la aplicación permanece intacta.
* **Negativo:** El constructor de `TodoConsoleApp.cs` sigue creciendo (`n+1` dependencias). Eventualmente, a medida que se agreguen más características, esta clase se convertirá en un objeto-dios ("god object") violando el SRP en la capa de presentación.
