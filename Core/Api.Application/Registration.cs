using Api.Application.Exceptions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using MediatR;
using Api.Application.Beheviors;
using Api.Application.Features.Products.Rules;
using Api.Application.Bases;

namespace Api.Application
{
    public static  class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly=Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleWare>();

            services.AddRulesFromAssemblyContaining(assembly,typeof(BaseRules));

            //services.AddTransient<ProductRules>();

            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(assembly));

            services.AddValidatorsFromAssembly(assembly);

            ValidatorOptions.Global.LanguageManager.Culture=new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RedisCacheBehevior<,>));
        }
        private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services,Assembly assembly,Type type)
        {
            var types=assembly.GetTypes().Where(t=>t.IsSubclassOf(type)&& type!=t).ToList();
            foreach (var item in types)
            {
                services.AddTransient(item);
            }
            return services;
        }
    }
}
