using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Excemtions
{
    public class NotFoundExceptation : Exception
    {
        public NotFoundExceptation(string massage) : base(massage) { }
        
    }
}
