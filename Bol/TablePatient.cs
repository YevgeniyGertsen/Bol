using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bol
{
    [Table("TablePatients")]
    public class TablePatient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string IIN { get; set; }

        public int MedOraganizationsId { get; set; }
    }

    [Table("TableUsers")]
    public class TableUsers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int MedOraganizationsId { get; set; }

        public virtual TableUserRoles TableUserRoles { get; set; }
        public virtual TableMedOraganizations TableMedOraganizations { get; set; }
    }

    [Table("TableUserRoles")]
    public class TableUserRoles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }

    [Table("TableMedOraganizations")]
    public class TableMedOraganizations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedOraganizationsId { get; set; }
        public string OrgName { get; set; }
    }

    [Table("TableStatuses")]
    public class TableStatuses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }
    [Table("TableRequests")]
    public class TableRequests
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReauestId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime FinishTime { get; set; }
        public int PatientId { get; set; }
        public int MedOraganizationsId { get; set; }
        public int StatusId { get; set; }

        public virtual TableMedOraganizations TableMedOraganizations { get; set; }
        public virtual TableStatuses TableStatuses { get; set; }
        public virtual TablePatient TablePatient { get; set; }
    }
}
