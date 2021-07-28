using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GEtlist();
        void HeadingAdd(Heading heading);
        void HEadingDelete(Heading heading);
        void HeadingUpdate(Heading heading);
        Heading GetById(int id);
        List<Heading> GetListbyWriter(int id);

    }
}
