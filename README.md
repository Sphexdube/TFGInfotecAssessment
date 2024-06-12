# TFGInfotecAssessment REST API

Welcome to the documentation for the TFGInfotecAssessment REST API! This API is designed to facilitate interactions with a cantina, offering various features for managing dishes, drinks, customer actions, and user authentication.

## Table of Contents

- [Features](#features)
- [Future Work](#future-work)
- [Database](#database)
- [Logging](#logging)

## Features

### Done

- **Dish and Drink Management:**
  - Create, View, List, Update, and Delete dishes and drinks.
  - Each dish and drink must have a name, description, price, and image.

- **Customer Actions:**
  - Search, View, and Rate dishes & drinks.

- **User Authentication:**
  - Users can register and login.
  - Users have a name, email address, and password.

### Future Work

- **User Management:**
  - Implement user permissions and authentication support.
  - Require a logged-in user for all functionality except Registration.
  - Support password-based authentication.

- **Data Validation:**
  - Add validation to API data entities.
  - Implement defenses against brute force attacks.

- **Performance Optimization:**
  - Improve API performance on existing hardware.
  - Explore options for further performance enhancements beyond current hardware capabilities.

- **Review Management:**
  - Create a dashboard to view reviews and ratings.
  - Implement rate-limiting per logged-in customer to prevent abuse.
  - Allow users to login using OAuth2-based Single Sign-On (SSO) such as Google.

## Database

The TFGInfotecAssessment API uses a database in a containerized environment using Docker. Below are the necessary files:

- **docker-compose.yml**: Configuration for Docker Compose.
- **migration files**: Files for seeding the database.

## Logging

The application is configured for logging. While logging to another platform would be preferable, logging to the console is currently implemented.

For more details on each API endpoint and how to interact with them, refer to the API documentation.