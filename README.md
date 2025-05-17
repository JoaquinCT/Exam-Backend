Exam Backend – REST API

Bienvenido al backend del proyecto Exam.
Este servicio está escrito en ASP .NET Core 8 y expone una API REST para administrar cursos y estudiantes.
El repositorio incluye todo lo necesario para compilar, ejecutar y probar la aplicación localmente o desde un dispositivo móvil/emulador.

Contenido:

    Requisitos

    Clonar y restaurar

    Ejecución

    Rutas principales

    Variables de entorno

    Migraciones EF Core

    Licencia

Requisitos:

    .NET SDK 8.0.x

    Visual Studio 2022 o VS Code + extensión C# Dev Kit

    dotnet-ef 8.0.x (opcional, para manejar migraciones)

Clonar y restaurar:

    Clona el repositorio:
    git clone https://github.com/JoaquinCT/Exam-Backend.git

    Entra al directorio del proyecto:
    cd Exam-Backend

    Restaura dependencias:
    dotnet restore

Ejecución:

La URL donde se ejecuta la API se define en el archivo Properties/launchSettings.json.
Debes cambiar el valor de "applicationUrl" dependiendo del dispositivo desde el que accederás a la API:

    Si usas un emulador Android o navegas localmente: usa https://localhost:5292

    Si usas un celular u otro dispositivo en la misma red local: usa http://0.0.0.0:5292

Importante: El puerto por defecto es 5292. Asegúrate de que sea el mismo tanto en el backend como en el frontend o herramienta que consuma la API.

Para iniciar el servidor:

dotnet run --project Exam-Backend

Rutas principales:

Cursos (/api/course):

    GET /api/course → listar todos los cursos

    GET /api/course/{id} → obtener un curso específico

    POST /api/course → crear un nuevo curso

    PUT /api/course/{id} → actualizar un curso

    DELETE /api/course/{id} → eliminar un curso

Estudiantes (/api/student):

    GET /api/student → listar todos los estudiantes

    GET /api/student/{id} → obtener un estudiante específico

    POST /api/student → crear un nuevo estudiante

    PUT /api/student/{id} → actualizar un estudiante

    DELETE /api/student/{id} → eliminar un estudiante

    GET /api/student/by-course/{courseId} → obtener los estudiantes que pertenecen a un curso específico

Variables de entorno:

    ASPNETCORE_ENVIRONMENT: Development (por defecto)

    ConnectionStrings__Default: Data Source=Exam.db (usa SQLite por defecto)

Puedes configurarlas directamente en el entorno o en appsettings.Development.json.

Migraciones con EF Core:

Si realizas cambios en las entidades y deseas generar una nueva migración:

dotnet ef migrations add NombreDeLaMigracion

Para aplicar las migraciones y crear/actualizar la base de datos:

dotnet ef database update

La base de datos se genera como un archivo local SQLite (Exam.db).