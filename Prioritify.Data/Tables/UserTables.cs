using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Prioritify.Data.Tables {
    public class TbUsers {
        [Key]
        [Column("flUserId")]
        public int Id { get; set; }

        [Column("flFirstname")]
        public string Firstname { get; set; }

        [Column("flLastname")]
        public string Lastname { get; set; }
        [Column("flBirthDate")]
        public DateTime BirthDate { get; set; }
        [Column("flGender")]
        [EnumDataType(typeof(UserGender))]
        public UserGender Gender { get; set; }
        [Column("flStudyYear")]
        public int StudyYear { get; set; }
        [Column("flDegree")]
        [EnumDataType(typeof(Degree))]
        public Degree Degree { get; set; }

        [Column("flCreatedAt")]
        public DateTime CreatedAt { get; set; }
        [Column("flUpdatedAt")]
        public DateTime UpdatedAt { get; set; }
    }

    public class TbAccounts {
        [Key]
        [Column("flAccountId")]
        public int Id { get; set; }
        [Column("flUserId")]
        public int UserId { get; set; }
        [Column("flUsername")]
        public string Username { get; set; }

        [Column("flEmail")]
        public string Email { get; set; }
        [Column("flPhoneNumber")]
        public string PhoneNumber { get; set; }
        [Column("flPassword")]
        public string Password { get; set; }
        [Column("flCreatedAt")]
        public DateTime CreatedAt { get; set; }
        [Column("flUpdatedAt")]
        public DateTime UpdatedAt { get; set; }
    }

    public class TbUserRoles {
        [Key]
        [Column("flId")]
        public int Id { get; set; }
        [Column("flUserId")]
        public int UserId { get; set; }
        [Column("flAccountId")]
        public int AccountId { get; set; }
        [Column("flRoleId")]
        public int RoleId { get; set; }
        [Column("flCreatedAt")]
        public DateTime CreatedAt { get; set; }
        [Column("flUpdatedAt")]
        public DateTime UpdatedAt { get; set; }
    }

    public class TbRoles {
        [Key]
        [Column("flRoleId")]
        public int Id { get; set; }
        [Column("flRole")]
        [EnumDataType(typeof(Role))]
        public Role Role { get; set; }
        [Column("flCreatedAt")]
        public DateTime CreatedAt { get; set; }
        [Column("flUpdatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
    
    public enum UserGender {
        Male,
        Female
    }

    public enum Degree {
        Bachelor,
        Master,
        PhD
    }

    public enum Role {
        Administrator,
        User
    }
    
}
