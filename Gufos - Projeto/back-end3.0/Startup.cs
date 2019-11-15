using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

// Instalamos o Entity Framework
// dotnet tool install --global dotnet-ef

// Baixamos o pacote SQLServer do Entity Framework
// dotnet add package Microsoft.EntityFrameworkCore.SqlServer

// Baixamos o pacote que irá escrever nossos códigos
// dotnet add package Microsoft.EntityFrameworkCore.Design

// Testamos se os pacotes foram instalados
// dotnet restore

// Testamos a instalação do EF
// dotnet ef

// Código que criará o nosso Contexto da Base de Dados e nossos Models
// dotnet ef dbcontext scaffold "Server=LAB08DESK4001; Database=Gufos; User Id=sa; Password=132" Microsoft.EntityFrameworkCore.SqlServer -o Domains -d --context-dir Context -c GufosContext
// dotnet ef dbcontext scaffold "Server=DESKTOP-NJ6LHN1\SQLDEVELOPER; Database=Gufos; Integrated Security=true;" Microsoft.EntityFrameworkCore.SqlServer -o Domains -d --context-dir Context -c GufosContext

// SWAGGER - Documentação

// Instalamos o pacote
// dotnet add backend.csproj package Swashbuckle.AspNetCore -v 5.0.0-rc4

// JWT - JSON WEB Token

// Adicionamos o pacote JWT
// dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 3.0.0

// Adicionamos o pacote Newtonsoft para tratamento de json
// dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 3.0.0

// Possível solução problemas com Omnisharp
// Adicionar a variável de ambiente MSBuildSDKsPath
// Adicionar o caminho da variável como C:\Program Files\dotnet\sdk\3.0.100\Sdks

namespace backend
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
            // Configura para que o looping no relacionamento de entidades seja ignorado
            services.AddControllersWithViews().AddNewtonsoftJson(
                opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            );

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            // Configuramos o Swagger
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo{ Title = "API", Version = "v1"});

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Declara o uso do Swagger
            app.UseSwagger();

            // Especifica o Endpoint do Swagger na aplicação
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","API V1");
            });

            // Declara o uso da autenticação
            app.UseAuthentication();
            
            // Habilita o Cors
            app.UseCors("CorsPolicy");

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
