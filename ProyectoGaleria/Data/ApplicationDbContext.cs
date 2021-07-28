using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoGaleria.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoGaleria.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Artista> Artista { get; set; }

        public DbSet<Contacto> Contacto { get; set; }

        
        
        
    }
}
