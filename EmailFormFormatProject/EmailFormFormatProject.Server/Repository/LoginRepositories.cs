namespace EmailFormFormatProject.Server.Repository
{
    public class LoginRepositories
    {
        private readonly ILogger<LoginRepositories> _logger;

        public LoginRepositories(ILogger<LoginRepositories> logger)
        {
            _logger = logger;
        }

        public Task<object> SignInAccess(string username, string password)
        {
            if (username == "masteradmin" && password == "MasterAdmin123!@")
            {
                return Task.FromResult<object>(new
                {
                    succeed = true,
                    data = new
                    {
                        name = "MASTER ADMIN",
                        userId = "masteradmin",
                        roleId = "master",
                        accessToken = "",
                        refreshToken = ""
                    },
                    error = "",
                });
            }
            return Task.FromResult<object>(new
            {
                succeed = false,
                data = "",
                error = new
                {
                    title = "LoginErr",
                    message = "Username and Password invalid. Please contact administrator.! "
                },
            });
        }
    }
}
