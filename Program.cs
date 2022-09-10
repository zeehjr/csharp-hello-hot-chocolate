using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder
    .Services
    .AddDbContext<DatabaseContext>(options =>
        options.UseNpgsql("Host=localhost;Database=graphql;Username=postgres;Password=postgrespassword"));

// builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite(builder.Configuration["Database:ConnectionString"]));

// builder.Services.RegisterDbContext<DatabaseContext>();
// builder.Services.AddDbContextFactory<DatabaseContext>(opt => opt.UseNpgsql("Host=localhost;Database=graphql;Username=postgres;Password=postgrespassword"));
// builder.Services.AddScoped<DatabaseContext>(sp => sp.GetRequiredService<IDbContextFactory<DatabaseContext>>().CreateDbContext());

builder.Services
    .AddGraphQLServer()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true)
    .RegisterDbContext<DatabaseContext>()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
