using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prioritify.Data.Tables {
    public class TbExceptions {
        [Key]
        [Column("flExceptionId")]
        public int Id { get; set; }
        [Column("flCreatedAt")]
        public DateTime CreatedAt { get; set; }
        [Column("flException")]
        public string Exception { get; set; }
    }

    public class TbLogs {
        [Key]
        [Column("flLogId")]
        public long Id { get; set; }
        [Column("flType")]
        public string Type { get; set; }
        [Column("flMessage")]
        public string Message { get; set; }
    }
}
