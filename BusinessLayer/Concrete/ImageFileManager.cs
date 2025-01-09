using BusinessLayer.Abatract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        ImageFileDal _imagefileDal;

        public ImageFileManager(ImageFileDal imagefileDal)
        {
            _imagefileDal = imagefileDal;
        }

        public List<ImageFile> GetImageList()
        {
            return _imagefileDal.List();
        }
    }
}
