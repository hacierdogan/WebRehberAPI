using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.DAL
{
    public class TelefonlarDAL
    {
        DataContext db = new DataContext();

        public IEnumerable<Telefonlar> GetAllPhones()
        {
            return db.Telefonlar;
        }

        public Telefonlar GetPhoneById(int id)
        {
            return db.Telefonlar.Find(id);
        }

        public Telefonlar CreatePhone(Telefonlar phone)
        {
            db.Telefonlar.Add(phone);
            db.SaveChanges();
            return phone;
        }

        public Telefonlar UpdatePhone(int id,Telefonlar phone)
        {
            db.Entry(phone).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return phone;
        }

        public void DeletePhone (int id)
        {
            db.Telefonlar.Remove(db.Telefonlar.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyPhoneID(int id)
        {
            return db.Telefonlar.Any(x=>x.ID==id);
        }
        public Telefonlar IsThereAnyPhoneNumber(string number)
        {
            return db.Telefonlar.Where(w => w.TelefonNo == number).SingleOrDefault();
        }
    }
}
