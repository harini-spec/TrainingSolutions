# Day 21
## Hotel Booking System

This ERD was developed using pair programming methodology. One, the driver, writes code while the other, the observer or navigator, reviews each line of code as it is typed in. The two programmers **SWITCH ROLES** frequently.

- Colaborated with
[@JaivigneshJv](https://github.com/JaivigneshJv)
[[repo](https://github.com/JaivigneshJv/GenSpark)]


### Entities

The entities in this system and their attributes are as follows:

- **Rooms**: Id, Name, Type, Occupancy Capacity, Nightly rate, DiscountPercentage
- **Guests**: Id, Name, Phone No, Email, Loyalty points, List<Reservations>
- **Reservation**: Id, Room Id, Guest Id, CheckIn Date, Checkout Date, Occupancy Count, Cancellation Policy, Total cost, Discount
- **Feedback**: Id, Guest Id, Reservation Id, Feedback, Rating, Feedback Date
- **Features**: Id, Feature
- **Guest Features**: Guest Id, Features Id
- **Room Features**: Room Id, Feature Id

### Entity Relationship Diagram (ERD)

![ERD](/Day21/Assets/HotelManagement-ERD.png)


## Employee Request Tracker
#### 1. User Registration
![ERD](/Day21/Assets/01_Register.png)
#### 2. User Login
![ERD](/Day21/Assets/02_UserLogin.png)
#### 3. User Request Menu
![ERD](/Day21/Assets/03_UserRequestMenu.png)
#### 4. Admin Login
![ERD](/Day21/Assets/04_AdminLogin.png)
#### 5. Admin Request Menu
![ERD](/Day21/Assets/05_AdminRequestMenu.png)
![ERD](/Day21/Assets/06_AdminRequestMenu.png)