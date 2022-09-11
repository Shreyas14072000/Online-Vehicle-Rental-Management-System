using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OVRMS.DomainLayer.Models;

namespace OVRMS.RepositoryLayer
{
    public class OVRMSDBContext : DbContext
    {
        public OVRMSDBContext(DbContextOptions options) : base(options)
        {


        }
        DbSet<Customers> Customers { get; set; }
        DbSet<BookingDetails> BookingDetails { get; set; }

        DbSet<Vehicles> Vehicles { get; set; }

        DbSet<Payment> Payment { get; set; }
        DbSet<Admin> Admin { get; set; }
    }
}
