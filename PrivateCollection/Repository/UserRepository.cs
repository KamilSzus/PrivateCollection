using Microsoft.AspNetCore.Identity;
using PrivateCollection.Data;
using PrivateCollection.Interfaces;
using PrivateCollection.Models;

namespace PrivateCollection.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PrivateCollectionContext Context;
        private readonly UserManager<User> UserManager;

        public UserRepository(PrivateCollectionContext context, UserManager<User> userManager)
        {
            this.Context = context;
            this.UserManager = userManager;
        }


    }
}
