# Printing Services Management System

## Overview

Printing Services Management System is a C# Windows Forms application that models a small print-shop workflow. The repository contains separate customer, manager, worker, and administrator screens, together with supporting SQL scripts and shared data classes.

## Features

- Customer request submission, request history, and profile screens
- Manager dashboards for reviewing requests and assigning work
- Worker task and profile screens
- Administrator views for users, customer reports, service reports, and yearly reports
- LocalDB-backed data access through the shared project classes and SQL scripts

## Tech Stack

- C#
- Windows Forms
- SQL Server LocalDB
- Visual Studio solution and project files

## Project Structure

- `OopFinalProject.sln` and `OopFinalProject.csproj` - solution and project entry files
- `Program.cs` - desktop application entry point
- `Form1.cs` - initial form launched by the application
- `Customer*.cs`, `Manager*.cs`, `Worker*.cs`, `Admin*.cs` - role-specific screens
- `UserData.cs` and `Requests.cs` - shared application data classes
- `SQLQuery*.sql` - supporting database scripts

## How to Run

1. Open `OopFinalProject.sln` in Visual Studio.
2. Make sure SQL Server LocalDB is available on the machine.
3. Create the required database objects using the bundled SQL scripts if they are not already present.
4. Build and run the project from Visual Studio.
