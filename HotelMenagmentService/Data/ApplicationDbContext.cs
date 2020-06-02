﻿using System;
using System.Collections.Generic;
using System.Text;
using HotelMenagmentService.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelMenagmentService.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Room>Rooms { get; set; }
        public DbSet<Guest>Guests { get; set; }
        public DbSet<Reservation>Reserevations { get; set; }
        public DbSet<ReservationHistory>ReservationHistoryItems { get; set; }
    }
}
