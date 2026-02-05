# Blog Management Backend

A robust backend API for managing blogs, built with **ASP.NET Core** and **PostgreSQL**.

## Features

- CRUD operations for blog posts, categories, and comments
- RESTful API design
- Entity Framework Core integration
- PostgreSQL database support

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- Swagger (OpenAPI)

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)

### Setup

1. **Clone the repository:**
    ```bash
    git clone https://github.com/ShaviRajapaksha/Blog-Management-Backend-ASP.Net-Core-PostgreSQL.git
    cd Blog-Management-Backend-ASP.Net-Core-PostgreSQL
    ```

2. **Configure the database:**
    - Update the `appsettings.json` with your PostgreSQL connection string.

3. **Apply migrations:**
    ```bash
    dotnet ef database update
    ```

4. **Run the application:**
    ```bash
    dotnet run
    ```

5. **Access Swagger UI:**
    - Navigate to `http://localhost:5000/swagger` in your browser.

## API Endpoints

- `/api/posts` - Blog post management
- `/api/categories` - Category management
- `/api/comments` - Comment management

