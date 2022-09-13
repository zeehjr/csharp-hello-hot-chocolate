using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddDbContext<DatabaseContext>(options =>
        options.UseNpgsql("Host=localhost;Database=graphql;Username=postgres;Password=postgrespassword"));

builder.Services.AddScoped<UsersService, UsersService>();

builder.Services
    .AddGraphQLServer()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true)
    .RegisterDbContext<DatabaseContext>()
    .AddFiltering()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
