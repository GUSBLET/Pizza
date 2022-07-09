
namespace Pizza.Sourse
{
    public class TableUsers
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime CreateAt { get; set; }
    }

    public class TabelUsersEntityTypeConfiguration : IEntityTypeConfiguration<TableUsers>
    {
        public void Configure(EntityTypeBuilder<TableUsers> builder)
        {
            builder
                .ToTable("Users");
            builder
                .HasKey(x => x.Id);
            builder
                .Property(x => x.Login)
                .HasColumnName("Login")
                .IsRequired();
            builder
                .Property(x => x.Password)
                .HasColumnName("Password")
                .IsRequired();
            builder
                .Property(x => x.CreateAt)
                .IsRequired()
                .HasColumnName("CreateAt")
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");
                
        }
    }
}
