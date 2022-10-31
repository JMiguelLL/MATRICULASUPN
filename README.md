# MATRICULASUPN
Reto técnico - sistema de matrículas

Alcance:

Construir una aplicación web para que usuarios administrativos puedan visualizar los cursos
matriculados, realizar matriculas y sacar reporte de matrículas.

Requerimientos:

- La aplicación debes estar construida con .NET Framework 4.7.1 o superior con código
C# y en ASP.NET MVC.
- La base de datos debe ser SQL Server 2017.
- Usar Bootstrap.
- Se debe considerar las siguientes tablas en la Base de Datos: Usuario, Estudiante,
Matricula, MatriculaDetalle, Curso, Clase y Periodo. (Se pueden añadir tablas
adicionales de ser necesario).
- Se debe guardar un log de registro de usuarios que acceden a visualizar datos de un
estudiante.
- Si un usuario se loguea incorrectamente mas de 2 veces se debe bloquear el acceso.
- El sistema no debe permitir la matricula a un estudiante inactivo (mostrar mensaje de
validación.)
- Se debe guardar un log de los movimientos de la matricula de un estudiante por
periodo (agregación o eliminación de cursos).
- El usuario no puede matricular a un estudiante en un curso en el que ya esta o ha
estado matriculado (mostrar mensaje de validación).
- Construir un reporte de matriculas que muestre los siguientes campos: Código de
Estudiante, Nombres, Periodo, Cantidad de Cursos Matriculados y Cantidad de
Movimientos (cambios de agregación o eliminación de cursos que ha sufrido la
matricula). El reporte debe poder exportarse a PDF.
- Subir el código fuente y los scripts de BD en un repositorio público, en caso de ser
privado compartir el acceso al siguiente correo: juan.benitez@upn.edu.pe.
- De ser posible publicar la solución en algún servicio público o en el IIS local (Opcional).
