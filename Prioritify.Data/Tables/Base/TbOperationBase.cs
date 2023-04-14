using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prioritify.Data.Tables.Base {
    public class TbOperationBase {
        [Key]
        [Column("flOperationId")]
        public long Id { get; set; }
        [Column("flOpType")]
        public string OpType { get; set; }
        [Column("flOpModelJson")]
        public string OperationModelJson { get; set; }
        [Column("flTimestamp")]
        public DateTime Timestamp { get; set; }
        [EnumDataType(typeof(OperationStatus))]
        [Column("flStatus")]
        public OperationStatus Status { get; set; }
        [Column("flExecuter")]
        public string OperationExecuter { get; set; }
    }
}
