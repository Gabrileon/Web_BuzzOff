using Common.Interfaces;

namespace BuzzOff.Models
{
    public class UsersModel
    {
        public List<IUser> Users { get; set; } = new List<IUser>();
    }
}
