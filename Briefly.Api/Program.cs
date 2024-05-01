using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Briefly.Infrastructure.Context;

using Briefly.Data.Identity;
using Briefly.Core.DepencyInjection;
using Briefly.Infrastructure.DepencyInjection;
using Briefly.Data.Helpers;
using Briefly.Infrastructure.SeedData;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region ConnectToDb
//AddDb
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString));

#region identityservices
builder.Services.AddIdentity<User, Role>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    // User settings.
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<ApplicationDbContext>()
  .AddDefaultTokenProviders();
#endregion



#endregion

#region Dependendies
builder.Services.AddCoreDependinces()
                .AddServiceDependinces()
                .AddRepositoryDependinces();
#endregion

#region configure authentication 
//var jwtSettings = new JwtSettings();
//builder.Services.AddSingleton(jwtSettings);
//builder.Configuration.GetSection("jwtSettings").Bind(jwtSettings);


//builder.Services.AddAuthentication(x =>
//{
//    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(x =>
//{
//    x.RequireHttpsMetadata = false;
//    x.SaveToken = true;
//    x.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = jwtSettings.ValidateIssuer,
//        ValidIssuer = jwtSettings.Issuer,
//        ValidateAudience = jwtSettings.ValidateAudience,
//        ValidAudience = jwtSettings.Audience,
//        ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
//        ValidateLifetime=jwtSettings.ValidateLifeTime
//    };
//});


//#endregion

//#region Swagger generator auth
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NewsApi Project", Version = "v1" });
//    c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
//    {
//        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
//        Name = "Authorization",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.ApiKey,
//        Scheme = JwtBearerDefaults.AuthenticationScheme
//    });

//    c.AddSecurityRequirement(new OpenApiSecurityRequirement
//            {

//            {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = JwtBearerDefaults.AuthenticationScheme
//                }
//            },
//            Array.Empty<string>()
//            }
//           });
//});
#endregion

#region bindingData
var jwtSettings = new JwtSettings();
builder.Services.AddSingleton(jwtSettings);
builder.Configuration.GetSection("jwtSettings").Bind(jwtSettings);

var emailSetting = new EmailSetting();
builder.Configuration.GetSection("emailSetting").Bind(emailSetting);
builder.Services.AddSingleton(emailSetting);

var GoogleAuthSetting = new GoogleAuthSetting();
builder.Services.AddSingleton(GoogleAuthSetting);
builder.Configuration.GetSection("GoogleAuth").Bind(GoogleAuthSetting);

//builder.Services.Configure<EmailSetting>(builder.Configuration.GetSection("emailSetting"));
#endregion


#region AddIUrlhelper
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddScoped<IUrlHelper>(x =>
{
    var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
    var factory = x.GetRequiredService<IUrlHelperFactory>();
    return factory.GetUrlHelper(actionContext);
});
#endregion

#region Addcors
var Cors = "_cors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Cors,
    builder =>
    {
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        builder.AllowAnyOrigin();
    });
});
#endregion

var app = builder.Build();

#region SeedData
using (var scope = app.Services.CreateScope())
{
    var usermanager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var rolemanager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

    await SeedRole.SeedRolesAsync(rolemanager);
    await SeedUser.SeedUserAsync(usermanager);
}

#endregion


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

//app.UseAuthentication();

app.UseCors(Cors);

app.UseAuthorization();

app.MapControllers();

app.Run();
