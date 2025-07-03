# UseCase Design Principles

Use cases are the building blocks of application logic. They represent single operations that the system can perform, such as creating or updating an entity. This document outlines the principles for designing use cases in a maintainable, testable, and scalable way.

## What is a Use Case?
- A use case is a single, focused operation that the system can execute (e.g., create a new entity, update an existing one).
- Each use case should have:
  - **Request**: The input data, ideally using Value Objects.
  - **Response**: The output/result of the operation.
  - **Handler**: The class that contains the business logic for the operation.

## Key Principles
- **Single Responsibility**: Each use case should do one thing and do it well.
- **Isolation**: Use cases should not depend on other use cases. If shared logic is needed, extract it into a service or utility class.
- **Validated Input**: Validation is the responsibility of the Presentation layer. The use case should receive only validated input, typically as Value Objects.
- **No Direct Validation**: The use case should not perform input validation. It should assume all inputs are valid.

## Rationale
- The data received by the presentation layer may not map directly to the domain model. By validating in the presentation layer and using Value Objects in the use case, we ensure that only valid data reaches the business logic.

---

## Good Example
// Request uses Value Objects, validation is done in the presentation layer
public record CreateUserRequest(UserName userName, Email email);

public class CreateUserHandler
{
    public CreateUserResponse Handle(CreateUserRequest request)
    {
        // ... use request.userName and request.email, which are already validated Value Objects
    }
}
## Bad Example
// Request uses primitive types, validation is done in the use case
public record CreateUserRequest(string userName, string email);

public class CreateUserHandler
{
    public CreateUserResponse Handle(CreateUserRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.userName))
            throw new ArgumentException("Username is required");
        if (!request.email.Contains("@"))
            throw new ArgumentException("Invalid email");
        // ...
    }
}
---

## Why This Approach Is Good
- **Separation of Concerns:** Validation is handled by the presentation layer, keeping use cases focused on business logic.
- **Reusability:** Value Objects encapsulate validation and domain rules, making them reusable across use cases.
- **Testability:** Use cases are easier to test because they assume valid input.
- **Maintainability:** Changes to validation rules are isolated from use case logic.

## Why Violating It Is Bad
- **Duplication:** Validation logic may be repeated in multiple use cases.
- **Tight Coupling:** Use cases become tightly coupled to input validation, making them harder to maintain.
- **Reduced Clarity:** Mixing validation and business logic makes code harder to read and reason about.
- **Difficult Testing:** Use cases must handle both validation and business logic, complicating tests.

---

## When to Choose This Approach
- Use this approach when you want clear separation between input validation and business logic.
- Prefer this when your domain model uses Value Objects and you want to enforce domain invariants consistently.
- Choose this when you want to maximize reusability and maintainability of both validation and business logic.

### When to Consider Other Approaches
- In very simple CRUD applications where domain logic is minimal, you may choose to validate in the use case for simplicity.
- If your application does not use Value Objects or has no domain layer, validation in the use case may be acceptable, but is not recommended for complex domains.

---

