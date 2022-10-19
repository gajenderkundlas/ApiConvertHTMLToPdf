using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppDataAccess.DBEntity
{
    public class UserEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }    
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string ApiKey { get; set; }
        public virtual string VerificationToken { get; set; }
        public virtual bool? IsVerified { get; set; }
        public virtual DateTime? VerifiedOn { get; set; }
        public virtual DateTime? CreatedOn { get; set; }

    }
}
