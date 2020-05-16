using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Streaming.WebApp.Models;

namespace Streaming.WebApp.Data
{
    public class StreamingWebAppContext : DbContext
    {
        public StreamingWebAppContext (DbContextOptions<StreamingWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<Streaming.WebApp.Models.User> User { get; set; }

        public DbSet<Streaming.WebApp.Models.Channel> Channel { get; set; }

        public DbSet<Streaming.WebApp.Models.Chat> Chat { get; set; }
    }
}
