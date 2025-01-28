# HackerNewsAPI
Esta es una API RESTful desarrollada en ASP.NET Core que recupera las mejores historias de la API de Hacker News. La aplicación organiza y retorna las historias en orden descendente de puntuación, permitiendo especificar el número de historias a recuperar mediante un parámetro.

---

## Requisitos previos

Antes de ejecutar la aplicación, asegúrate de que tienes instalados los siguientes componentes:

1. SDK de .NET 7.0 o superior  
   Puedes descargarlo desde [aquí](https://dotnet.microsoft.com/download).

2. Editor de código o IDE  
   Recomendamos [Visual Studio Code](https://code.visualstudio.com/) o [Visual Studio](https://visualstudio.microsoft.com/).

3. Git (opcional)  
   Para clonar el repositorio si aún no lo tienes localmente.

---

## Instalación y configuración

Sigue estos pasos para configurar y ejecutar la aplicación:

### 1. Clonar el repositorio

Clona el proyecto desde el repositorio público:

```bash
git clone https://github.com/hernandezNQF/HackerNewsAPI.git
cd HackerNewsAPI
```

### 2. Restaurar dependencias
Restaura las dependencias del proyecto con el siguiente comando:
```dotnet restore```

### 3. Ejecutar la aplicación
Ejecuta la aplicación con:
```dotnet run```  
La API estará disponible en http://localhost:5240 (el puerto puede variar)

### 4. Probar los endpoints
Accede a la documentación Swagger en tu navegador en:
http://localhost:5240/swagger

Desde ahí, podrás probar el endpoint principal:
GET /api/hackernews/beststories

**Parámetros:**
/api/hackernews/beststories?n={n}   
n (opcional): Número de historias a recuperar (por defecto 10).

**Ejemplo de respuesta:**
```json
[
  {
    "title": "A uBlock Origin update was rejected from the Chrome Web Store",
    "uri": "https://github.com/uBlockOrigin/uBlock-issues/issues/745",
    "postedBy": "isaaclawson",
    "time": "2019-08-12T13:43:18+00:00",
    "score": 1716,
    "commentCount": 572
  },
  ...
]
```

---

### Supuestos realizados
**1. Formato de datos:**
  El formato de salida incluye campos relevantes (title, uri, postedBy, etc.) basados en los requisitos.

**2. Orden de las historias:**
  Las historias están ordenadas en orden descendente por puntuación.

**3. Gestión de errores:**
  Si ocurre un error al interactuar con la API de Hacker News, se devuelve un error 500 con un mensaje descriptivo.

---

### Mejoras y cambios posibles
Dado más tiempo, se podrían implementar las siguientes mejoras:

**1. Caching:**
  Implementar almacenamiento en caché para evitar múltiples solicitudes innecesarias a la API de Hacker News, mejorando el rendimiento y reduciendo la carga en su servidor.

**2. Paginación:**
  Agregar soporte para paginación en los resultados devueltos por la API.

**3. Pruebas unitarias:**
Escribir pruebas unitarias para validar la funcionalidad del servicio HackerNewsService.

**4. Manejo avanzado de errores:**
  Mejorar el manejo de excepciones para diferenciar errores del cliente (como parámetros inválidos) y errores del servidor externo.
