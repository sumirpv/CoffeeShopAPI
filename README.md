# CoffeeShopAPI

CoffeeShopAPI is a simple Web API built with .NET 9.0 for managing coffee shop data, including information about shop locations, hours, and ratings. This API allows users to interact with coffee shop data through various HTTP endpoints.

## Table of Contents

- [Installation](#installation)
- [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)
- [Testing the API](#testing-the-api)

---

## Installation

### Prerequisites

- **.NET 9.0 SDK**: Required to build the application. You can download it from the official .NET website:
  [Download .NET SDK](https://dotnet.microsoft.com/download/dotnet).

- **SQLite**: The application uses SQLite as the database for storing coffee shop data.

### Cloning the Repository

1. Clone the repository to your local machine:
   ```bash
   git clone https://github.com/sumirpv/CoffeeShopAPI
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

To publish the application for multiple platforms, use the publish.sh script. This script will automatically handle the publishing process for Windows, Linux, and macOS and place all the executable files inside the exes folder.

- **For macOS or Linux**:
  ```bash
  chmod +x publish.sh
  ```

- **Run the publish.sh script:**:
  ```bash
   ./publish.sh
  ```

The publishing process will generate standalone executable files for different platforms and compress them into the `/exes` folder for easy distribution.

Here’s an enhanced version of your instructions:

---

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

## Using Curl

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

## Accessing the API via Browser

You can directly access the API by visiting:

```bash
https://localhost:5001/api/coffeeshops
http://localhost:5001/api/coffeeshops/2
```


---
