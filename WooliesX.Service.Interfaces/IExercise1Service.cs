using System;
using System.Collections.Generic;
using System.Text;
using WooliesX.Domain;
using WooliesX.Domain.Models;

namespace WooliesX.Service.Interfaces
{
    public interface IExercise1Service
    {
        ResultValue<Exercise1Response> GetUser();
    }
}
