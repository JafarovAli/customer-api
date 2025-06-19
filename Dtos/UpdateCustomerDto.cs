namespace CustomerApi.Dtos;

public record UpdateCustomerDto(
    string? FirstName,
    string? LastName,
    string? Email
);