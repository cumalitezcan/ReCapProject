using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    
    //Tek başına bir tablo değil.
    public class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        


        public int ImageId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }

    }
}
