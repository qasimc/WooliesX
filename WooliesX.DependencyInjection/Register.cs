using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WebComms.Interfaces;
using WooliesX.Domain.Interfaces;
using WooliesX.Service.Interfaces;
using WooliesX.Services;


namespace WooliesX.DependencyInjection
{
    public class Register
    {
        public static void RegisterTypes(IServiceCollection container)
        {
            container.AddScoped<IExercise1Service, Exercise1Service>();
            container.AddScoped<IExercise2Service, Exercise2Service>();
            container.AddScoped<IWebComms, WebComms.Communication.WebComms>();
            container.AddScoped<IExternalComms, ExternalComms.ExternalComms>();
            container.AddScoped<IExercise3Service, Exercise3Service>();
        }
    }
}
