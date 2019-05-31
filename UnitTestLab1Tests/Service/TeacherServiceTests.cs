using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestLab1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestLab1.ODT;


namespace UnitTestLab1.Service.Tests
{
    [TestClass()]
    public class TeacherServiceTests
    {

        TeacherService _teacher;


        [TestMethod()]
        public void CheckTeacherQualificationsTest超過65歲回傳AgeFaild()
        {
            var teacher = new TeachearServicse();
            var result = teacher.checkTeacherQualifications();
            var actual = result.FirstOrDefault(p => p.Name == "T1").CheckResult = ODT.QualificationResult.AgeFaild;
            Assert.AreEqual(ODT.QualificationResult.AgeFaild, actual);
        }

        [TestMethod()]
        public void CheckTeacherQualificationsTest外聘超過60小時回傳MinHourLimit()
        {
            var teacher = new TeachearServicse();
            var result = teacher.checkTeacherQualifications();
        }

        [TestMethod()]
        public void CheckTeacherQualificationsTest外聘超過60小時回傳MaxHourLimit()
        {
            var teacher = new TeachearServicse();
            var result = teacher.checkTeacherQualifications();
        }

        [TestMethod()]
        public void CheckTeacherQualificationsTest內聘65歲以下回傳NoProblem()
        {
            var teacher = new TeachearServicse();
            var result = teacher.checkTeacherQualifications();
        }



    }
}