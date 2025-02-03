### CoffeeShopAPI

CoffeeShopAPI is a simple Web API built with .NET 9.0 for managing coffee shop data, including information about shop locations, hours, and ratings. This API allows users to interact with coffee shop data through various HTTP endpoints.

## Table of Contents

- [Installation](#installation)
- [EF Core and SQLite Integration](#ef-core-and-sqlite-integration)
- [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)
- [Testing the API](#testing-the-api)

---

## Installation

### Prerequisites

- **.NET 9.0 SDK**: Required to build the application. You can download it from the official .NET website:
  [Download .NET SDK](https://dotnet.microsoft.com/download/dotnet).

- **SQLite**: While the application uses SQLite for the database, there is no need for users to install SQLite manually. EF Core with the `Microsoft.EntityFrameworkCore.Sqlite` package will automatically handle the database connection and creation for you.

- **Entity Framework Core**: This application uses Entity Framework Core (EF Core) to manage database interactions. EF Core will automatically handle database migrations and the creation of the SQLite database file if it doesn’t already exist. The connection string used to connect to the database is configured in the application’s settings.

## EF Core and SQLite Integration

The application uses **Entity Framework Core (EF Core)** to interact with a **SQLite** database for storing coffee shop data. EF Core automatically manages the creation and updates of the SQLite database through migrations, so you don’t need to manually install or manage SQLite on your system.

Once you clone the repository and restore dependencies, you can run the following commands to create the initial database and apply migrations:

1. Add migrations (if needed):
   ```bash
   dotnet ef migrations add InitialCreate
   ```

2. Update the database (apply migrations):
   ```bash
   dotnet ef database update
   ```

This will create the SQLite database file and set up the schema for coffee shop data.

---

## Cloning the Repository

1. Clone the repository to your local machine:
   ```bash
   git clone https://github.com/sumirpv/CoffeeShopAPI
   ```

2. Navigate into the project directory:
   ```bash
   cd CoffeeShopAPI
   ```

3. Run the following command to restore the necessary dependencies:
   ```bash
   dotnet restore
   ```

## Running the Application

### Step 1: Publish the Application (for Standalone Executable)

To publish the application for multiple platforms, use the `publish.sh` script. This script will automatically handle the publishing process for Windows, Linux, and macOS and place all the executable files inside the `exes` folder.

- **For macOS or Linux**:
  ```bash
  chmod +x publish.sh
  ```

- **Run the publish.sh script**:
  ```bash
  ./publish.sh
  ```

The publishing process will generate standalone executable files for different platforms and compress them into the `/exes` folder for easy distribution.

### Step 2: Run the Executable

After publishing the application, follow these steps:

1. Navigate to the `dist` folder where the compressed file is located.
2. Decompress the file and open the extracted folder.

- **For Windows**:
  Double-click the `CoffeeShopAPI.exe` file or run it from the command prompt:
  ```bash
  CoffeeShopAPI.exe
  ```

- **For Linux/macOS**:
  Open a terminal, navigate to the folder, and run:
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

Once the application is running, you can test the API using tools like [Postman](https://www.postman.com/) , `curl` or directly via a browser.

### Using Curl

#### 1. **GET Request** (Retrieve all coffee shops):

```bash
curl --location --request GET 'http://localhost:5001/api/coffeeshops' \
--header 'Content-Type: application/json'
```

#### 2. **POST Request** (Create a new coffee shop):

```bash
curl --location --request POST 'http://localhost:5001/api/coffeeshops' \
--header 'Content-Type: application/json' \
--data '{
  "name": "Cafe Java",
  "openingTime": "08:00:00",
  "closingTime": "20:00:00",
  "location": "123 Java St, Java City",
  "rating": 4.5
}'
```

#### 3. **GET Request** (Retrieve a coffee shop by ID):

```bash
curl --location --request GET 'http://localhost:5001/api/coffeeshops/2' \
--header 'Content-Type: application/json'
```

Replace `2` with the desired coffee shop ID.

#### 4. **PUT Request** (Update a coffee shop):

```bash
curl --location --request PUT 'http://localhost:5001/api/coffeeshops/2' \
--header 'Content-Type: application/json' \
--data '{
  "name": "Updated Cafe Java",
  "openingTime": "09:00:00",
  "closingTime": "21:00:00",
  "location": "456 Updated St, Java City",
  "rating": 4.7
}'
```

#### 5. **DELETE Request** (Delete a coffee shop):

```bash
curl --location --request DELETE 'http://localhost:5001/api/coffeeshops/2' \
--header 'Content-Type: application/json'
```

### Accessing the API via Browser

You can directly access the API by visiting:

- **To retrieve all coffee shops**:
  ```bash
  http://localhost:5001/api/coffeeshops
  ```

- **To retrieve a specific coffee shop by ID**:
  ```bash
  http://localhost:5001/api/coffeeshops/{id}
  ```

Replace `{id}` with the actual coffee shop ID.

---