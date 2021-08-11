using System;
using TheUser.Business.Interfaces;

namespace TheUser.Business.Models
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
