# TFGInfotecAssessment REST API

Welcome to the documentation for the TFGInfotecAssessment REST API! This API facilitates interactions with a cantina, providing various features for managing dishes, drinks, customer actions, and user authentication.

## Table of Contents

- [Features](#features)
- [Future Work](#future-work)
- [Database](#database)
- [Logging](#logging)

## Features

### Completed Work

- **AccountController Overview (Tested):**

#### Key Features:
  - **Sign Up:**
    - Creates a new user account.
  
  - **Sign In:**
    - Authenticates a user and generates a JWT token.

- **DishController & DrinkController Overview (Untested):**

#### Key Features for Dishes and Drinks:
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
  - Ensures secure operations with user authentication in both controllers.
  - Provides comprehensive management of accounts, dishes, and drinks.

- **Performance Optimization (Tested):**
  - Utilizes asynchronous programming to prevent blocking threads.
  - Implements dependency injection with scoped or transient lifetimes to optimize resource usage.

### Future Work

- **Performance Optimization:**
  - Implement caching mechanisms to store frequently accessed data in memory, reducing database calls.
  - Optimize database with indexes, query optimizations, and connection pooling.
  - Docker container optimization using slim images, resource limits, and multi-stage builds.

- **Review Management:**
  - Develop a dashboard for viewing reviews and ratings.
  - Introduce rate-limiting per logged-in customer to mitigate abuse.
  - Enable OAuth2-based Single Sign-On (SSO) such as Google for user login.

## Database

The TFGInfotecAssessment API utilizes a database within a Docker containerized environment. Below are essential files:

- **docker-compose.yml**: Docker Compose configuration.
- **Migration files**: Database seeding files.

The **ApplicationDbContext** constructor establishes a database connection using provided options. It verifies connectivity and creates the database if connection fails. Additionally, it ensures necessary tables are created if they do not exist, ensuring the database is ready for application use. Exceptions encountered are logged to the console for diagnostic purposes.

## Logging

The application is configured to log information. Currently, logging to the console is implemented. While logging to another platform would be preferable for production environments.

For detailed information on each API endpoint and interaction instructions, refer to the API documentation.
