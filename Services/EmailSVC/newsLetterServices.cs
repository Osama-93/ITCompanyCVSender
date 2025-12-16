using DataAccessTier.DataAccessController;
using DataAccessTier.DataAccessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EmailSVC
{
    public class newsLetterServices
    {
        DataAccessnewsLetter dataAccess = new DataAccessnewsLetter();
        public List<newsLetter> Get()
        {
            return dataAccess.Get().ToList();
        }
        public newsLetter Get(int id)
        {
            return dataAccess.Get(id);
        }
        public void Add(newsLetter newsLetter)
        {
            dataAccess.Add(newsLetter);
        }
        public void Delete(newsLetter newsLetter)
        {
            dataAccess.Delete(newsLetter);
        }
        public void Edit(newsLetter newsLetter)
        {
            dataAccess.Update(newsLetter);
        }
    }
}
