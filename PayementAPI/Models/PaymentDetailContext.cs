using Microsoft.EntityFrameworkCore;

namespace PayementAPI.Models
{
    public class PaymentDetailContext : DbContext
    {
        public PaymentDetailContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PaymetDetails> PaymentDetails { get; set; } 
    }
}
