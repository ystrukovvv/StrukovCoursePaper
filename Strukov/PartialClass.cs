using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strukov
{
    public partial class NEWS
    {
        public string FullAuthor
        {
            get
            {
                return "Автор: " + AuthorId;
            }
        }
    }
}
