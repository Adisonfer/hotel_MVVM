using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IAdditionService
    {
        List<AdditionDTO> GetAdditions();
        AdditionDTO GetAddition(int id);
    }
}
