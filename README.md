
# PersonAddress

This project consists of two main components: a Back-End developed in C# (.NET Core) and a Front-End built with Angular.

## Framework Version

### Back-End
- **C#**: .NET Core 6.0

### Front-End
- **Angular**: 15.x.x
- **Node.js**: 16.x.x (or any compatible version with Angular 15)

## Setup

### Prerequisites
Make sure you have the following tools installed:
- **Node.js** (https://nodejs.org/)
- **.NET Core SDK** (https://dotnet.microsoft.com/download)
- **Angular CLI** (install globally if not already installed):
    ```bash
    npm install -g @angular/cli
    ```

### Setting up the Back-End

1. **Navigate to the Back-End directory**  
   Open a terminal and navigate to the Back-End folder:
   ```bash
   cd Back-End
   ```

2. **Restore .NET dependencies**  
   Use the `dotnet` CLI to restore all required NuGet packages:
   ```bash
   dotnet restore
   ```

3. **Build the project**  
   Compile the Back-End project to ensure everything is set up correctly:
   ```bash
   dotnet build
   ```

4. **(Optional) Configure Environment Settings**  
   If your project requires any specific environment settings (such as database connections or API keys), create an `appsettings.Development.json` file in the `Back-End` folder. You can copy the existing `appsettings.json` and modify it as needed for your development environment.

### Setting up the Front-End

1. **Navigate to the Front-End directory**  
   Open a new terminal and navigate to the Front-End folder:
   ```bash
   cd Front-End
   ```

2. **Install Node.js dependencies**  
   Run the following command to install all the required Node.js packages listed in the `package.json` file:
   ```bash
   npm install
   ```

3. **(Optional) Configure Environment Settings**  
   If your project requires any specific environment configurations (like API base URLs), update the file `src/environments/environment.ts` or create a new environment file as necessary.

## How to Start

### Starting the Back-End

1. **Navigate to the Back-End directory**  
   Open a terminal and ensure you're in the Back-End folder:
   ```bash
   cd Back-End
   ```

2. **Run the application**  
   Start the .NET application using the `dotnet` CLI:
   ```bash
   dotnet run
   ```

   By default, the server will be hosted at `http://localhost:5267`. You can access the API endpoints using tools like Postman or through the browser (e.g., `http://localhost:5267/swagger` if Swagger is set up).

   **Note**: If your application has custom settings like ports, database connections, or other required services, make sure they are properly configured before running.

### Starting the Front-End

1. **Navigate to the Front-End directory**  
   Open a terminal and ensure you're in the Front-End folder:
   ```bash
   cd Front-End
   ```

2. **Serve the Angular application**  
   Use the Angular CLI to serve the app:
   ```bash
   ng serve
   ```

   By default, the Angular application will be available at `http://localhost:4200`.

   **Custom Port**: If you want to use a different port, add the `--port` option:
   ```bash
   ng serve --port 4300
   ```
