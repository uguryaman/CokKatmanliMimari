using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IImageService
    {
        List<ImageFile> GEtlist();
        void AboutAdd(ImageFile ımageFile);
        void AboutDelete(ImageFile ımageFile);
        void AboutUpdate(ImageFile ımageFile);
        ImageFile GetById(int id);
        List<ImageFile> GetListByID(int id);
    }
}
