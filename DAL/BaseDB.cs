using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class BaseDB : Models.ZilatanBotContext
    {
        public bool Add(Models.Message message)
        {

            return true;
        }


    }
}
