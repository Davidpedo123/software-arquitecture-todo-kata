# 2. Agregar el Caso de Uso DeleteTask

Fecha: 2024-03-12

## Estado

Aceptado

## Contexto

Estamos extendiendo la Aplicación de Consola existente para soportar la eliminación de una tarea (nota). La arquitectura actual aplica un enfoque CQRS utilizando Casos de Uso (UseCases) para la orquestación y Comandos/Consultas (Commands/Queries) para la lógica real y el acceso a datos. Necesitamos decidir cómo integrar la funcionalidad de eliminación.

## Decisión

Decidimos crear un `DeleteTaskCommand` segregado y un `DeleteTaskUseCase` dedicado para manejar la lógica de eliminación, en lugar de adaptar o reutilizar comandos existentes (como `EditTaskCommand`). El Caso de Uso orquesta la acción mientras que el Comando aplica las reglas de negocio (como validar que la tarea pertenece al usuario que solicita la eliminación).

## Consecuencias

* **Positivo:** Asegura el Principio de Responsabilidad Única (SRP) al mantener cada comando estrictamente enfocado en una sola mutación.
* **Positivo:** Sigue los patrones arquitectónicos existentes en el código base, facilitando a futuros desarrolladores la navegación y extensión.
* **Negativo:** Aumenta el número de archivos y código repetitivo (Modelos, Caso de Uso, Comando, Interfaces) simplemente para realizar una eliminación.
