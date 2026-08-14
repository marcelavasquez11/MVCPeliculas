# MVCPeliculas - Sistema de Gestión de Películas
PROYECTO ACADÉMICO

MVCPeliculas es una aplicación web desarrollada con **ASP.NET MVC** y **Entity Framework Core** que permite gestionar un catálogo de películas. La aplicación incluye funcionalidades CRUD (Crear, Leer, Actualizar, Eliminar) para películas.

### Características Principales

- ✅ Listado de películas con búsqueda por título
- ✅ Creación, edición y eliminación de películas
- ✅ Asignación de géneros a cada película
- ✅ Interfaz responsiva
- ✅ Base de datos SQL Server
- ✅ Contenerización con Docker
- ✅ Orquestación multi-contenedor con Docker Compose

---

## 🛠️ Tecnologías Utilizadas

| Tecnología | Versión | Descripción |
|------------|---------|-------------|
| **.NET** | 8.0 | Framework principal |
| **ASP.NET MVC** | 8.0 | Patrón de diseño MVC |
| **Entity Framework Core** | 8.0.28 | ORM para acceso a datos |
| **SQL Server** | 2022 | Motor de base de datos |
| **Docker** | 24.0+ | Contenerización |

---

## 📁 Estructura del Proyecto

```bash
Desafio1/
│
├── MVCPeliculas/                           
│   │
│   ├── Controllers/                          # Controladores - Lógica de la aplicación
│   │   ├── HomeController.cs                 # Página de inicio y privacidad
│   │   ├── PeliculasController.cs            # CRUD completo de películas
│   │   └── HelloWorldController.cs           # Controlador de ejemplo
│   │
│   ├── Data/                                
│   │   ├── PeliculasDbContext.cs             # Contexto de Entity Framework
│   │   └── SeedData.cs                       # Datos iniciales
│   │
│   ├── Models/                                
│   │   ├── Pelicula.cs                       # Modelo de película 
│   │   └── ErrorViewModel.cs                 # Modelo para manejo de errores
│   │
│   ├── Views/                               
│   │   │
│   │   ├── Home/                             # Vistas de la página principal
│   │   │   ├── Index.cshtml                  # Página de inicio con bienvenida
│   │   │   └── Privacy.cshtml               
│   │   │
│   │   ├── Peliculas/                        # Vistas del CRUD de películas
│   │   │   ├── Index.cshtml                  
│   │   │   ├── Create.cshtml                
│   │   │   ├── Edit.cshtml                   
│   │   │   ├── Details.cshtml               
│   │   │   └── Delete.cshtml                 
│   │   │
│   │   └── Shared/                           # Vistas compartidas
│   │       ├── _Layout.cshtml                # Plantilla principal de la página
│   │       └── _ValidationScriptsPartial.cshtml  # Validaciones
│   │
│   ├── Migrations/                           
│   │
│   ├── wwwroot/                              
│   │   ├── css/
│   │   │   └── site.css                      # Estilos personalizados
│   │   ├── images/
│   │   │   └── movie.png                     # Imagen de la página de inicio
│   │   └── lib/                              # Librerías externas
│   │
│   ├── Properties/			      # Configuración de ejecución
│   │
│   ├── Program.cs                             # Punto de entrada de la aplicación
│   └── appsettings.json                       # Configuración (cadena de conexión)
│
├── Dockerfile                                 # Configuración para contenerización
├── docker-compose.yml                         # Orquestación App + SQL Server
├── .gitignore                                 
├── README.md                                  
│
└── evidencias/                                # Capturas de funcionamiento
```

## 🐳 Ejecución con Docker

### 📋 Requisito Previo

- [Docker Desktop](https://www.docker.com/products/docker-desktop/) instalado y en ejecución


#### 1. Clonar el repositorio (o navegar a la carpeta del proyecto)

```bash
git clone https://github.com/marcelavasquez11/MVCPeliculas-cloud.git
```

> **Nota**: navegar a raiz del proyecto clonado. Ejemplo: `cd MVCPeliculas`

#### 2. Construir y levantar los contenedores

```bash
docker-compose up --build
```

**Este comando:**
- Construye la imagen de la aplicación
- Descarga la imagen de SQL Server 2022
-  Crea y levanta ambos contenedores:
   `peliculas-app` (Aplicación ASP.NET MVC)
   `peliculas-db` (SQL Server)

#### 3. Verificar que los contenedores están corriendo

```bash
docker ps
```

**Resultado esperado:**
```
CONTAINER ID   IMAGE                      STATUS         PORTS
xxxxxxxxxxxx   mvcpeliculas-peliculas-app Up 2 minutes   0.0.0.0:8081->8080/tcp
xxxxxxxxxxxx   mcr.microsoft.com/mssql/server:2022-latest Up 2 minutes   0.0.0.0:1433->1433/tcp
```

#### 4. Acceder a la aplicación

Abre tu navegador y ve a:

```
http://localhost:8081
```

---

### 🗄️ Conectarse a SQL Server

#### Opción 1: Desde el contenedor (terminal)

```bash
docker exec -it desafio1-peliculas-db-1 /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P Password123! -C
```

**Comandos SQL para verificar datos:**

```sql
-- Ver todas las bases de datos
SELECT name FROM sys.databases;
GO

-- Usar la base de datos Peliculas
USE Peliculas;
GO

-- Ver todos los géneros
SELECT * FROM Generos;
GO

-- Ver todas las películas
SELECT * FROM Peliculas;
GO

-- Salir
EXIT
```

### 📊 Comandos útiles de Docker

| Comando | Descripción |
|---------|-------------|
| `docker-compose up --build` | Construye y levanta los contenedores |
| `docker-compose up -d` | Levanta los contenedores en segundo plano |
| `docker-compose down` | Detiene y elimina los contenedores (conserva datos) |
| `docker-compose down -v` | Detiene y elimina contenedores + volumen (pierde datos) |
| `docker ps` | Lista contenedores activos |
| `docker volume ls` | Lista todos los volúmenes |

---

### Solución de problemas comunes

| Problema | Solución |
|----------|----------|
| **Error: port 8081 already allocated** | Cambia el puerto en `docker-compose.yml` o detén el otro contenedor |
| **Error: no se puede conectar a la base de datos** | Espera 30 segundos a que SQL Server termine de iniciar |
| **Error: contraseña incorrecta** | Usa `Password123!` o cambia la contraseña en `docker-compose.yml` |
| **Los datos se pierden al reiniciar** | No uses `docker-compose down -v`, solo usa `docker-compose down` |

---

## 👩‍💻 Realizado por

- **Nombre:** Melissa Flores FA220709
- **Carnet:** Wendy Aguilar AV220801 

---

## 📄 Licencia

Este proyecto fue desarrollado con fines académicos como parte de experimentación en Contenerización.

---
