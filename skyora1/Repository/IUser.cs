using skyora1.Models;

namespace skyora1.Repository
{
    public interface IUser
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int empid);
        Task<int> AddUser(User user);
        Task<int> UpdateUser(int id, User user);
        Task<int> DeleteUser(int id);
    }
}
