using System.Reflection;
using Library.Application;
using Library.Infrastructure;
using Library.Infrastructure.Exceptions;
using LibraryPersistentEF.LibraryDB;
using Microsoft.OpenApi.Models;
{
    // ���������� �������� ������� �����:
    //https://www.csharp.com/blogs/addmigration-the-term-addmigration-is-not-recognized
    // � ������ �������� �������

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    //    builder.Services.AddSwaggerGen();
    builder.Services.AddSwaggerGen(
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "�������� ��������",
                    Description = "������� ����� 15"
                });


                // ���-�� ���� ������� ��� ������ �������� ��� �� ��������� �� ����������
                //<PropertyGroup><GenerateDocumentationFile>true</GenerateDocumentationFile>  � *.Api.csproj
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                xmlFilename = Path.Combine(AppContext.BaseDirectory, xmlFilename);
                if (File.Exists(xmlFilename))
                    options.IncludeXmlComments(xmlFilename);
            }

    );


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

    // �������� ���������. ��� �� ���� �� ���������
    app.UseCustomExceptionHandler(app.Environment);

    app.Run();
}