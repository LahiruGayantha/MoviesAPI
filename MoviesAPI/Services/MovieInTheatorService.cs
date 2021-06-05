using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesAPI.Services
{
    public class MovieInTheatorService : IHostedService,IDisposable
    {
        private readonly IServiceProvider serviceProvider;
        private Timer Timer;

        public MovieInTheatorService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Dispose()
        {
            Timer.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Timer = new Timer(changeInTheator, null, TimeSpan.Zero, TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        private async void changeInTheator(object state)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var today = DateTime.Today;
                var movies = await context.Movies.Where(x => x.ReleaseDate == today).ToListAsync();
                if (movies.Any())
                {
                    foreach (var movie in movies)
                    {
                        movie.IsShowing = true;
                    }

                    await context.SaveChangesAsync();
                }
            }
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            Timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
