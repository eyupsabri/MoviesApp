using Entities;
using Microsoft.EntityFrameworkCore;
using Business;
using Business.Services;
using DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MoviesAppUser.ActionFilter;
using FluentValidation.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var jwtIssuer = builder.Configuration.GetSection("JWT_ISSUER").Get<string>();
var jwtKey = builder.Configuration.GetSection("JWT_KEY").Get<string>();
//var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
//var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
// Add services to the container.
builder.Services.AddCors();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtKey,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddSingleton(new MyAuthActionFilter(jwtKey, jwtIssuer));

builder.Services.AddControllers().AddFluentValidation(v =>
{
    v.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseLazyLoadingProxies();
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IMoviesRepository, MoviesRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMovieReviewsRepository, MovieReviewsRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();

builder.Services.AddScoped<IMoviesService, MoviesService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMovieReviewsService, MovieReviewsService>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

var service = (IServiceScopeFactory)app.Services.GetService(typeof(IServiceScopeFactory));
using (var db = service.CreateScope().ServiceProvider.GetService<AppDbContext>())
{
    db.Database.Migrate();
}

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseStaticFiles(); // This will serve the React static files

app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapFallbackToFile("index.html"); // This will serve index.html for all unknown routes
});


//app.MapControllers();

app.Run();
