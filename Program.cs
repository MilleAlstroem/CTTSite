using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CTTSite.Services.NormalService;
using CTTSite.Services.JSON;
using CTTSite.Services.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CTTSite.Models;


// Edited by Christian

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddTransient<JsonFileService<User>>();
builder.Services.Configure<CookiePolicyOptions>(options => {
    // This lambda determines whether user consent for non-essential cookies is needed for a given request. options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;

});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(cookieOptions => {
    cookieOptions.LoginPath = "/User/Login/LogInPage";

});
builder.Services.AddMvc().AddRazorPagesOptions(options =>
{
    options.Conventions.AuthorizeFolder("/Admin");

}).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
