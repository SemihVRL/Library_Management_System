using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library_Management_System.Models.Entity;

namespace Library_Management_System.Models.Classes
{
    public class LibraryEnumerable
    {
        public IEnumerable<TBLBOOK> Books { get; set; }
        public IEnumerable<TBLABOUT> Abouts { get; set; }
    }
}