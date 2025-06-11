using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using online_school_api.Books.Repository;
using online_school_api.Books.Service;
using online_school_api.Courses.Repository;
using online_school_api.Courses.Service;
using online_school_api.Data;
using online_school_api.Enrolments.Repository;
using online_school_api.Students.Repository;
using online_school_api.Students.Service;
using System.Windows.Input;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("online-school-api", domain => domain.WithOrigins("")
                .AllowAnyHeader()
                .AllowAnyMethod());
        });

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(builder.Configuration.GetConnectionString("Default")!,
                new MySqlServerVersion(new Version(8, 0, 21))));

        builder.Services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddMySql5()
                .WithGlobalConnectionString(builder.Configuration.GetConnectionString("Default"))
                .ScanIn(typeof(Program).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole());


        builder.Services.AddScoped<IQueryServiceStudent, QueryServiceStudent>();
        builder.Services.AddScoped<IStudentRepo, StudentRepo>();
        builder.Services.AddScoped<ICommandServiceStudent, CommandServiceStudent>();

        builder.Services.AddScoped<IBookRepo, BookRepo>();
        builder.Services.AddScoped<IQueryServiceBook,QueryServiceBook>();

        builder.Services.AddScoped<ICourseRepo, CourseRepo>();
        builder.Services.AddScoped<ICommandServiceCourse, CommandServiceCourse>();
        builder.Services.AddScoped<IQueryServiceCourse, QueryServiceCourse>();

        builder.Services.AddScoped<IEnrolmentRepo, EnrolmentRepo>();

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();

        using (var scope = app.Services.CreateScope())
        {
            try
            {
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                runner.MigrateUp();
                Console.WriteLine("Migration successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Migration failed: {ex.Message}");
            }
        }

        app.UseCors("online-school-api");
        app.Run();
    }
}