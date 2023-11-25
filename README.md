# Leave Management System

Leave Management project is a .NET Core web application. When developing this application, it has used the following techniques.

- Connect to a Database using Entity Framework Core
- Use Repository and Unit Of Work Patterns and Dependency Injection
- Use the MVC (Models, Views, and Controllers) Pattern
- Apply C# and .Net Core Web Syntax
- Use user Authentication using ASP.NET Core Identity
- Use Models, ViewModels and AutoMapper
- Use Bootstrap to style and manipulate the overall layout
- Manage Packages with NuGet Manager

## To Configure For Local Use

- Clone Repository To Local Computer
- Open Project in Visual Studio
- Edit "DefaultConnection" to point to preferred database
- Open Package Console Manager and run the command "Update-Database"
- When completed, Run Website in Visual Studio to seed default Admin User
- Login as admin user using: Username: admin@localhost.com | Password: Password1234!

## Design Diagram

### Entity–relationship Diagram model

### Database diagram

## Overview

In many companies, Employee Leave Management systems can sometimes be taken into account retrospectively. Some use a paper-based system. Others mark the day in their calendars if they do so at all. This practice grows many issues, especially when asked from the employee’s point of view.

This system has the following features.

- Ability to apply for leave at any time of the day
- Employees can find out how many leaves are left
- It is easy to know whether his leave application was accepted or rejected
- The admin can easily find out how many leaves have been applied for
- The ability for the admin to allocate the leaves for all employees at once
- The admin can change the amount of leave of the employee

## Sample Videos:

### Admin View

### Employee View

## Packages

- AutoMapper
- automapper.extensions.microsoft.dependencyinjection
- microsoft.aspnetcore.diagnostics.entityframeworkcore
- microsoft.aspnetcore.identity.entityframeworkcore
- microsoft.aspnetcore.identity.UI
- microsoft.entityframeworkcore.sqlserver
- microsoft.entityframeworkcore.tools
- microsoft.visualstudio.web.codegeneration.design
