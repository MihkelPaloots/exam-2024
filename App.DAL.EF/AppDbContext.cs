using App.Domain;
using App.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid, IdentityUserClaim<Guid>, AppUserRole,
    IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>

{
    public DbSet<Country> Countries { get; set; } = default!;
    public DbSet<City> Cities { get; set; } = default!;
    public DbSet<UserSubject> UserSubjects { get; set; } = default!;
    public DbSet<Role> Roles { get; set; } = default!;
    public DbSet<Subject> Subjects { get; set; } = default!;
    public DbSet<UserSubjectHomework> UserSubjectHomeworks { get; set; } = default!;
    public DbSet<Homework> Homeworks { get; set; } = default!;
    
    public DbSet<AppRefreshToken> RefreshTokens { get; set; } = default!;

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}