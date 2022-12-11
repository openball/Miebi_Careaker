namespace Caretaker.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> op) : base(op) 
        {

        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<ApartmentType> ApartmentTypes { get; set; }
        public DbSet<BillingCategory> BillingCategories { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<NoticeBoard> NoticeBoards { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonCategory> PersonCategories { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
