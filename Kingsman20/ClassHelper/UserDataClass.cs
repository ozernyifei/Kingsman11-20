using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingsman20.ClassHelper
{
    internal class UserDataClass
    {
        public static DB.Employee SavedEmployee { get; set; } = new DB.Employee();

        public static DB.Client SavedClient { get; set; } = new DB.Client();
    }
}
