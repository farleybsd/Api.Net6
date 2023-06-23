using Blog;
using Blog.Data;
using Blog.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
var builder = WebApplication.CreateBuilder(args);

var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services
        .AddControllers()
        .ConfigureApiBehaviorOptions(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        }); // desabilita Validacao Automatica ModelState

builder.Services.AddDbContext<BlogDataContext>();
builder.Services.AddTransient<TokenService>();
//builder.Services.AddTransient(); -> Sempre Cria um novo
//builder.Services.AddScoped();    -> Mantem o mesmo objeto naquela transacao (Request)
//builder.Services.AddSingleton(); -> Nunca Morre

var app = builder.Build();

app.UseAuthentication(); // Manter esse 1 que o UseAuthorization
app.UseAuthorization();
app.MapControllers();

app.Run();
