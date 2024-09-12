# Proyecto Web API - Práctica 02

## Estructura del Proyecto

El proyecto debe tener la siguiente estructura:


### Detalles del Proyecto

#### 1. **Controlador: `ArticulosController` (carpeta Controllers)**
   Este controlador será responsable de exponer los endpoints para la gestión de artículos en la Web API. Los métodos necesarios son:
   - `AgregarArticulos`: Permite agregar nuevos artículos.
   - `ConsultarArticulos`: Recupera los artículos almacenados.
   - `EditarArticulos`: Modifica los datos de un artículo existente.
   - `EliminarArticulos`: Marca un artículo como dado de baja.

#### 2. **Modelo: `Articulo` (carpeta Models)**
   Define las propiedades del artículo que serán gestionadas. Este modelo puede incluir propiedades como:
   - `Id`: Identificador único.
   - `Nombre`: Nombre del artículo.
   - `Precio`: Precio del artículo.
   - `Cantidad`: Cantidad disponible.
   - `Estado`: Estado del artículo (Activo/Inactivo).

#### 3. **Interfaz: `IAplicacion`**
   La interfaz `IAplicacion` expone los métodos para interactuar con los artículos. Los métodos incluyen:
   - `AgregarArticulo(Articulo articulo)`
   - `ConsultarArticulos()`
   - `EditarArticulo(Articulo articulo)`
   - `EliminarArticulo(int articuloId)`

#### 4. **Capa de Acceso a Datos (Repository Pattern)**
   Implementa el patrón Repository para gestionar el acceso a los datos mediante procedimientos almacenados. Esta capa se encargará de:
   - Realizar operaciones CRUD sobre la base de datos utilizando procedimientos almacenados.
   - Encapsular la lógica de acceso a los datos, haciendo la API independiente de la tecnología de base de datos.

#### 5. **Proyecto de Librería (DLL)**
   Para la capa de acceso a datos, se puede crear un segundo proyecto de tipo Librería. Este proyecto:
   - Contendrá las implementaciones de acceso a datos utilizando el patrón Repository.
   - Deberá ser referenciado en el proyecto principal (Web API) para permitir su uso en el controlador y los servicios.

## Requerimientos Adicionales

1. **Base de Datos**:
   - Utilice la misma base de datos que fue utilizada en la actividad 01.
   
2. **Procedimientos Almacenados**:
   - Desarrollar los procedimientos almacenados necesarios para realizar las operaciones de agregar, consultar, editar y eliminar artículos.

3. **Pruebas con Swagger**:
   - Configure y pruebe la Web API utilizando la herramienta Swagger para asegurarse de que los endpoints funcionan correctamente.
