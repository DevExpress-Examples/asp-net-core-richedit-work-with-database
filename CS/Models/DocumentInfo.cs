using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RichSaveLoadDB.Models
{
    public class DocumentInfo
    {
        [Key]
        public int ID { set; get; }
        [Column("documentName")]
        public string DocumentName { set; get; }
        [Column("documentBytes")]
        public byte[] DocumentBytes { set; get; }
        [Column("documentFormat")]
        public int DocumentFormat { set; get; }
    }
}
