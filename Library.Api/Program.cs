using System.Reflection;
using Library.Application;
using Library.Infrastructure;
using LibraryPersistentEF.LibraryDB;
{
    // ���������� �������� ������� �����:
    //https://www.csharp.com/blogs/addmigration-the-term-addmigration-is-not-recognized
    // � ������ �������� �������

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    //// ����� �� �������������� ����. ����� ���������. �� ����. �������������� ��� ����� ���� ���������� ��������
    //Assembly assembly = Assembly.GetExecutingAssembly();
    //builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    builder.Services.AddInfrastructureServices();
    builder.Services.RegisterLibraryDbContext(builder.Configuration);

    // �������� ������ AddApplicationServices. �� �� ��� �����. ���� �� ������ Application, ������ � �������������� 
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