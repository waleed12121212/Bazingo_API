using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Domain_Logic
{
    public static class ComplaintLogic
    {
        public static bool CanCloseComplaint(string status)
        {
            return status == "Resolved";
        }
    }
}
