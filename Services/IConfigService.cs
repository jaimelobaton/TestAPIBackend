using System.Collections.Generic;
using TestAPIBackend.Data;

namespace TestAPIBackend.Services
{
    public interface IConfigService
    {
        List<Director> getAllDirectors();
        List<Genrer> getAllGenders();
        List<Studio> getAllStudios();
    }
}