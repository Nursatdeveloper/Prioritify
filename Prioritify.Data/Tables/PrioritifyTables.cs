using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prioritify.Data.Tables {
    public class TbTasks {
        [Key]
        public string flId { get; set; }
        public string flName { get; set; }
        public string flDescription { get; set; }
        public DateTime flDeadline { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public int flUserId { get; set; }
        public TaskStatus flStatus { get; set; }
        public string flPrevVersionsInJson { get; set; }
        public string Tags { get; set; }
    }

    public enum TaskStatus {
        Done,
        OnProcess,
        Postponed,
        NotStarted
    }
}
