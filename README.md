# URL Shortener

This is a simple URL Shortener web application built using ASP.NET Core MVC. The application allows users to create shortened URLs, manage their URLs via a dashboard, and redirect from shortened URLs to the original URLs.

## Features

- **URL Shortening**: Generate shortened URLs for long links.
- **User Authentication**: Simple email and password authentication using ASP.NET Core Identity.
- **Dashboard**: Manage your shortened URLs (view, delete).

## Technologies Used

- **ASP.NET Core MVC**: Web framework for building web applications.
- **ASP.NET Core Identity**: For user authentication and management.
- **SQLite**: Database engine.
- **Entity Framework** Core: Object-relational mapper (ORM) for interacting with SQLite database.
- **BCrypt.Net**: For password hashing.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or any preferred IDE.

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/naazeri/url-shortener.git
cd url-shortener
```

### 2. Set Up the Database

No setup is required for SQLite. The database exists in project files: `urlshortener.db`

### 3. Recreate Database (Optional)

```bash
dotnet ef database update
```

Since you are using Dapper, manual migrations are not required unless you've set up a custom process.

### 4. Run the Application

```bash
dotnet run
```

## Project Structure

- **Controllers**: Contains the logic to handle HTTP requests and responses.
- **Models**: Contains the data models used in the application.
- **Views**: Contains the Razor views for rendering HTML pages.
- **Services**: Contains services for handling URL shortening and user-specific logic.
- **Data**: Contains database context and related data classes.

## How to Use

1. **Register**(Optional): Create a new account using your email and password.
2. **Login**: Login with your credentials or defalut user: email: `admin@gmail.com` password: `Admin@123`
3. **Create a Short URL**: Navigate to the "Create" page and enter the original URL you want to shorten.
4. **View Your URLs**: Go to the dashboard to see your shortened URLs. You can also delete URLs from here.
5. **Redirect**: Access your shortened URLs by navigating to `https://localhost:5001/{shortUrl}`, which will redirect you to the original URL.

## Routes

- **/Account/Register**: User registration.
- **/Account/Login**: User login.
- **/Home/Create**: Create a new shortened URL.
- **/Home/Index**: View and manage your URLs.
- **/{shortUrl}**: Redirect to the original URL.

## Security

- Passwords are hashed using BCrypt for security.
- User authentication is required for creating and managing URLs.

## Contributing

Feel free to fork this repository, make changes, and submit a pull request. Contributions are welcome!

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
