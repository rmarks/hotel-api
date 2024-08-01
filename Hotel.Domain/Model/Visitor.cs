namespace Hotel.Domain.Model;

public class Visitor
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string IdCode { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public string Name => $"{FirstName} {LastName}";
}
