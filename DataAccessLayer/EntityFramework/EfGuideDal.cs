using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfGuideDal : GenericRepository<Guide>, IGuideDal
    {
        Context context = new Context();
        public void ChangeToFalseByGuide(int id) // id göre çağırıcaz
        {
            var values = context.Guides.Find(id); // id göre buldurduk
            values.Status = false; // durumunu false yaptık db içindede false oluyor
            context.Update(values);// valuesden gelen değeri güncelle sonra aşağıda kaydetme işlemi gerçekleşecek
            context.SaveChanges(); // bunuda database de kaydettik
        }

        public void ChangeToTrueByGuide(int id) // id göre çağırıcaz
        {
            var values = context.Guides.Find(id); //id göre buldurduk
            values.Status = true; // burada database durumunu true hale getirdik
            context.Update(values);// valuesden gelen değeri güncelle sonra aşağıda kaydetme işlemi gerçekleşecek
            context.SaveChanges(); // burada database kaydettik
        }
    }
}
