namespace Ordering.Domain.ValueObjects;

public record Address
{
    public string FirstName { get; }
    public string LastName { get; }
    public string? EmailAddress { get; }
    public string AddressLine { get; }
    public string Country { get; }
    public string State { get; }
    public string ZipCode { get; }

    private Address(
        string firstName,
        string lastName,
        string emailAddress,
        string addressLine,
        string country,
        string state,
        string zipCode
    )
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        AddressLine = addressLine;
        Country = country;
        State = state;
        ZipCode = zipCode;
    }

    public static Address Of(
        string firstName,
        string lastName,
        string emailAddress,
        string addressLine,
        string country,
        string state,
        string zipCode
    )
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName, nameof(firstName));
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName, nameof(lastName));
        ArgumentException.ThrowIfNullOrWhiteSpace(addressLine, nameof(addressLine));
        ArgumentException.ThrowIfNullOrWhiteSpace(country, nameof(country));
        ArgumentException.ThrowIfNullOrWhiteSpace(state, nameof(state));
        ArgumentException.ThrowIfNullOrWhiteSpace(zipCode, nameof(zipCode));

        return new Address(firstName, lastName, emailAddress, addressLine, country, state, zipCode);
    }
}
