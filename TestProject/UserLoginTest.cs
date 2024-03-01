using HospitalSystemManagement;
using HospitalSystemManagement.BusinessLogic;
using HospitalSystemManagement.Model;
using HospitalSystemManagement.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Windows.Markup;

namespace TestProject
{
    [TestClass]
    public class UserLoginTest
    {
      //  [TestMethod]
        public void LoginTest() {
        UserLogic userLogin=new UserLogic();
            #region UserLogin
            // Assert.IsTrue(userLogin.Login("Osama","123"));

            //  Assert.IsFalse(userLogin.Login("Osama", "1234")); 
            #endregion

            #region GetUsers
            //Assert.IsNotNull(userLogin.getUsers("Osama"));
            //Assert.IsNotNull(userLogin.getUsers("admin")); 
            #endregion
        
        }

     //   [TestMethod]
        public void DepartmentTest() {
        DepartmentLogic departmentLogic=new DepartmentLogic();

            #region AddDept
            // Assert.IsTrue(departmentLogic.addDept("Ramad","Ramad Desc")); 
            // Assert.IsTrue(departmentLogic.addDept("", "Ramad Desc"));
            #endregion

            #region Update Department

            //  Assert.IsTrue(departmentLogic.updateDept(1,"Ram","Ram Desc"));
            //  Assert.IsTrue(departmentLogic.updateDept(1, "Ram", "Ram Desc")); 
            #endregion

            #region SearchDept
            //  Assert.IsNotNull(departmentLogic.getAllDept());
            //  Assert.IsNotNull(departmentLogic.getDept(7)); 
            #endregion

            #region DeleteDept
            // departmentLogic.deleteDept(5);
            //  departmentLogic.deleteDept(6); 
            #endregion

            #region Search Dept
            // departmentLogic.searchDept("ram"); 
            #endregion

        }

     //   [TestMethod]
        public void FlootTest() {
            FloorLogic floorLogic = new FloorLogic();

            #region Chech Name
            // Assert.IsTrue(floorLogic.CheckName("First"));
            // Assert.IsTrue(floorLogic.CheckName("Third"));
            #endregion

            #region Add
            // floorLogic.AddFloor("Third",6);
            //  floorLogic.AddFloor("Third", 6);
            #endregion

            #region Update
            // floorLogic.UpdateFloor(5, "Second","Second", 11);
            //  floorLogic.UpdateFloor(5, "Second", "First", 11);
            #endregion

            #region Delete
           // floorLogic.DeleteFloor(7);
          //  floorLogic.DeleteFloor(4);
            #endregion

        }

       // [TestMethod]
        public void RoomTest() {
            RoomLogic roomLogic = new RoomLogic();
            FloorLogic floorLogic = new FloorLogic();
            DepartmentLogic departmentLogic = new DepartmentLogic();

            #region Get
            // Assert.IsNotNull(roomLogic.GetAllRoom());
            // Assert.IsNull(roomLogic.GetAllRoom());

            //  Assert.IsNotNull(floorLogic.GetFloor(4));
            //  Assert.IsNotNull(floorLogic.GetFloor(7)); 
            #endregion


            #region Add
            //  Assert.IsTrue(roomLogic.AddRoom(departmentLogic.getDept(1), floorLogic.GetFloor(4)));
            //  Assert.IsTrue(roomLogic.AddRoom(departmentLogic.getDept(1), floorLogic.GetFloor(8)));

            #endregion

            #region Edit
            //Assert.IsTrue(roomLogic.UpdateRoom(25,departmentLogic.getDept(18), floorLogic.GetFloor(12)));
            #endregion

            #region Delete
            //roomLogic.DeleteRoom(22);
            #endregion


        }
        [TestMethod]
        public void Patient() {
            PatientLogic patientLogic = new PatientLogic();

            #region Get
            // Assert.IsNotNull(patientLogic.GetPatient(8));
            //  Assert.IsNotNull(patientLogic.GetAllPatients());
            #endregion
            DataContext dataContext = new DataContext();
            RoomLogic roomLogic = new RoomLogic();
            Doctor doctor = dataContext.Doctors.First(d => d.ID == 5);
            
          // Assert.IsTrue(patientLogic.AddPatient("Abdallah","2323233","Minia","01134348984","Heart","A",5,roomLogic.GetRoom(19)));
            Assert.IsTrue(patientLogic.UpdatePatient(20,"Khaled", "2323233", "Minia", "01134348984", "Heart", "A", 2, 36,29));

        }



    }
}
