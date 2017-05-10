using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenNote.Models
{
    public class NoteCreate
    {
        [Required]
        [MaxLength (128)]
        public string Title { get; set; }

        [MaxLength(8000)]
        public string Content { get; set; }

        //This is optional, User may not have change idea to include
        public string Content1 { get; set; }

        public override string ToString() => Title;
        

    }
}
