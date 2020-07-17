using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.DAL
{
    public class KullanicilarDAL
    {
        DataContext db = new DataContext();

        public Kullanicilar GetUserByApiKey(string apikey)
        {
            return db.Kullanicilar.FirstOrDefault(x => x.UserKey.ToString() == apikey);
        }
        public Kullanicilar GetUserByName(string name)
        {
            return db.Kullanicilar.FirstOrDefault(x => x.UserName == name);
        }
    }
}
