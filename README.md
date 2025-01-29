# Hotel-Reservation-API
A comprehensive system for managing hotel reservations, dynamically calculating costs based on seasonality, and ensuring capacity constraints. Developed using ASP.NET Core and Entity Framework.

### `CalculateReservationCostAsync` Method

**Purpose**:
Calculates the total cost of a hotel stay based on multiple factors including the stay duration, room type, and meal plan, adjusting for seasonal pricing variations.

**Parameters**:
- `checkIn` (DateOnly): The check-in date of the reservation.
- `checkOut` (DateOnly): The check-out date of the reservation.
- `numberOfGuests` (int): The total number of guests included in the reservation.
- `roomTypeId` (int): Identifier for the type of room booked.
- `mealPlanId` (int): Identifier for the chosen meal plan.

**Returns**: 
- Returns the total cost of the stay as a `decimal`.

**Exceptions**:
- `ArgumentNullException`: Thrown if the specified room type or meal plan does not exist.
- `ArgumentException`: Thrown if the number of guests exceeds the room's capacity.
