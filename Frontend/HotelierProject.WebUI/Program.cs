using FluentValidation;
using FluentValidation.AspNetCore;
using HotelierProject.DataAccessLayer.Concrete;
using HotelierProject.EntityLayer.Concrete;
using HotelierProject.WebUI.Dtos.GuestDto;
using HotelierProject.WebUI.ValidationRules.GuestValidationRules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//Fluent Validation register

builder.Services.AddTransient<IValidator<CreateGuestDto>,GuestValidationRules>();

builder.Services.AddControllersWithViews().AddFluentValidation();

//Authorization Policy Oluþturma
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
// Uygulamanýn session özelliklerini ve giriþ path ini  belirleme
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
    options.LoginPath = "/Login/Index/";
});

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.

//Custom hata sayfalarýný etkinleþtirme
app.UseStatusCodePagesWithReExecute("/Error/{0}");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/500");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
//Projeye Authentication ekledim.
app.UseAuthentication(); 
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
