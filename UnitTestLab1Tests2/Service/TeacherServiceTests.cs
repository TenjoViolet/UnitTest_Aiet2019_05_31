using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestLab1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestLab1.Repository;
using UnitTestLab1.ODT;
using NSubstitute;
namespace UnitTestLab1.Service.Tests
{
    [TestClass()]
    public class TeacherServiceTests
    {
        TeacherService _teacher;
        //List<ODT.Teacher> _result;
        ITeacherRepository _stubTeacher;

        [TestInitialize]
        public void Initial()
        {
            _stubTeacher = Substitute.For<ITeacherRepository>();
            _teacher = new TeacherService(_stubTeacher);
            //_result = _teacher.CheckTeacherQualifications();
        }

        /// <summary>
        /// 取代原TeacherService的取資料
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="result"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        private List<Teacher> CheckTeacher(string name, int age, QualificationsResult result,int hour,TeacherType type)
        {
            _stubTeacher.SelectTeachers().Returns(new List<Teacher>
            {
                new Teacher{Name=name,Age=age,CheckResult=result,Hour=hour,Type=type }
            });
            return _teacher.CheckTeacherQualifications();
        }



        [TestMethod()]
        public void CheckTeacherQualificationsTest超過65歲回傳AgeFaild()
        {

            var expect = ODT.QualificationsResult.AgeFaild;
            //var actual = _result.FirstOrDefault(p => p.Name == "T1").CheckResult = expect;
            var result = CheckTeacher("T1", 66, QualificationsResult.AgeFaild, 50,TeacherType.內聘);
            //var actual = result.FirstOrDefault().CheckResult = expect;
            var actual = result.FirstOrDefault().CheckResult;
            //Assert.AreEqual(ODT.QualificationsResult.AgeFaild, actual);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void CheckTeacherQualificationsTest外聘超過60小時回傳MinHourFaild()
        {
            //var expect = ODT.QualificationsResult.MinHourFaild;
            //var actual = _result.FirstOrDefault(p => p.Name == "T3").CheckResult = expect;
            //Assert.AreEqual(ODT.QualificationsResult.MinHourFaild, actual);
            var expect = ODT.QualificationsResult.MinHourFaild;
            var result = CheckTeacher("T3", 34, QualificationsResult.MinHourFaild, 61,TeacherType.外聘);
            //var actual = result.FirstOrDefault().CheckResult = expect;
            var actual = result.FirstOrDefault().CheckResult;
            //Assert.AreEqual(ODT.QualificationsResult.MinHourFaild, actual);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void CheckTeacherQualificationsTest外聘超過80小時回傳MaxHourLimit()
        {
            //var expect = ODT.QualificationsResult.MaxHourFaild;
            //var actual = _result.FirstOrDefault(p => p.Name == "T5").CheckResult = expect;
            //Assert.AreEqual(ODT.QualificationsResult.MaxHourFaild, actual);

            var expect = ODT.QualificationsResult.MaxHourFaild;
            var result = CheckTeacher("T5", 31, QualificationsResult.MaxHourFaild,81, TeacherType.外聘);
            //var actual = result.FirstOrDefault().CheckResult = expect;
            var actual = result.FirstOrDefault().CheckResult;
            //Assert.AreEqual(ODT.QualificationsResult.MaxHourFaild, actual);
            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void CheckTeacherQualificationsTest內聘65歲以下回傳NoProblem()
        {
            //var expect = ODT.QualificationsResult.NoProblem;
            //var actual = _result.FirstOrDefault(p => p.Name == "T2").CheckResult = expect;
            //Assert.AreEqual(ODT.QualificationsResult.NoProblem, actual);

            var expect = ODT.QualificationsResult.NoProblem;
            var result = CheckTeacher("T2", 46, QualificationsResult.NoProblem, 85, TeacherType.內聘);
            //var actual = result.FirstOrDefault().CheckResult = expect;
            var actual = result.FirstOrDefault().CheckResult;
            //Assert.AreEqual(ODT.QualificationsResult.NoProblem, actual);
            Assert.AreEqual(expect, actual);
        }
    }
}