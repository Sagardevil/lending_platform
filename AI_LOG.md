# 🤖 AI Usage & Development Log

AI tools were used as a development aid during the project for tasks such as understanding framework concepts, troubleshooting errors, reviewing implementation approaches, and improving documentation.

The final implementation was reviewed and adapted based on the project's requirements and testing results. AI-generated suggestions were not treated as final without verification.

## 1. Initial Backend Structure

**Prompt / Request:**

> "What is the basic structure of a C# ASP.NET Core Web API, and how should I organize controllers, models, interfaces, and services for a lending application?"

**Use of Output:**
Used the explanation to understand the separation between the controller, service layer, models, and interfaces before implementing the backend structure.

**Iteration:**
The initial suggestions were simplified and adapted to match the actual project requirements rather than adding unnecessary layers.

---

## 2. Lending Evaluation Logic

**Prompt / Request:**

> "Help me implement a lending decision engine based on loan amount, asset value, LTV, and credit score, including different rules for loans above and below £1 million."

**Use of Output:**
Used the suggested approach as a starting point for structuring the lending rules and LTV calculation.

**Questioned / Corrected:**
The boundary conditions were reviewed carefully, particularly:

* £1,000,000 loan threshold
* 60%, 80%, and 90% LTV boundaries
* Minimum and maximum loan amounts
* Required credit scores for different LTV ranges

The final conditions were adjusted to match the specified business rules rather than copying the generated logic directly.

---

## 3. API Controller and Service Separation

**Prompt / Request:**

> "How should the ASP.NET Core controller call a lending service while keeping business logic outside the controller?"

**Use of Output:**
Used this to structure the `LendingController` and `ILendingService` / `LendingService` relationship.

**Reason for Iteration:**
The controller was kept focused on receiving HTTP requests and returning responses, while the lending service handles the actual evaluation and metrics logic.

---

## 4. Thread Safety of In-Memory Data

**Prompt / Request:**

> "How can I safely maintain an in-memory list when multiple API requests may access it concurrently?"

**Use of Output:**
AI suggested synchronization around access to the shared collection.

**Questioned / Corrected:**
The approach was reviewed against the actual application's requirements. A locking mechanism was used around access to the shared application collection rather than introducing a more complex persistence solution for a project that currently uses in-memory storage.

---

## 5. Frontend–Backend Integration

**Prompt / Request:**

> "How should a React frontend send a loan application to an ASP.NET Core Web API and handle the response?"

**Use of Output:**
Used the guidance to understand the HTTP request/response flow between the React frontend and the lending API.

**Iteration:**
The request structure and API endpoint were aligned with the actual backend model and route used in the project.

---

## 7. README and Documentation Review

**Prompt / Request:**

> "Review and restructure the README so that the architecture, setup instructions, API endpoints, business rules, and future improvements are clearly documented."

**Use of Output:**
Used AI to improve the organization and readability of the documentation.

**Correction:**
The documentation was reviewed to distinguish between:

* Features currently implemented
* Architectural decisions made for the simulation
* Improvements that would be considered for a production version

This prevented future production ideas from being presented as already implemented features.

---

## 8. AI Output That Was Questioned

During development, some AI-generated suggestions were intentionally questioned instead of being accepted directly.

Examples included:

* Whether a database was necessary for the current simulation
* Whether additional architectural layers were justified
* Whether the LTV boundary conditions matched the assignment
* Whether thread synchronization was necessary for the in-memory collection
* Whether suggested package changes were compatible with the existing .NET setup

The implementation was kept focused on the requirements of the simulation, while more advanced suggestions were documented as potential future improvements where appropriate.

---

## Summary

AI was primarily used as a **development support and problem-solving tool** rather than as a replacement for implementation or decision-making.

The development process involved:

**Understand → Implement → Test → Question → Correct → Document**

The final code and project structure were reviewed against the required lending rules and the actual behaviour of the application.
