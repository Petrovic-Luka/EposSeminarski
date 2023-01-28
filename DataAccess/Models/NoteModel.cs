using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class NoteModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }


    }
}
