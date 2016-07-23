using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure
{
    public interface IBaseRepository<TModel, Tkey, TSearchModel> : IDisposable
    {
        Tkey Add(TModel Current);
        bool Edit(TModel Current);
        bool Delete(Tkey ID);
        bool DeleteRange(List<Tkey> IDS);
        List<TModel> GetAll();
        TModel Get(Tkey ID);
        TModel GetByMessageID(int MessageID);
        int Count();
        int Count(TSearchModel sm);
        List<TModel> Search(TSearchModel sm, out int RecordCount);

    }
}
