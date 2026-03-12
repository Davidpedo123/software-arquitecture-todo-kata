# Propuesta: Uso de MediatR para Eliminar Boilerplate de Casos de Uso

Fecha: 2024-03-12

## Estado

Propuesto

## Contexto

Actualmente, cada operación en el sistema (como Crear Tarea, Eliminar Tarea) requiere de la creación de múltiples clases: Un Request (e.g. `CreateTaskRequest`), un Result (`CreateTaskResult`), un Command o Query (`CreateTaskCommand`), un Interfaz `ICommand` o `IQuery` correspondiente, y finalmente un Caso de Uso (`CreateTaskUseCase`) que implementa la interfaz `IUseCase` y, en la mayoría de los casos, sólo actúa como un mero pasamanos (pass-through) inyectando y ejecutando el comando subyacente.

Esto genera una gran cantidad de código repetitivo (redundancia gorda) que no aporta valor de negocio, inflando el constructor de la aplicación (`TodoConsoleApp.cs`) ya que se deben inyectar o registrar docenas de de interfaces.

## Decisión Propuesta

Se propone introducir la librería **MediatR**.
En lugar de crear Casos de Uso que envuelven Comandos, los "Commands" se convertirían en `IRequest<TResponse>` y sus implementaciones serían los `IRequestHandler<TRequest, TResponse>`.

## Consecuencias

* **Positivo:** Elimina completamente la necesidad de clases envoltorio "UseCase" inútiles.
* **Positivo:** Todo el enrutamiento a los *Handlers* se hace de manera dinámica en tiempo de ejecución. El constructor de `TodoConsoleApp` pasaría de recibir 5+ dependencias `IUseCase<...>` a tener únicamente que recibir una dependencia: `IMediator mediator`.
* **Positivo:** Se reduce drásticamente el "ruido" en el código, permitiendo a los desarrolladores enfocarse en la lógica real.
* **Negativo:** MediatR añade cierta "magia" o acoplamiento implícito, lo que hace ligeramente más difícil navegar el código haciendo "Click To Defintion" o "Find all References", ya que el emisor de un `IRequest` no llama explícitamente al `IRequestHandler`.
