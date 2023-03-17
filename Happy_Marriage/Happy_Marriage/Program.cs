
using ExampleApplication;
using Happy_Marriage.BusinessLogic;
using Happy_Marriage.BusinessLogic.Interfaces;
using Happy_Marriage.Services;
using Happy_Marriage.Services.Interfaces;
using Happy_Marriage.Utilities;
using Happy_Marriage.Utilities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Happy_Marriage.Models;
using Happy_Marriage.Exceptions;

var builder = WebApplication.CreateBuilder(args);

//Configuring a external path for storing data on server
var config = builder.Configuration.GetSection("ApplicationConfiguration");
builder.Services.Configure<ApplicationConfiguration>(config);

//Getting mysql connection from appsettings.json
string constring = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<DBEntityContext>(options => { options.UseMySQL(constring); });

//For sass compliling into css -- adding a service into the program
/*builder.Services.AddHostedService(sp => new NpmWatchHostedService(
                enabled: sp.GetRequiredService<IWebHostEnvironment>().IsDevelopment(),
                logger: sp.GetRequiredService<ILogger<NpmWatchHostedService>>()));*/

//Actions to be taken before starting the server
/*builder.Services.AddHostedService(conf => new StartupHostedService(
                enabled: conf.GetRequiredService<IWebHostEnvironment>().IsDevelopment(),
                logger: conf.GetRequiredService<ILogger<StartupHostedService>>()));*/

//Email smtp server configration from appsettings.json
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

//AppConfigServices DI
builder.Services.AddTransient<IAppConfigServices,AppConfigServices>();

//Email Services injection 
builder.Services.AddTransient<IEmailServices, EmailServices>();

//Services Injection
builder.Services.AddTransient<DBEntityContext>();
builder.Services.AddTransient<IUserManager, UserManager>();
builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddTransient<IFileManager, FileManager>();
builder.Services.AddTransient<IFileServices, FileServices>();
builder.Services.AddTransient<IRelationshipManager, RelationshipManager>();
builder.Services.AddTransient<IRelationshipServices, RelationshipServices>();
builder.Services.AddTransient<IMessengerManager, MessengerManager>();
builder.Services.AddTransient<IMessengerServices, MessengerServices>();
builder.Services.AddTransient<IAjaxManager, AjaxManager>();
builder.Services.AddTransient<IAjaxServices, AjaxServices>();
builder.Services.AddTransient<IAccountManager, AccountManager>();
builder.Services.AddTransient<IAccountServices, AccountServices>();


//Add where the session will be stored
builder.Services.AddDistributedMemoryCache();

//Session management on server side
builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromSeconds(1000);
                                         options.Cookie.HttpOnly = true;
                                         options.Cookie.IsEssential= true;} );

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers(options => { options.Filters.Add(new SessionExpiryResponseFilter());});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
//middleware settings for session
app.UseSession();

//For ApiControllers
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
