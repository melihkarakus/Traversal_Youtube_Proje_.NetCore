using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AnnouncementDTOs
{
    public class AnnouncementListDTO
    {
        public int AnnouncementID { get; set; } //announcement controllerındaki dto ile eşitlenen yerde çıkıyor
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
