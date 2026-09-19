# Blackfinch Lending Platform Simulation

A loan evaluation and analytics platform that automates lending decisions based on **loan amount, asset value, and credit score**.

The platform consists of a **.NET 8 ASP.NET Core Web API** backend and a **React.js** frontend. It evaluates loan applications against predefined lending criteria and provides platform-level lending metrics.

---

## 🏗️ Architecture & Technology Stack

| Layer             | Technology                          |
| ----------------- | ----------------------------------- |
| Backend           | C# ASP.NET Core Web API (.NET 8)    |
| Frontend          | React.js, JavaScript, CSS3          |
| Data Storage      | In-memory `List<ApplicationRecord>` |
| API Communication | REST API                            |
| Development Tools | Visual Studio / VS Code, Git        |

### High-Level Flow

```text
React Frontend
      │
      │ HTTP / REST API
      ▼
ASP.NET Core Web API
      │
      ▼
Lending Evaluation Service
      │
      ├── Loan Amount Validation
      ├── LTV Calculation
      ├── Credit Score Evaluation
      └── Approval / Decline Decision
      │
      ▼
In-Memory Application Store
```

---

## 🚀 Getting Started

### Prerequisites

Make sure the following are installed:

* [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
* [Node.js](https://nodejs.org/) (v16 or later recommended)
* npm (included with Node.js)

---

## 1. Run the Backend API

Open a terminal and navigate to the backend project:

```bash
cd LendingPlatform.API
```

Restore the required .NET dependencies:

```bash
dotnet restore
```

Start the API:

```bash
dotnet run
```

The backend will be available at:

```text
http://localhost:5270
```

---

## 2. Run the React Frontend

Open a **new terminal window** and navigate to the frontend directory:

```bash
cd lending-platform-ui
```

Install the required npm packages:

```bash
npm install
```

Start the React development server:

```bash
npm start
```

The frontend will be available at:

```text
http://localhost:3000
```

---

# ⚡ API Endpoints

| Method | Endpoint               | Description                                                    |
| ------ | ---------------------- | -------------------------------------------------------------- |
| `POST` | `/api/Lending/apply`   | Evaluates a loan application and returns the lending decision. |
| `GET`  | `/api/Lending/metrics` | Returns platform-level lending analytics.                      |

### `POST /api/Lending/apply`

Evaluates an application using:

* Loan Amount
* Asset Value
* Credit Score
* Calculated Loan-to-Value (LTV)

The endpoint returns the resulting lending decision based on the configured business rules.

### `GET /api/Lending/metrics`

Provides aggregate platform statistics, including:

* Total applications
* Approval rate
* Total value written
* Mean LTV

---

# 🏛️ Lending Decision Rules

The evaluation engine applies the following business criteria.

## General Loan Constraints

| Rule                | Requirement |
| ------------------- | ----------: |
| Minimum Loan Amount |    £100,000 |
| Maximum Loan Amount |  £1,500,000 |

The Loan-to-Value ratio is calculated as:

```text
LTV = (Loan Amount / Asset Value) × 100
```

---

## Loans of £1,000,000 or More

For applications where the loan amount is **£1,000,000 or greater**:

```text
LTV ≤ 60%
AND
Credit Score ≥ 950
```

Both conditions must be satisfied for the application to be approved.

---

## Loans Below £1,000,000

For applications below £1,000,000, the required credit score depends on the calculated LTV.

| LTV   | Minimum Credit Score |
| ----- | -------------------: |
| < 60% |                  750 |
| < 80% |                  800 |
| < 90% |                  900 |
| ≥ 90% |             Declined |

The applicable rule is determined from the application's LTV before making the final lending decision.

---

# 📊 Platform Analytics

The platform maintains application information in memory and uses it to calculate aggregate metrics.

The metrics endpoint can be used to monitor:

* Number of applications processed
* Number and percentage of approved applications
* Total value of approved lending
* Average/mean LTV across applications

---

# 💡 Architectural Decisions

### In-Memory Data Storage

For this simulation, application records are maintained using an in-memory collection:

```text
List<ApplicationRecord>
```

This keeps the implementation lightweight and avoids requiring an external database during development and demonstration.

### Thread Safety

Since multiple API requests may access the application collection concurrently, access to the shared collection is protected using locking:

```csharp
lock (_applications)
{
    // Access or update application records
}
```

This prevents concurrent requests from modifying or reading the shared state in an unsafe manner.

### Service-Based Architecture

The lending decision logic is separated from the API controller through a dedicated service layer.

This keeps the controller focused on handling HTTP requests while the service is responsible for:

* Validating applications
* Calculating LTV
* Applying lending rules
* Recording applications
* Calculating platform metrics

---

# 🔄 Production Considerations

The current implementation uses in-memory storage because this project is designed as a simulation.

For a production deployment, the persistence layer could be replaced with **Entity Framework Core** and a relational database such as:

* PostgreSQL
* SQL Server

A production implementation could additionally introduce:

* Persistent application history
* Database transactions
* Authentication and authorization
* Structured logging
* Centralized exception handling
* API validation
* Automated unit and integration tests
* Database migrations
* Monitoring and health checks

The lending evaluation service can remain largely independent of the persistence mechanism, allowing the storage implementation to evolve without changing the core decision logic.

---

# 📁 Project Structure

```text
LendingPlatform
│
├── LendingPlatform.API
│   ├── Controllers
│   │   └── LendingController.cs
│   │
│   ├── Models
│   │   ├── ApplicationRequest.cs
│   │   └── ApplicationRecord.cs
│   │
│   ├── Services
│   │   ├── ILendingService.cs
│   │   └── LendingService.cs
│   │
│   └── Program.cs
│
├── lending-platform-ui
│   ├── src
│   ├── public
│   └── package.json
│
└── README.md
```

> The exact structure may vary depending on the final project organization.

---

# 🧪 Testing the API

The API can be tested using tools such as **Postman** or directly through the React frontend.

Example application request:

```json
{
  "loanAmount": 500000,
  "assetValue": 800000,
  "creditScore": 850
}
```

The API calculates the LTV and evaluates the application against the applicable lending criteria.

---

# 📌 Project Purpose

The purpose of this project is to demonstrate the implementation of an automated lending decision engine with:

* Rule-based loan evaluation
* RESTful API design
* Separation of controller and business logic
* Concurrent in-memory state management
* Frontend-to-backend integration
* Lending analytics and metrics
* Considerations for future production persistence

---
