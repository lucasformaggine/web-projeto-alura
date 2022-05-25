namespace web_projeto_alura
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddTransient<ICatalogo, Catalogo>();
            services.AddTransient<IRelatorio, Relatorio>();

            //services.AddScoped<ICatalogo, Catalogo>();
            //services.AddScoped<IRelatorio, Relatorio>();

            //var catalogo = new Catalogo();
            //services.AddSingleton<ICatalogo>(catalogo);
            //services.AddSingleton<IRelatorio>(new Relatorio(catalogo));

        }

        public void Configure(WebApplication app, IWebHostEnvironment environment, IServiceProvider serviceProvider)
        {
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            ICatalogo catalogo = serviceProvider.GetService<ICatalogo>();
            IRelatorio relatorio = serviceProvider.GetService<IRelatorio>();

            app.MapGet("/", async (context) =>
            {
                await relatorio.Imprimir(context);
            });
        }
    }
}
