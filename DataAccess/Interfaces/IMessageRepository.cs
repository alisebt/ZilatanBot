using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IMessageRepository : Infrastructure.IBaseRepository<DomainModel.Models.Message, int, DomainModel.Models.Message>
    {
        List<DomainModel.Models.Message> GetSeachResult(DomainModel.Models.Message sm, out int RecordCount);
    }
}
