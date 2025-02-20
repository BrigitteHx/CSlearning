using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data.Contracts;
using StudentEnrollment.Data.Repositories;

namespace StudentEnrollment.Data.Contracts
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<Course> GetStudentList(int courseId);
    }
}