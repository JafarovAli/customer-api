namespace CustomerApi.Dtos;

public record GetCustomerDto(
    int Id,
    string FirstName,
    string LastName,
    string Email
);

