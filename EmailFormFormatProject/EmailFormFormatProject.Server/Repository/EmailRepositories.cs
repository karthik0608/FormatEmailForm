namespace EmailFormFormatProject.Server.Repository
{
    public class EmailRepositories
    {
        private readonly ILogger<EmailRepositories> _logger;
        
        public EmailRepositories(ILogger<EmailRepositories> logger)
        {
            _logger = logger;
        }

        public bool SendEmail()
        {
            return false;
        }
    }
}
