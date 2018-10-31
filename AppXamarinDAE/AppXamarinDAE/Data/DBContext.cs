using System;
using System.Collections.Generic;
using System.Text;
using AppXamarinDAE.Models;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace AppXamarinDAE.Data
{
    public class DBContext : DbContext
    {
        private readonly string FicDataBasePath;

        public DBContext(string FicPaDataBasePath)
        {
            FicDataBasePath = FicPaDataBasePath;
            FicMetCrearDB();
        }

        private async void FicMetCrearDB()
        {
            try
            {
                //FIC: Se crea la base de datos en base el esquema
                await Database.EnsureCreatedAsync();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }

        }//ESTE METODO CREA LA BASE DE DATOS

        protected async override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlite($"Filename={FicDataBasePath}");
                optionsBuilder.EnableSensitiveDataLogging();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//CONFIGURACION DE LA CONEXION

        public DbSet<Eva_cat_edificios> eva_cat_edificios { get; set; }
        public DbSet<Eva_cat_espacios> eva_cat_espacios { get; set; }

        protected async override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                modelBuilder.Entity<Eva_cat_espacios>()
                    .HasKey(c => new { c.IdEdificio, c.IdEspacio });

                modelBuilder.Entity<Eva_cat_edificios>()
                    .HasKey(c => new { c.IdEdificio });

                /*modelBuilder.Entity<Eva_cat_espacios>()
                    .HasOne(s => s.).
                    WithMany().HasForeignKey(s => s.);*/
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }
    }
}
