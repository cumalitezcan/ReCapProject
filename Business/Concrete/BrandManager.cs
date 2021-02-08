using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

       

        public void Add(Brand brand)
        {
            if (brand.Name.Length>2)
            {
                _brandDal.Add(brand);
                Console.WriteLine("Marka Bilgisi Başarıyla Eklendi");
            }
            else
            {
                Console.WriteLine($"Marka isim uzunluğu 2 karakterdan fazla olmalıdır. Girilen Marka İsmi: {brand.Name}");
            }
        }

       

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("Marka Bilgisi Başarıyla Silindi");
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.Get(c=>c.Id==id);
        }

      

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
            Console.WriteLine("Marka Biglisi Güncellendi");
        }
    }
}
