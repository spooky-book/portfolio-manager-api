using portfolio_manager_api.Services;
using PortfolioManagerApi.Proxy;
using PortfolioManagerApi.Repository;

namespace portfolio_manager_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddScoped<IPortfolioService, PortfolioService>();
            builder.Services.AddScoped<IPortfolioContextService, PortfolioContextService>();
            builder.Services.AddDbContext<PortfolioContext>();

            builder.Services.AddHttpClient<IStockDataProxy, StockDataProxy>(config =>
            {
                config.BaseAddress = new Uri("http://127.0.0.1:5000/");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<PortfolioContext>();
                context.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
