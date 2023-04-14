using Prioritify.Data.Tables;

namespace Prioritify.Sources.Operations {
    public interface IOperation<TOpModel> {
        Task<OperationResult<TOpModel>> ExecuteAsync();
    }

    public class OperationResult<TOpModel> {
        public OperationResult(TOpModel opModel, OperationStatus status, string opExecuter) {
            OperationModel = opModel;
            Status = status;
            OperationExecuter = opExecuter;
            Timestamp = DateTime.UtcNow;

        }
        public TOpModel OperationModel { get; set; }
        public DateTime Timestamp { get; set; }
        public OperationStatus Status { get; set; }
        public string OperationExecuter { get; set; }
    }

}
