# Car Rental API
#### A comprehensive Car Rental System API built with C#, Entity Framework, and JWT authentication.
---


## Models

1. **Car**
   - Properties: `Id`, `Make`, `Model`, `Year`, `PricePerDay`, `IsAvailable`
2. **User**
   - Properties: `Id`, `Name`, `Email`, `Password`, `Role` (Admin/User)
3. **Rental**
   - Properties: `Id`, `CarId`, `UserId`, `RentalDate`, `RentalDays`

---

## Services

1. **AuthService**: Manages JWT authentication.
2. **CarRentalService**: Core business logic for renting cars.
   - Methods: `RentCar`, `CheckCarAvailability`
3. **UserService**: Handles user registration and authentication.
4. **EmailService**: Sends email notifications.
5. **NotificationService**: Integrates with external email providers like SendGrid.

---

## Screenshots 
Please check the screenshot folder: [Here](https://github.com/tanishqj-19/Car-Rental-API/tree/master/CarRentalScreenshots)
## Repositories

1. **CarRepository**:
   - Methods: `AddCar`, `GetCarById`, `GetAvailableCars`, `UpdateCarAvailability`,  `Rent Car `
2. **UserRepository**:
   - Methods: `AddUser`, `GetUserByEmail`, `GetUserById`

---

## Controllers

1. **Car Controller**
   - Endpoints:
     - `GET /cars` - List available cars.
     - `POST /cars` - Add a new car.
     - `PUT /cars/{id}` - Update car details.
     - `DELETE /cars/{id}` - Delete a car.
     - `POST /cars/rend/{carId}`
2. **User Controller**
   - Endpoints:
     - `POST /users/register` - Register a new user.
     - `POST /users/login` - Log in to receive a JWT token.

---

## Authentication and Authorization

- **JWT Authentication**: Secures the API using JWT tokens.
- **Role-based Authorization**:
  - Admin: Manage cars.
  - User: Rent cars and view their rental history.

---

## Notification System

Uses **Gmaill SMTP** for email notifications to inform users when:
- A car booking is successfully completed.
- Emails include car details, rental duration, and user information.

---

## API Endpoints

| Endpoint            | Method | Description                       | Access  |
|---------------------|--------|-----------------------------------|---------|
| `/cars`             | GET    | Get available cars                | Public  |
| `/cars`             | POST   | Add a new car                     | Admin   |
| `/cars/rent/{carId}`| POST   | Rent a car and email conformation | Public  |
| `/cars/{id}`        | PUT    | Update car details                | Admin   |
| `/cars/{id}`        | DELETE | Delete a car                      | Admin   |
| `/users/register`   | POST   | Register a new user               | Public  |
| `/users/login`      | POST   | Authenticate user and get a token | Public  |


---
