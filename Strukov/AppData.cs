using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Strukov
{
    class AppData
    {
        public static Frame MainFrame = new Frame();

        public static HospitalBaseEntities2 Context = new HospitalBaseEntities2();

        public static bool statusRegistry = false;
    }
}
