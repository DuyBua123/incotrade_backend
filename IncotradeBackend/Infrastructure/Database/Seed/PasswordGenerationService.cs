
using IncotradeBackend.Infrastructure.Database.Model;
using Microsoft.AspNetCore.Identity;

namespace IncotradeBackend.Infrastructure.Database.Seed
{
    public class PasswordGenerationService : IHostedService
    {
        private readonly PasswordHasher<User> _passwordHasher;

        public PasswordGenerationService(PasswordHasher<User> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            
            string plainPassword = "Test@123456";

            Console.WriteLine("=========GENERATING PASSWORD================");
            Console.WriteLine(_passwordHasher.HashPassword(null, plainPassword));
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}