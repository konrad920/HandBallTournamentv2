using HandBallTournamentv2.ApplicationServices.Mappings;
using HandBallTournamentv2.ApplicationServices.API.Domain;
using HandBallTournamentv2.DataAccess;
using HandBallTournamentv2.DataAccess.CQRS;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using HandBallTournamentv2.ApplicationServices.API.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddMvcCore().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddClubRequestValidator>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();

builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();

builder.Services.AddAutoMapper(typeof(PlayersProfile).Assembly);

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssemblies(typeof(ResponseBase<>).Assembly);
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var connectionString = builder.Configuration.GetConnectionString("TournamentEntitiesDataBaseConnection");
builder.Services.AddDbContext<TournamentEntitiesContext>(opt => opt.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
