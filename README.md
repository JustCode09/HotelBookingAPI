#  HotelBookingAPI

A RESTful Web API built with ASP.NET Core 8 for 
managing hotel room bookings, featuring JWT 
authentication and PostgreSQL database.

## 🔗 Live Demo
[https://hotelbookingapi-1-qqoy.onrender.com/swagger](https://hotelbookingapi-1-qqoy.onrender.com/swagger)

> Note: Free tier may take ~50 seconds to wake up 
> on first request after inactivity.

##  Tech Stack
- ASP.NET Core 8
- Entity Framework Core 8
- PostgreSQL
- JWT Authentication
- BCrypt (password hashing)
- Docker
- Swagger UI

##  Features
- User Registration & Login with JWT
- Password hashing with BCrypt
- Room Management (CRUD)
- Booking System (Create/Cancel)
- Protected endpoints with `[Authorize]`
- Async/Await throughout
- Deployed on Render with Docker

##  Project Structure
```
HotelBookingAPI
├── Controllers
│   ├── AuthController.cs
│   ├── RoomController.cs
│   └── BookingController.cs
├── Models
│   ├── User.cs
│   ├── Room.cs
│   └── Booking.cs
├── DTOs
│   ├── RegisterDTO.cs
│   ├── LoginDTO.cs
│   └── UserDTO.cs
├── Services
│   ├── IAuthService.cs / AuthService.cs
│   ├── IRoomService.cs / RoomService.cs
│   └── IBookingService.cs / BookingService.cs
├── Helpers
│   └── JwtHelper.cs
├── Data
│   └── AppDbContext.cs
├── Dockerfile
└── Program.cs
```

##  Run Locally
1. Clone the repo
2. Update connection string in `appsettings.json`
3. Run `Update-Database` in Package Manager Console
4. Press F5

##  API Endpoints

### 🔐 Auth
- `POST` api/auth/register
- `POST` api/auth/login

### 🏨 Rooms
- `GET` api/room
- `GET` api/room/{id}
- `POST` api/room 🔒
- `PUT` api/room/{id} 🔒
- `DELETE` api/room/{id} 🔒

###  Bookings (all 🔒 require login)
- `GET` api/booking
- `GET` api/booking/{id}
- `POST` api/booking
- `DELETE` api/booking/{id}

🔒 = requires JWT token (Authorize button in Swagger)

##  Author
[@JustCode09](https://github.com/JustCode09)