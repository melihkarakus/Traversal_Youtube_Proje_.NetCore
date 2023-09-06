namespace TravelsalProje.Areas.Admin.Models
{
    public class AnnouncementListModel
    {
        public int ID { get; set; } //announcement controllerındaki dto ile eşitlenen yerde çıkıyor
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
