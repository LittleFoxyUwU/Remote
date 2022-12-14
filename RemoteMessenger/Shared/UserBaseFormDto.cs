using System.ComponentModel.DataAnnotations;

namespace RemoteMessenger.Shared;

public class UserBaseFormDto
{
    private string _username = string.Empty;

    [Required(ErrorMessage = "Требуется имя пользователя @example.")]
    [MaxLength(20, ErrorMessage = "Никнейм должен быть меньше или равен 20-ти симболам.")]
    public string Username
    {
        get => _username;
        set
        {
            if (value.Length == 0)
            {
                _username = "@";
                return;
            } 
            if (value[0] != '@') value = value.Insert(0, "@");
            _username = value.ToLower();
        }
    }
    
    [Required(ErrorMessage = "Требуется пароль.")]
    [MinLength(8, ErrorMessage = "Пароль должен состоять из 8-ми или более симболов.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}