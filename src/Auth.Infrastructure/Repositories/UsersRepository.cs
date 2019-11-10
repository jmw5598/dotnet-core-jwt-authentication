using Auth.Core.Entities;
using Auth.Core.Interfaces;
using Auth.Infrastructure.Data;

namespace Auth.Infrastructure.Repositories
{
    public class UsersRepository : BaseRepository<User>, IUsersRepository
    {
        private readonly AppDbContext _context;

        public UsersRepository(AppDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}