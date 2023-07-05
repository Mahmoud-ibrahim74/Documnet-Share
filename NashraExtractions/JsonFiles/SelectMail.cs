using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NashraExtractions.JsonFiles
{
    internal class SelectMail
    {
        public int id { get; set; }
        public string mail_title { get; set; }
        public string file_name { get; set; }
        public string username { get; set; }
        public DateTime date_mail { get; set; }
        public int isSigned { get; set; }
        public string UserSigned { get; set; } 

        public static implicit operator List<object>(SelectMail v)
        {
            throw new NotImplementedException();
        }
    }
}
