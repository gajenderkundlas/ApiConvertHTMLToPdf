using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppDataAccess.DBEntity;

namespace TestAppDataAccess
{
    public class TestAppDBContext: DbContext
    {
        /// <summary>
        /// Constructor for adding options
        /// </summary>
        /// <param name="options"></param>
        public TestAppDBContext(DbContextOptions options)
            : base(options)
        {
            
        }
        
        public DbSet<UserEntity> Users { get; set; }
    }
}
