using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleHostApp
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
            services.AddMvc()
                .AddRazorOptions(options =>
                {
                    var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();

                    assemblies.Add(typeof(Microsoft.CSharp.RuntimeBinder.Binder).Assembly);
                    assemblies.Add(typeof(HtmlAttributeValueStyle).Assembly);
                    assemblies.Add(typeof(HtmlString).Assembly);


                    var refs = assemblies
                        .Where(x => !x.IsDynamic && !string.IsNullOrWhiteSpace(x.Location))
                        .Select(x => MetadataReference.CreateFromFile(x.Location))
                        .ToList();
                    foreach (var portableExecutableReference in refs)
                    {
                        options.AdditionalCompilationReferences.Add(portableExecutableReference);
                    }

                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
