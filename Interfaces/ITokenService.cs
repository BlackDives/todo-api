using todo_rest_api.Models;

namespace todo_rest_api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
