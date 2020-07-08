using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.GameHandlers
{
    public interface IHandler
    {
        public IHandler SetNext(IHandler handler);

        public object Handle(object request);
    }
}
