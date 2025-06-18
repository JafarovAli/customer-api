namespace CustomerApi.Dtos;

public record CreateCustomerDto(
    string FirstName,
    string LastName,
    string Email
);
