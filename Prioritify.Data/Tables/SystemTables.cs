using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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

    public class TbOperations {
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

    public enum OperationStatus {
        Executed,
        Failed
    }
}
