using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RReviews.Data;
using RReviews.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<RReviewsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RReviewsContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseCustomCultureSettings();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
