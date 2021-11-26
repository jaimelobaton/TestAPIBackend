using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TestAPIBackend.Authentication;
using TestAPIBackend.Data;


namespace TestAPIBackend.Services
{
    public class ConfigService : IConfigService
    {
        private readonly TestDbContext _db;

        public ConfigService(TestDbContext db)
        {
            _db = db;
        }
        public List<Genrer> getAllGenders()
        {
            var genders = _db.Genrers.ToList();

            return genders;
        }

        public List<Director> getAllDirectors()
        {
            var directors = _db.Directors.ToList();

            return directors;
        }

        public List<Studio> getAllStudios()
        {
            var studios = _db.Studios.ToList();

            return studios;
        }
    }
}
