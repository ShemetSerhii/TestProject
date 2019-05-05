using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public static class DataInitializer
    {
        public static void AddInitData(this ModelBuilder modelBuilder)
        {
            var clients = new Client[]
            {
                new Client
                {
                    Id = 1,
                    FirstName = "Tom",
                    LastName = "Taylor",
                    Address = "Kharkiv",
                    PhoneNumbers = "124124124; 214124142",
                    Tasks = new List<ClientTask>()
                },
                new Client
                {
                    Id = 2,
                    FirstName = "Alice",
                    LastName = "Baker",
                    Address = "Kyiv",
                    PhoneNumbers = "112412; 14214",
                    Tasks = new List<ClientTask>()
                },
                new Client
                {
                    Id = 3,
                    FirstName = "Sam",
                    LastName = "Porter",
                    Address = "Kharkiv",
                    PhoneNumbers = "124142; 124124",
                    Tasks = new List<ClientTask>()
                },
                new Client
                {
                    Id = 4,
                    FirstName = "Peter",
                    LastName = "Walker",
                    Address = "Kyiv",
                    PhoneNumbers = "12412; 214124",
                    Tasks = new List<ClientTask>()
                }
            };

            var tasks = new ClientTask[]
            {
                new ClientTask
                {
                    Id = 1,
                    Name = "Name",
                    Description = "Description",
                    ClientAddress = "Kharkiv",
                    StartTime = DateTime.UtcNow.AddHours(-1),
                    EndTime = DateTime.UtcNow,
                    ClientId = 1
                },
                new ClientTask
                {
                    Id = 2,
                    Name = "Name",
                    Description = "Description",
                    ClientAddress = "Kyiv",
                    StartTime = DateTime.UtcNow.AddHours(-1),
                    EndTime = DateTime.UtcNow,
                    ClientId = 2
                },
                new ClientTask
                {
                    Id = 3,
                    Name = "Name",
                    Description = "Description",
                    ClientAddress = "Kharkiv",
                    StartTime = DateTime.UtcNow.AddHours(-1),
                    EndTime = DateTime.UtcNow,
                    ClientId = 3
                },
                new ClientTask
                {
                    Id = 4,
                    Name = "Name",
                    Description = "Description",
                    ClientAddress = "Kyiv",
                    StartTime = DateTime.UtcNow.AddHours(-1),
                    EndTime = DateTime.UtcNow,
                    ClientId = 4
                }
            };

            modelBuilder.Entity<Client>().HasData(clients);
            modelBuilder.Entity<ClientTask>().HasData(tasks);
        }
    }
}
