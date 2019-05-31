using System;
using UnitTestLab1.Repository;

namespace UnitTestLab1.Factory
{
    public class RepositoryFactory
    {
        public static TeacherRepository GetTeacherRepository()
        {
            return new TeacherRepository();
        }
    }
}