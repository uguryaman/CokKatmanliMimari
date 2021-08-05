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
        void ImageAdd(ImageFile ımageFile);
        void ImageDelete(ImageFile ımageFile);
        void ImageUpdate(ImageFile ımageFile);
        ImageFile GetById(int id);
        List<ImageFile> GetListByID(int id);
    }
}
