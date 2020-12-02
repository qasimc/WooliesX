using System;
using System.Collections.Generic;
using System.Text;
using WooliesX.Domain;
using WooliesX.Domain.Interfaces;
using WooliesX.Domain.Models;
using WooliesX.Service.Interfaces;

namespace WooliesX.Services
{
    public class Exercise1Service : IExercise1Service
    {
        IExternalComms ExternalComms;
        public Exercise1Service(IExternalComms externalComms)
        {
            ExternalComms = externalComms;
        }
        public ResultValue<Exercise1Response> GetUser(string resource)
        {
            var response = ExternalComms.GetExercise1Response(resource + "/User");
            return response;

        }
    }
}
