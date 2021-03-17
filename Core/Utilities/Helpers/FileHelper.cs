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
            var result = newPath(file);
            try
            {
                var sourcepath = Path.GetTempFileName();//Geçici dosya yolu

                if (file.Length > 0)//Dosya var mı ?
                
                    //FileStream dosya üzerinde okuma,yazma ve atlama operasyonları
                    //yazmamıza yardımcı olan bir sınıftır.
                    using (var stream = new FileStream(sourcepath, FileMode.Create))

                        file.CopyTo(stream);//Dosya kopyalama
                    File.Move(sourcepath, result.newPath);//Dosya taşıma
            }


                  catch (Exception exception)
            {
                return exception.Message;
            }
            return result.Path2;

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
            try
            {
                if (sourcePath.Length > 0)
                {
                    using (var stream = new FileStream(result.newPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                File.Delete(sourcePath);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return result.Path2;
        }


        public static (string newPath,string Path2 ) newPath(IFormFile file)
        {
            //FileInfo verilen dizindeki dosya hakkında adı,oluşturma tarihi,tam yolu,uzantısı,
            //bulunduğu klasör vb. dosya hakkında bilgileri öğrenmemizi sağlar.
            FileInfo ff = new FileInfo(file.FileName);

            string fileExtension = ff.Extension;//Dosya uzantısını alma

            var newPath = Guid.NewGuid() + fileExtension;

            string path = Environment.CurrentDirectory + @"\wwwroot\uploads";//mevcut dosya yolu


            string result = $@"{path}\{newPath}";

            return (result, $"\\uploads\\{newPath}");
        }

    }
}
