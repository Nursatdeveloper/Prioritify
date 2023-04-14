using Prioritify.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prioritify.Data.Repositories {
    public interface IRepositoryAccessor {
        IUserRepository<TbUsers> GetTbUsers();
        IUserRepository<TbAccounts> GetTbAccounts();
        IUserRepository<TbUserRoles> GetTbUserRoles();
        IUserRepository<TbRoles> GetTbRoles();
    }
    public class RepositoryAccessor : IRepositoryAccessor {
        private readonly IUserRepository<TbUsers> _tbUsers;
        private readonly IUserRepository<TbAccounts> _tbAccounts;
        private readonly IUserRepository<TbUserRoles> _tbUserRoles;
        private readonly IUserRepository<TbRoles> _tbRoles;

        public RepositoryAccessor(
            IUserRepository<TbUsers> tbUsers,
            IUserRepository<TbAccounts> tbAccounts,
            IUserRepository<TbUserRoles> tbUserRoles,
            IUserRepository<TbRoles> tbRoles
        ) {
            _tbUsers = tbUsers;
            _tbAccounts = tbAccounts;
            _tbUserRoles = tbUserRoles;
            _tbRoles = tbRoles;
        }

        public IUserRepository<TbAccounts> GetTbAccounts() {
            return _tbAccounts;
        }

        public IUserRepository<TbRoles> GetTbRoles() {
            return _tbRoles;
        }

        public IUserRepository<TbUserRoles> GetTbUserRoles() {
            return _tbUserRoles;
        }

        public IUserRepository<TbUsers> GetTbUsers() {
            return _tbUsers;
        }
    }
}
