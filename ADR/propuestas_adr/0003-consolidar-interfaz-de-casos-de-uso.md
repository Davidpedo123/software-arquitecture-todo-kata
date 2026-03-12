# Propuesta: Consolidar Interfaz de Casos de Uso e Inyección Directa de Dependencias (Eliminar Capa Duplicada)

Fecha: 2024-03-12

## Estado

Propuesto

## Contexto

En el diagrama arquitectónico actual, observamos una estricta separación entre operaciones de Comandos/Consultas (ubicados en el proyecto `.Cqrs`) y los Casos de Uso (ubicados en el proyecto `.UseCases`).

Sin embargo, en su estado actual, el Caso de Uso rara vez hace algo más que recibir una petición (`TRequest`) y delegar esa petición textualmente a un Comando interno (`TCommand`). A nivel conceptual, el Comando **es** la encapsulación del Caso de Uso. A nivel código, hay interfaces duplicadas que definen contratos idénticos (e.g. `IUseCase<TInput, TOutput>` vs `ICommand<TInput, TOutput>`).

## Decisión Propuesta

Se propone eliminar la capa externa de `UseCases` para estos flujos simples. Los Comandos y Consultas pueden registrarse directamente en el Inyector de Dependencias (IoC), y la aplicación de interfaz de usuario (`TodoConsoleApp.cs`) puede recibir un `ICommand<CreateTaskRequest, CreateTaskResult>` directamente en su constructor.

## Consecuencias

* **Positivo:** Se elimina una capa arquitectónica completa (`ArchitectureKata.TodoList.UseCases`) que actualmente actúa como "anémica" y no aporta orquestación real.
* **Positivo:** Se reduce el tiempo de desarrollo a la mitad para nuevas funciones, al no tener que cruzar de `.Cqrs` a `.UseCases` sólo de ida y vuelta.
* **Negativo:** Si en el futuro un Caso de Uso necesita coordinar **dos o más** Comandos (ej. `CreateUser` y luego `SendWelcomeEmail`), la capa de orquestación haría falta. En tal escenario, se tendría que crear un servicio orquestador, o bien regresar a la estructura actual para esos casos particulares.
