# Propuesta: Quitar la capa de UseCases cuando no aporta nada

Fecha: 2026-03-12

## Estado

Propuesto

## Contexto

En el proyecto hay una separación entre los Commands/Queries (en el proyecto `.Cqrs`) y los UseCases (en `.UseCases`). Pero en la práctica, la mayoría de los UseCases lo único que hacen es recibir un request y pasárselo tal cual al Command. Es decir, el Command ya **es** el caso de uso real, y la capa de UseCase está de más.

## Decisión Propuesta

Para los flujos simples donde el UseCase no agrega nada, eliminarlo. Los Commands y Queries se registrarían directamente en el contenedor de dependencias y la app de consola los recibiría sin intermediarios.

## Consecuencias

* **Positivo:** Se elimina una capa que hoy no aporta valor real y solo agrega archivos.
* **Positivo:** Agregar funcionalidades nuevas toma la mitad del tiempo porque no hay que crear la clase UseCase de más.
* **Negativo:** Si más adelante un caso de uso necesita coordinar varios comandos (por ejemplo, crear un usuario y luego enviarle un email), haría falta volver a tener esa capa de orquestación para esos casos puntuales.
