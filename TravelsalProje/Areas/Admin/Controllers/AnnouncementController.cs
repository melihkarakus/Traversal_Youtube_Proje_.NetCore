using AutoMapper;
using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.ExtendedProperties;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TravelsalProje.Areas.Admin.Models;

namespace TravelsalProje.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            //List<Announcement> announcements = _announcementService.TGetlist();//announcement içindeki dataları hepsini listeledik
            //List<AnnouncementListModel> model = new List<AnnouncementListModel>();//model içindeki verileri çağırdık buraya
            //foreach (var item in announcements) //datadaki announcement olanlar verileri itemin içine attık
            //{
            //    AnnouncementListModel announcementListModel = new AnnouncementListModel(); //burayada tanımlamamız lazım modei
            //    announcementListModel.ID = item.AnnouncementID; //hem datamızdaki verileri hemde modeldeki verileri eşitledik burada
            //    announcementListModel.Title = item.Title;
            //    announcementListModel.Content = item.Content;

            //    model.Add(announcementListModel);//modele ekleme yapmak için komutu kullanıp list modelde olan verileri ekledik
            //}

            var values = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.TGetlist());
            return View(values);//en son modele tanımladığımızda ekrana yansıttık
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDTO model) //dtolayer içinde dto sınıfından miras aldık
        {
            if (ModelState.IsValid) //eğer model state doğruysa
            {
                _announcementService.TAdd(new Announcement()//announcement ekleme işlemi yapılacak
                {
                    Title = model.Title, //burası veri girişinin tutulduğu columnlar
                    Content = model.Content,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult DeleteAnnouncement(int id) //id bazlı silme işlemi yapılacak
        {
            var values = _announcementService.TGetByID(id); //businesslayer serviceslerinden miras alınıp id ile silinecek
            _announcementService.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)// id şeklinde duyurumuzu buluyoruz
        {
            var values = _mapper.Map<AnnouncementUpdateDTO>(_announcementService.TGetByID(id));//mapper ile mapleyip id şeklinde eklemimizi yapıyoruz
            return View(values);
         }
        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDTO model)//dtolayer içindeki sınıflardan çağırdık
        {
            if(ModelState.IsValid)//eğer model doğru ise aşağıdaki işlemleri yapılacak
            {
                _announcementService.TUpdate(new Announcement()//announcement service gidilip update işlemi yapılacak
                {
                    AnnouncementID = model.AnnouncementID, //database verilerimize ile eşitlenip updateleme işlemi yapılacak
                    Content = model.Content,
                    Title = model.Title,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
