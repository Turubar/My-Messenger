using Application.Interfaces.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class SearchTagGenerator : ISearchTagGenerator
    {
        public string GenerateSearchTag()
        {
            int number = new Random().Next(1000, 999999999);
            return "user" + number;
        }
    }
}
