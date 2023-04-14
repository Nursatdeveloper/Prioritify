using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prioritify.Data.Tables;
using Prioritify.Data.Repositories;

namespace Prioritify.Sources.Operations.AccountOperations {
    public class RegisterOperation: IOperation<RegisterOpModel> {
        private readonly RegisterOpModel _model;
        private readonly IRepositoryAccessor _repositoryAccessor;
        public RegisterOperation(RegisterOpModel model, IRepositoryAccessor repositoryAccessor) {
            _model = model;
            _repositoryAccessor = repositoryAccessor;
        }

        public async Task<OperationResult<RegisterOpModel>> ExecuteAsync() {
            var tbUsers = _repositoryAccessor.GetTbUsers();
            var tbAccounts = _repositoryAccessor.GetTbAccounts();

            var user = new TbUsers() {
                Firstname = _model.Firstname,
                Lastname = _model.Lastname,
                BirthDate = _model.BirthDate,
                Gender = _model.Gender,
                Degree = _model.Degree,
                StudyYear = _model.StudyYear,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var createdUser = await tbUsers.InsertAsync(user);

            if(createdUser == null) {
                return new OperationResult<RegisterOpModel>(_model, OperationStatus.Failed, "EXECUTER");
            }

            var account = new TbAccounts() {
                Username = _model.Username,
                Email = _model.Email,
                Password = _model.Password,
                PhoneNumber = _model.PhoneNumber,
                UserId = createdUser.Id,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            var createdAccount = await tbAccounts.InsertAsync(account);

            if(createdUser != null && createdAccount != null) {
                return new OperationResult<RegisterOpModel>(_model, OperationStatus.Executed, "EXECUTER");
            }
            return new OperationResult<RegisterOpModel>(_model, OperationStatus.Failed, "EXECUTER");
        }
    }

    public class RegisterOpModel {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public UserGender Gender { get; set; }
        [Required]
        [Range(1, 4)]
        public int StudyYear { get; set; }
        [Required]
        public Degree Degree { get; set; }


        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [MinLength(5)]
        public string Password { get; set; }
    }

}
