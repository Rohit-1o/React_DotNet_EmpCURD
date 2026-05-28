# React DotNet EmpCURD

This repository contains a full-stack CRUD application built with:

- ASP.NET Core Web API backend (`02Web_Project`)
- React frontend using Vite (`ReactApplication/client_to_api`)
- SQL Server LocalDB database for employee data

## Project Description

The app manages employee records with operations to:

- List employees
- Add new employee records
- Update existing employees
- Delete employees

The React frontend calls the ASP.NET backend API to perform CRUD operations on the `Emp` table.

## Folder Structure

- `02Web_Project` - ASP.NET Core backend project
- `ReactApplication/client_to_api` - React frontend project

## Requirements

- .NET 10 SDK
- Node.js and npm
- SQL Server LocalDB (usually installed with Visual Studio or SQL Server tools)

## Setup & Run

### 1. Backend

Open a terminal in `D:\React_DotNet_(EmpCURD)\02Web_Project` and run:

```powershell
dotnet run
```

This starts the backend API on `http://localhost:5032`.

### 2. Frontend

Open another terminal in `D:\React_DotNet_(EmpCURD)\ReactApplication\client_to_api` and run:

```powershell
npm install
npm run dev
```

This starts the frontend on `http://localhost:5174`.

### 3. Open the App

Open your browser at:

```text
http://localhost:5174
```

The frontend will call the backend API at:

```text
http://localhost:5032/api/Values
```

## Notes

- The backend uses SQL Server LocalDB and the connection string is stored in `02Web_Project/appsettings.json`.
- If the database does not exist, create it manually or use the existing EF migrations in `02Web_Project/Migrations`.
- The frontend source file for the dashboard is `ReactApplication/client_to_api/src/dashboard.jsx`.

## GitHub Repo

Published to: `https://github.com/Rohit-1o/React_DotNet_EmpCURD`
