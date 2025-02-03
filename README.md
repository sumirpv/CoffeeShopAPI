# CoffeeShopAPI

CoffeeShopAPI is a simple Web API built with .NET 9.0 for managing coffee shop data, including information about shop locations, hours, and ratings. This API allows users to interact with coffee shop data through various HTTP endpoints.

## Table of Contents

- [Installation](#installation)
- [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)
- [Testing the API](#testing-the-api)
- [License](#license)

---

## Installation

### Prerequisites

- **.NET 9.0 SDK**: Required to build the application. You can download it from the official .NET website:
  [Download .NET SDK](https://dotnet.microsoft.com/download/dotnet).

- **SQLite**: The application uses SQLite as the database for storing coffee shop data.

### Cloning the Repository

1. Clone the repository to your local machine:
   ```bash
   git clone https://github.com/yourusername/CoffeeShopAPI.git
   ```

2. Navigate into the project directory:
   ```bash
   cd CoffeeShopAPI
   ```

### Install Dependencies

Run the following command to restore the necessary dependencies:

```bash
dotnet restore
```

---

## Running the Application

### Step 1: Publish the Application (for Standalone Executable)

If you want to run the application as a standalone executable, use the `dotnet publish` command.

- **For Windows**:
  ```bash
  dotnet publish -c Release -r win-x64 --self-contained
  ```

- **For Linux**:
  ```bash
  dotnet publish -c Release -r linux-x64 --self-contained
  ```

- **For macOS**:
  ```bash
  dotnet publish -c Release -r osx-x64 --self-contained
  ```

This will generate the executable in the `bin/Release/net9.0/<platform>/publish` directory.

### Step 2: Run the Executable

After publishing the application, navigate to the `publish` folder and run the executable.

- **For Windows**:
  Double-click the `CoffeeShopAPI.exe` file or run it from the command prompt:
  ```bash
  CoffeeShopAPI.exe
  ```

- **For Linux/macOS**:
  Open a terminal and run:
  ```bash
  ./CoffeeShopAPI
  ```

---

## API Endpoints

### GET `/api/coffeeshops`

Retrieves all coffee shops in the database.

**Response**:
- `200 OK` – A list of all coffee shops.

### GET `/api/coffeeshops/{id}`

Retrieves a coffee shop by its ID.

**Request Parameters**:
- `id` – The ID of the coffee shop.

**Response**:
- `200 OK` – The coffee shop details.
- `404 Not Found` – If no coffee shop with the given ID exists.

### POST `/api/coffeeshops`

Creates a new coffee shop.

**Request Body**:
```json
{
  "name": "Coffee Shop Name",
  "openingTime": "08:00:00",
  "closingTime": "20:00:00",
  "location": "Coffee Shop Location",
  "rating": 4.5
}
```

**Response**:
- `201 Created` – The coffee shop was created successfully.
- `400 Bad Request` – If the request data is invalid.

---

## Testing the API

You can test the API using tools like [Postman](https://www.postman.com/) or `curl`.

**Example `curl` request to create a new coffee shop**:

```bash
curl -X POST https://localhost:5001/api/coffeeshops \
     -H "Content-Type: application/json" \
     -d '{
           "name": "Cafe Java",
           "openingTime": "08:00:00",
           "closingTime": "20:00:00",
           "location": "123 Java St, Java City",
           "rating": 4.5
         }'
```

---

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

This README should help users understand how to install and run the application, as well as provide details on the API endpoints they can interact with.

