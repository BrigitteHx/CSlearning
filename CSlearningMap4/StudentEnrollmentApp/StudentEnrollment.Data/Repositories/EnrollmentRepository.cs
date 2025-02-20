using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentEnrollment.Data.Contracts;

namespace StudentEnrollment.Data.Repositories
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(StudentEnrollmentDbContext db) : base(db)
        {
        }
    }
}
