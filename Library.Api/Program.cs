using System.Reflection;
using Library.Application;
using Library.Infrastructure;
using LibraryPersistentEF.LibraryDB;
{
    // Подключить миграцию удалось после:
    //https://www.csharp.com/blogs/addmigration-the-term-addmigration-is-not-recognized
    // в пакедж манагере консоли

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    //// Вынес из инфраструктуры сюда. Здесь наглядней. Но беда. Инфрастуруктур все равно надо подключить отдельно
    //Assembly assembly = Assembly.GetExecutingAssembly();
    //builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    builder.Services.AddInfrastructureServices();
    builder.Services.RegisterLibraryDbContext(builder.Configuration);

    // Вызывает всякие AddApplicationServices. Их аж две штуки. Одна на уровне Application, вторая в инфраструктуре 
    builder.Services.AddApplicationServices();

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
}