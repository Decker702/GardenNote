using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenNote.Data
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        //optional, user may not have ideas for change
        public string Content1 { get; set; }

        [Required]
        public DateTimeOffset CreateUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
