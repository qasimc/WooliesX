using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WooliesX.Domain;
using WooliesX.Domain.Models;
using WooliesX.Request_Models;
using WooliesX.Service.Interfaces;

namespace WooliesX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        IExercise1Service Exercise1Service;
        IExercise2Service Exercise2Service;
        IExercise3Service Exercise3Service;
        public ExerciseController(IExercise1Service exercise1Service, IExercise2Service exercise2Service, IExercise3Service exercise3Service)
        {
            Exercise1Service = exercise1Service;
            Exercise2Service = exercise2Service;
            Exercise3Service = exercise3Service;
        }

        [HttpGet("exercise1/user")]
        public IActionResult Exercise1()
        {
            var result = Exercise1Service.GetUser();
            if(result.IsOk)
            {
                Exercise1Response response = new Exercise1Response()
                {
                    name = result.Value.name,
                    token = result.Value.token
                };
                return Ok(new ApiResponse() { passed = true, url = "", message = response });
            }
            else
            {
                return BadRequest(result.Errors);
            }

        }
        [HttpPost("Exercise2/sort")]
        public IActionResult Exercise2([FromBody] ApiRequest request, string sortOption)
        {
            var result = Exercise2Service.GetSortedProducts("http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/products", sortOption, request.token);
            if (result.IsOk)
            {

                return Ok(new ApiResponse() { passed = true, url = request.url, message = result.Value });
            }
            else
            {
                return BadRequest(new ApiResponse() { passed = false, url = request.url, message = result.Errors });
            }

        }

        [HttpPost("Exercise3/trolleyTotal")]
        public IActionResult Exercise3([FromBody] TrolleyRequest trolleyRequest)
        {
            var result = Exercise3Service.CalculateMinimumTrolleyTotal(trolleyRequest.specials, trolleyRequest.products, trolleyRequest.quantities);
            if (result.IsOk)
            {
                return Ok(result.Value);
            }
            else
            {
                return BadRequest(new ApiResponse() { passed = false, url = "", message = result.Errors });
            }
        }
    }
}
