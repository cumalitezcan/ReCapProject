using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
   public class FileHelper
    {

        //Postman imageKey ile masaüstündeki fotoğraf seçilmiş ve gönderilmiştir.
        //Gönderilen fotoğraf newPath() methodu ile yeni dosya yolu alıp,
        //hem veritabanına hem de o yolu temsil eden Images klasörümüze kaydoldu.
        public static string Add(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName();//Geçici dosya yolu

            if (file.Length > 0)//Dosya var mı ?
            {
                //FileStream dosya üzerinde okuma,yazma ve atlama operasyonları
                //yazmamıza yardımcı olan bir sınıftır.
                using (var uploading = new FileStream(sourcepath,FileMode.Create))
                {
                    file.CopyTo(uploading);//Dosya kopyalama
                }
            }
            var result = newPath(file);
            File.Move(sourcepath,result);//Dosya taşıma
            return result;
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);//Dosya silme
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
               
            }
            return new SuccessResult();
        }

        public static string Update(string sourcePath,IFormFile file)
        {
            var result = newPath(file);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }


        public static string newPath(IFormFile file)
        {
            //FileInfo verilen dizindeki dosya hakkında adı,oluşturma tarihi,tam yolu,uzantısı,
            //bulunduğu klasör vb. dosya hakkında bilgileri öğrenmemizi sağlar.
            FileInfo ff = new FileInfo(file.FileName);

            string fileExtension = ff.Extension;//Dosya uzantısını alma

           
            string path = Environment.CurrentDirectory + @"\wwwroot\uploads";//mevcut dosya yolu

            var newPath = Guid.NewGuid().ToString()+fileExtension;//Benzersiz string değer+dosya uzantısı

            string result = $@"{path}\{newPath}";

            return result;
        }

    }
}
