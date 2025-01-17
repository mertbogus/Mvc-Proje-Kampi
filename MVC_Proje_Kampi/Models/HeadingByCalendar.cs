using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Proje_Kampi.Models
{
    public class HeadingByCalendar
    {
        public string title { get; set; }

        public DateTime start { get; set; }

        public DateTime end { get; set; }

        public bool allDay { get; set; }
    }
}