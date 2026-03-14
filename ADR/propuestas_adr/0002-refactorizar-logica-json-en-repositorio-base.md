# Propuesta: Crear un repositorio base para evitar repetir lógica JSON

Fecha: 2026-03-12

## Estado

Propuesto

## Contexto

Tenemos dos repositorios (`JsonFileUserRepository` y `JsonFileTaskRepository`) que hacen exactamente lo mismo para leer y escribir archivos JSON: abrir el archivo, deserializar, serializar y guardar. Si en algún momento queremos cambiar cómo se guarda la información (por ejemplo, cambiar el formato del JSON), hay que ir a modificar cada repositorio por separado.

## Decisión Propuesta

Crear una clase base genérica (algo como `JsonFileBaseRepository<TEntity>`) que se encargue de leer y escribir los archivos JSON. Los repositorios concretos solo se encargarían de sus consultas específicas (como buscar por usuario o por ID) y el resto lo hereda del padre.

## Consecuencias

* **Positivo:** Se aplica el principio DRY, la lógica de leer/escribir JSON queda en un solo lugar.
* **Positivo:** Si hay que cambiar algo de cómo se guardan los datos, solo se toca un archivo.
* **Negativo:** Si en el futuro alguna entidad necesita guardarse de forma muy diferente, la herencia puede quedar algo rígida. Aunque se podría resolver pasando opciones de configuración.
