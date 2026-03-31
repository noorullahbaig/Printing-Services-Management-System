# Printing Services Management System

Desktop-based C# Windows Forms application for managing a printing service workflow. The project includes customer, manager, worker, and admin views for handling requests, task assignment, reporting, and user management.

## Features

- Customer request submission and request tracking
- Manager dashboards and task assignment workflows
- Worker task views and status updates
- Administrative reporting and user management
- SQL-backed data access through LocalDB

## Tech Stack

- C#
- Windows Forms
- SQL Server LocalDB
- Visual Studio solution/project structure

## Project Files

- `OopFinalProject.sln` / `OopFinalProject.csproj` - Visual Studio solution and project
- `Program.cs` - application entry point
- `UserData.cs` - user/data access model
- `SQLQuery*.sql` - supporting database scripts
- `*.Designer.cs`, `*.resx` - Windows Forms UI components

## Run

1. Open `OopFinalProject.sln` in Visual Studio.
2. Ensure SQL Server LocalDB is available.
3. Create or restore the required database objects using the included SQL scripts if needed.
4. Build and run the Windows Forms application from Visual Studio.
