using Intarfaces.Repository;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdditionService : IAdditionService
    {
        private IDbRepos db;
        public AdditionService(IDbRepos db)
        {
            this.db = db;
        }
        public AdditionDTO GetAddition(int id)
        {
            return new AdditionDTO(db.Additions.GetItem(id));
        }

        public List<AdditionDTO> GetAdditions()
        {
            return db.Additions.GetList().Select(x => new AdditionDTO(x)).ToList();
        }
    }
}
