using Blog.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services
        .AddControllers()
        .ConfigureApiBehaviorOptions(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        }); // desabilita Validacao Automatica ModelState

builder.Services.AddDbContext<BlogDataContext>();
var app = builder.Build();

app.MapControllers();

app.Run();
