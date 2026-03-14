# Propuesta: Usar MediatR para reducir código repetitivo

Fecha: 2026-03-12

## Estado

Propuesto

## Contexto

Cada vez que agregamos una operación nueva (crear tarea, eliminar tarea, etc.) hay que crear un montón de clases: el Request, el Result, el Command, la interfaz y el UseCase. El problema es que el UseCase casi siempre solo recibe el pedido y se lo pasa al Command sin hacer nada más. Es mucho código para algo tan simple.

Además, el constructor de la clase principal de la app se va llenando de dependencias con cada operación nueva.

## Decisión Propuesta

Usar la librería **MediatR**. En vez de tener UseCases que solo pasan datos al Command, los Commands se convierten directamente en Requests de MediatR y sus implementaciones son los Handlers. La app solo necesita recibir un `IMediator` en vez de una dependencia por cada operación.

## Consecuencias

* **Positivo:** Se eliminan las clases UseCase que no aportaban nada.
* **Positivo:** El constructor de la app pasa de tener 5+ dependencias a tener solo una.
* **Positivo:** Hay menos ruido en el código y es más fácil enfocarse en lo importante.
* **Negativo:** MediatR esconde un poco cómo se conectan las piezas, así que es más difícil rastrear quién maneja cada operación con "ir a definición".
