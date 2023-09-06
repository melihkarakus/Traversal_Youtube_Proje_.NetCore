using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AnnouncementDTOs
{
    public class AnnouncementAddDTO // Announcement verileri aynısını burada database ile birleştirmek oluyor
    {
        public string Title { get; set; } //databasedeki verilerin aynısını tutuyor
        public string Content { get; set; }
    }
}
