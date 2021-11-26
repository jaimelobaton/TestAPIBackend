using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPIBackend.Data;
using TestAPIBackend.Services;

namespace TestAPIBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IConfigService _config;

        public ConfigController(IConfigService config)
        {
            _config = config;
        }

        [HttpGet]
        [Route("getAllGenders")]
        public IEnumerable<Genrer> getAllGenders()
        {

            try
            {
                return _config.getAllGenders();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("getAllDirectors")]
        public IEnumerable<Director> getAllDirectors()
        {

            try
            {
                return _config.getAllDirectors();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("getAllStudios")]
        public IEnumerable<Studio> getAllStudios()
        {

            try
            {
                return _config.getAllStudios();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
