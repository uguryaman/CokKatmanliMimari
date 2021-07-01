using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class ImageManager : IImageService
    {
        IImageDal _ımageDal;
        public ImageManager(IImageDal ımageDal)
        {
            _ımageDal = ımageDal;
        }

        public void AboutAdd(ImageFile ımageFile)
        {
            _ımageDal.Insert(ımageFile);
        }

        public void AboutDelete(ImageFile ımageFile)
        {
            _ımageDal.Delete(ımageFile);
        }

        public void AboutUpdate(ImageFile ımageFile)
        {
            _ımageDal.Update(ımageFile);
        }

        public ImageFile GetById(int id)
        {
            return _ımageDal.Get(x => x.ImageID == id);
        }

        public List<ImageFile> GEtlist()
        {
            return _ımageDal.List();
        }

        public List<ImageFile> GetListByID(int id)
        {
            return _ımageDal.List(x => x.ImageID == id);
        }
    }
}
