using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Via.Movies.Api.Data;
using Via.Movies.Api.Models;
using Via.Movies.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddDbContext<ViaMoviesDbContext>(opt =>
    {
        opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

builder.Services.AddControllers();
builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowMyApp",
            builder => builder.WithOrigins("http://localhost:4200") 
                              .AllowAnyHeader()
                              .AllowAnyMethod());
    });
builder.Services.AddDbContext<IdentityDbContext>(opt =>
{
   opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 8;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Lockout.MaxFailedAccessAttempts = 100;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    opt.User.RequireUniqueEmail = true;
    opt.SignIn.RequireConfirmedEmail = false;
})
// Tell the identity system to use this particular db context to store users.
.AddEntityFrameworkStores<IdentityDbContext>()
// We're telling identity to use the default token providers e.g. when
// generation an email confirmation token.
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Account/Login";
    opt.AccessDeniedPath = "/Account/AccessDenied";
});


builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IStarRepository, StarRepository>();
builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();


var app = builder.Build();

app.UseCors(builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("Location");
    });
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
