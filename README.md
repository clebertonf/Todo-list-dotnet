# Todo API

A task management API developed with a **clean architecture** approach, designed to provide scalable and maintainable solutions for handling tasks and categories.

---

## Features

### Categories
- **GET /api/categories**  
  Retrieve all categories.
  
- **GET /api/categories/{id}**  
  Retrieve a specific category by its ID.
  
- **POST /api/category**  
  Create a new category.
  
- **PUT /api/category**  
  Update an existing category.
  
- **DELETE /api/category/{id}**  
  Delete a category by its ID.

### Tasks
- **GET /api/tasks**  
  Retrieve all tasks.
  
- **GET /api/tasks/{id}**  
  Retrieve a specific task by its ID.
  
- **POST /api/task**  
  Create a new task.
  
- **PUT /api/task**  
  Update an existing task.
  
- **DELETE /api/task/{id}**  
  Delete a task by its ID.

---

## Project Structure

The solution is built with a **clean architecture** pattern and follows the principles of separation of concerns. Below is an overview of the project's key layers:

1. **Todo.API**  
   The API layer that handles HTTP requests and responses.

2. **Todo.Application**  
   Contains application-specific business rules and use cases.

3. **Todo.Domain**  
   Defines core entities, interfaces, and domain logic.

4. **Todo.Infra.Data**  
   Implements data persistence and repository logic.

5. **Todo.Infra.IoC**  
   Manages dependency injection and service configurations.

6. **Todo.Tests**  
   Includes unit tests to ensure code reliability and functionality.
