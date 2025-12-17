
using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DBContext;

namespace eCommerce.Infrastructure.Repositories;
internal class UsersRepository : IUsersRepository
{
    private readonly DapperDBContext _dbContext;
    public UsersRepository(DapperDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        //Generate a new user id for the user
        user.UserID = Guid.NewGuid();
        string query = "INSERT INTO public.\"Users\"(\"UserID\", \"Email\", \"PersonName\", \"Password\", \"Gender\") VALUES(@UserID, @Email, @PersonName, @Password, @Gender)";
        int rowCountAffected=await _dbContext.DbConnection.ExecuteAsync(query, user);
        if (rowCountAffected > 0)
        {
            return user;
        }
        else return null;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        string query = "SELECT * FROM public.\"Users\" WHERE  \"Email\"= @Email AND \"Password\"= @Password";
        
        var parameters = new { Email=email, Password= password};
        var user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);
        return user;
    }
}

