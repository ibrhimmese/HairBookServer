using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.RolBasedAccessControlEntities;

public sealed class User:IdentityUser<string>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string RefreshToken { get; set; }
    public DateTime? RefreshTokenExpires { get; set; }
    public DateTime CreatedDate { get; set; }
   // public DateTime? UpdatedDate { get; set; }
    public string FullName => string.Join(" ", FirstName, LastName);


    public User()
    {
        Id = new Guid().ToString();
        FirstName = string.Empty;
        LastName = string.Empty;
        RefreshToken = string.Empty;
    }
    public User(string id, string firstName, string lastName, string refreshToken)
    {
        Id= id;
        FirstName= firstName;
        LastName = lastName;
        RefreshToken= refreshToken;
    }
  
}
