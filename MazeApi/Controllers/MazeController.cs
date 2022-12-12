using MazeApi.Interface;
using MazeApi.Model;
using MazeApi.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MazeApi.Controllers
{
 
    [ApiController]
    [Route("api/Maze")]
    [EnableCors("MyPolicy")]
    public class MazeController : ControllerBase
    {

        private readonly ICalculateDistance _calculateDistance;

        public MazeController(ICalculateDistance calculateDistance)
        {
            _calculateDistance = calculateDistance;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_calculateDistance.GetMaze());

    }

   
}
