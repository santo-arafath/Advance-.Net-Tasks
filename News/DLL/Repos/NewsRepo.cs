using DLL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repos
{
    public class NewsRepo
    {
        public static string GetById(int id)
        {
            if (id == 1) return "Sports";
            else if (id == 2) return "Sports";
            else if (id == 3) return "Sports";

            else { return "Not found"; }
        }

        public static string Createnews(News cat)
        {

            return " news Created";

        }
    }
}
