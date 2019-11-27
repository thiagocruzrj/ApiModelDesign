using ApiDapper.Domain.Repository;
using ApiDapper.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiDapper.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            /*
            Adicionando a interface do repositório de pessoa no contexto de injeção de dependências do .net core.

            Assim, qualquer classe que referenciar esta interface em seu contrutor, ver PessoaController, receberá
            uma instância de PessoaRepository onde a connection string é obtida do arquivo de configurações appsettings.json
             */
            services.AddScoped<IPessoaRepository>(factory => {
                return new PessoaRepository(Configuration.GetConnectionString("MySqlDbConnection"));
            });

            services.AddScoped<IUsuarioRepository>(factory => {
                return new UsuarioRepository(Configuration.GetConnectionString("MySqlDbConnection"));
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
