﻿using Microsoft.EntityFrameworkCore;
using AppointmentBookingSystemWeb.Models;

namespace AppointmentBookingSystemWeb.Data
{
    public class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }
    }
}
