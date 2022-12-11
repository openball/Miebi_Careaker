using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caretaker.Shared
{
    public class NoticeBoard
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoticeBoardId { get; set; }
        public string? MessageTitle { get; set; }
        public string? MessageDetails { get; set; }
        public int PostedBy { get; set; }
        public DateTime PostedDate { get; set; } = DateTime.Now;
    }
}
