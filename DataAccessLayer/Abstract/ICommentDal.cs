using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        public List<Comment> GetListCommentWithDestination(); //ef comment dal için bir imza oluşturuldu
        public List<Comment> GetListCommentWithDestinationAndUser(int id);
    }
}
