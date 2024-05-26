# Laboratorio-.Net-Denis
Laboratorio .net Denis Saavedra
# Descripcion
Este proyecto sirve para gestionar un sistema de punto de venta (POS) para una pizzería, desarrollado en .NET Core.
### Aspectos Generales
- Se utiliza el enfoque database firts
- La solucion consta de 3 proyectos: 
 DataAccess(biblioteca de clases), API, Presentation(Windows Form)

## Instalacion
Instrucciones paso a paso sobre cómo configurar el entorno de desarrollo local.


### Prerrequisitos
- [.NET Core 5](Autorizado en meet de laboratorio)
- [SQL Server 2019]


### Configurar EFCore
En el proyecto DataAccess Utiliza los nugets:
Microsoft.EntityFrameworkCore.SqlServer 5.0.6
Microsoft.EntityFrameworkCore.Tools 5.0.6

Busca el archivo en el proyect DataAccess>Models>SistemaPOSPizzeriaContext.cs y en la linea 43 cambia la cadena de conexion por tus credenciales.


### Configurar Proyecto API
En este caso solo debes ubicar el appsettings.json y modificar DefaultConnection="" por tus credenciales.

### Consumir el API desde POSTMAN u otros.
Ejemplo.
https://localhost:tupuerto/api/Authentication/Login, este endpoint recibe el model
{
  "usuarioNombre": "Albatros.Services",
  "usuarioPassword": "albatros123"
}


### Configurar ProyectoWinForms
Este proyecto consume el API restfull. Para su correcto funcionamiento, ir a la siguiente ruta Models>ApiPort.cs
y modificar la propiedad UrlBase="https://localhost:44323" por el puerto que su equipo le haya asignado a la solucion.



