using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
           builder.HasData
            (
                new Client
                {
                    Id = 1,
                    FirstName = "Neal",
                    MiddleName = "",
                    LastName = "Mawditt",
                    PhoneNumber = "+867166746215",
                    Email = "neberdt0@sciencedirect.com"
                },
                new Client
                {
                    Id = 2,
                    FirstName = "Sydney",
                    MiddleName = "",
                    LastName = "Jeavon",
                    PhoneNumber = "+529112499711",
                    Email = "sorrey1@princeton.edu"
                },
                new Client
                {
                    Id = 3,
                    FirstName = "Octavia",
                    MiddleName = "",
                    LastName = "Kuhlmey",
                    PhoneNumber = "+866517274856",
                    Email = "oshakelade2@buzzfeed.com"
                },
                new Client
                {
                    Id = 4,
                    FirstName = "Maighdiln",
                    MiddleName = "",
                    LastName = "Bierling",
                    PhoneNumber = "+3528413440113",
                    Email = "mflack3@kickstarter.com"
                },
                new Client
                {
                    Id = 5,
                    FirstName = "Flossy",
                    MiddleName = "",
                    LastName = "Wooddisse",
                    PhoneNumber = "+2565212255733",
                    Email = "fhealks4@wunderground.com"
                }
            );
        }
    }
}
