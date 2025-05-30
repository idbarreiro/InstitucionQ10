# InstitucionQ10

Aplicación web para gestionar estudiantes y materias, desarrollada con ASP.NET Core y Razor Pages.

## Requisitos previos

Antes de ejecutar este proyecto, asegúrate de tener instalado:

- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/es/) 
- SQL Server LocalDB o cualquier instancia de SQL Server
- [Git](https://git-scm.com/) para clonar el repositorio

---

## 🛠️ Configuración del entorno

1. **Clona el repositorio:**

   ```bash
   git clone https://github.com/idbarreiro/InstitucionQ10.git
   cd InstitucionQ10
   
2. Configura la cadena de conexión:

      En appsettings.json, verifica la sección ConnectionStrings:

      ```json
      "ConnectionStrings": {
        "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=InstitucionQ10Db;Integrated Security=True;MultipleActiveResultSets=True;"
      }
      ```
      
      Si usas otra instancia de SQL Server, ajusta la cadena.

3. Restaura dependencias y aplica migraciones:

      ```bash
      dotnet restore
      dotnet ef database update

4. Iniciar depuración
   
    ```bash
     dotnet run
