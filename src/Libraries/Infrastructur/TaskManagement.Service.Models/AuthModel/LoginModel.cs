using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeWork.Service.Models.AuthModel;

public class LoginModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    [DefaultValue("admin@gmail.com")]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [DefaultValue("P@ssword1")]
    public string? Password { get; set; }

    public bool RememberMe { get; set; }
}
