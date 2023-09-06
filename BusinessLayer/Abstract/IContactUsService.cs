using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactUsService : IGenericService<ContactUS>
    {
        List<ContactUS> TGetListContactUsByTrue();
        List<ContactUS> TGetListContactUsByFalse();
        void TContactUsStatusChangeToFalse(int id);
    }
}
