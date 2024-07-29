# ToDo List Application

## Table of Contents

-   [Overview](#overview)
-   [Status](#status)
-   [Technology Stack](#technology-stack)
-   [Features](#features)
-   [Getting Started](#getting-started)
-   [Contributing](#contributing)
-   [Contact](#contact)

## Overview

This repository contains the code for a comprehensive, full-stack ToDo List application. It's designed with a mobile-first approach, ensuring a seamless experience across all platforms. Users can register and log in with their unique username and password, allowing them to access their data from any device. The app offers robust user authentication, including the ability to update passwords.

Key features of the ToDo List app include:

-   List Management: Users can create, update, and organize lists, which serve as group units for tasks. Each list has a title and an optional description.
-   Task Creation: Within each list, users can create tasks with customizable titles and descriptions.
-   Due Date Functionality: Tasks can have optional due dates. When a due date passes, the task automatically enters an overdue status.
-   Flexible Task Management: Users can modify task titles, descriptions, and due dates, or remove due dates entirely.
-   Dashboard: A comprehensive dashboard provides an overview of the user's productivity, displaying total task count, completed tasks, pending tasks, and overdue items.

This application showcases modern web development practices, incorporating React, .NET, SQL, and WebSockets. It's being developed using test-driven development (TDD) and behavior-driven development (BDD) methodologies, and is fully containerized using Docker.

## Status

✅ **Fully Functional and Deployed**

The ToDo List application is now fully developed and deployed. You can access the live version at [todo.yushi91.com](https://todo.yushi91.com).

Current status:

-   Main branch: Contains the stable, production-ready version of the application.
-   Development branch: Active development and polishing are ongoing in this branch.

We follow a structured development process:

1. New features and improvements are developed in the development branch.
2. Rigorous testing is performed on all changes.
3. Once tested and approved, changes are merged into the main branch.
4. The main branch is then deployed to the production environment.

Stay tuned for ongoing updates and improvements!

## Technology Stack

### Backend

-   .NET Core
-   Entity Framework Core for ORM
-   AutoMapper for object-object mapping

### Frontend

-   React
-   Redux for state management
-   TypeScript
-   Tailwind CSS for styling
-   DaisyUI for UI components
-   Redux Query for API request handling
-   Vite as build tool and development server

### Database

-   SQL Server

### CI/CD

-   GitHub Actions
-   Azure App Service CI/CD integration

### Authentication

-   JSON Web Tokens (JWT)
-   Cookie-based token storage

### Containerization

-   Docker
    -   Separate Dockerfiles for frontend and backend+database
    -   Docker Compose for orchestration
-   Makefile for running containerized applications

### Testing

-   NUnit
-   Moq for mocking in tests

### Cloud Infrastructure

-   Azure App Service
    -   Static Web Apps for frontend hosting
    -   Web Apps for backend hosting
-   Azure SQL Database

## Getting Started

The ToDo List application is live and ready to use! You can access it directly at:

[https://todo.yushi91.com](https://todo.yushi91.com)

Simply visit the URL to start using the application. You can create an account, log in, and begin managing your tasks right away.

### For Developers

If you're interested in running the project locally for development purposes, please follow these steps:

Prerequisites

-   Git
-   Docker

### Installing

unfinished yet

## Contributing

Since this is a personal project, contributing is currently not open. However, any feedback or suggestions are welcome. Please feel free to reach out to me.

## Contact

For any inquiries, feel free to contact me via realYushi@gmail.com

Thank you for your interest in this project!
