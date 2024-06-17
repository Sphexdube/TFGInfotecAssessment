# TFGInfotecAssessment REST API

Welcome to the documentation for the TFGInfotecAssessment REST API! This API is designed to facilitate interactions with a cantina, offering various features for managing dishes, drinks, customer actions, and user authentication.

## Table of Contents

- [Features](#features)
- [Future Work](#future-work)
- [Database](#database)
- [Logging](#logging)

## Features

### Done

- **AccountController Overview (Tested):**

- **Key Features:**
  - **Sign Up:**
    - Creates a new user account.

  - **Sign In:**
    - Authenticates a user and generates a JWT token.

- **DishController & DrinkController Overview (Untested):**

- **Key Features for Dishes and Drinks:**
  - **Search Items:**
    - Retrieve items (dishes or drinks) based on a search query or get all items if no query is provided.
  - **Add an Item:**
    - Create a new item (dish or drink) (requires authentication).
  - **Get Item Details:**
    - Retrieve details of a specific item (dish or drink) by ID.
  - **Update an Item:**
    - Update an existing item (dish or drink).
  - **Delete an Item:**
    - Delete an item (dish or drink) by its ID.
  - **Get Reviews for an Item:**
    - Retrieve all reviews for a specific item (dish or drink).
  - **Add a Review for an Item:**
    - Add a review for an item (dish or drink) (requires authentication).

- **Security and Functionality (Tested):**
  - Both controllers ensure secure operations with user authentication and provide comprehensive management of account, dishes and drinks.

- **Performance Optimization (Tested):**
  - Asynchronous Programming: Ensure your API uses async/await where appropriate to prevent blocking threads
  - Dependency Injection: Use scoped or transient lifetimes appropriately to avoid long-lived dependencies that may consume resources unnecessarily.

### Future Work

- **Performance Optimization:**
  - Caching: Implement caching mechanisms to store frequently accessed data in memory, reducing database calls.
  - Database Optimization: Indexes, Query Optimization & Connection Pooling.
  - Docker Container Optimization: Slim Images, Resource Limits & Multi-stage Builds

- **Review Management:**
  - Create a dashboard to view reviews and ratings.
  - Implement rate-limiting per logged-in customer to prevent abuse.
  - Allow users to login using OAuth2-based Single Sign-On (SSO) such as Google.

## Database

The TFGInfotecAssessment API uses a database in a containerized environment using Docker. Below are the necessary files:

- **docker-compose.yml**: Configuration for Docker Compose.
- **migration files**: Files for seeding the database.

The constructor in **ApplicationDbContext** establishes a database connection using provided options. 
It attempts to verify connectivity and creates the database if connection fails. 
Additionally, it creates necessary tables if they do not already exist, ensuring the database is ready for application use. 
Any encountered exceptions are logged to the console for diagnostic purposes.

## Logging

The application is configured for logging. While logging to another platform would be preferable, logging to the console is currently implemented.

For more details on each API endpoint and how to interact with them, refer to the API documentation.