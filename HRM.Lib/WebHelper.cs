using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Lib
{
    public static class WebHelper
    {
        public static string GetImagePath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return "/ProfilePicture/default-user.png";
            }
            return string.Format("/ProfilePicture/{0}", path);
        }
    }
}
