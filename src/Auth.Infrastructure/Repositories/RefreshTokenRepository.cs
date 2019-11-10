using Auth.Core.Entities;
using Auth.Core.Interfaces;
using Auth.Infrastructure.Data;

namespace Auth.Infrastructure.Repositories
{
    public class RefreshTokenRepository : BaseRepository<RefreshToken>, IRefreshTokenRepository
    {
        private readonly AppDbContext _context;

        public RefreshTokenRepository(AppDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}