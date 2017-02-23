using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT2106project.Models;

namespace ICT2106project.DAL
{
    interface IBookGateway
    {
        IEnumerable<Book> SelectAll();
        Book SelectById(int? id);
        void Insert(Book book);
        void Update(Book book);
        Book Delete(int? id);
        void Save();
    }
}
