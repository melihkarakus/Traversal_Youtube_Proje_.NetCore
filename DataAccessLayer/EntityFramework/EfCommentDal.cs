using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetListCommentWithDestination() // bu imza burada çağırıldı
        {
            using (var c = new Context())
            {
                return c.Comments.Include(x=>x.Destination).ToList(); // içi doldurmak için database de olan destination sınıfındaki bütün verileri getirmeye
                // yaradı bunun sebebi ise comment ındex tarafında city içindeki verileri getirmek için
            }
        }
    }
}
