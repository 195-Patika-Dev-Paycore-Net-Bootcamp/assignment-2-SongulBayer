using Assignments.Entity;
using Assignments.ValidationRules;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Assignment02Controller : ControllerBase
    {
        public static List<Staff> staffs = new List<Staff>() // Creating a list named staff
        {
            new Staff //Object added manually
            {
                Id=1,
                Name="Deny",
                LastName="Sellen",
                DateOfBirth=new DateTime(1989,01,01),
                Email="deny@gmail.com",
                PhoneNumber="555443366",
                Salary=4450
            },new Staff //Object added manually
            {
                Id=2,
                Name="Jhon",
                LastName="Jhairo",
                DateOfBirth=new DateTime(1995,10,07),
                Email="jhony@gmail.com",
                PhoneNumber="551125458",
                Salary=3500
            },new Staff //Object added manually
            {
                Id=3,
                Name="Rach",
                LastName="Geller",
                DateOfBirth=new DateTime(1970,09,06),
                Email="rach@gmail.com",
                PhoneNumber="555327498",
                Salary=5450
            },
        };
        //Created get method returning whole list
        [HttpGet]
        public List<Staff> GetListOfStaffs()
        {
            var staffList = staffs.OrderBy(x => x.Id).ToList<Staff>();
            return staffList;
        }
        //Listed by id
        [HttpGet("{id}")]
        public Staff GetById(int id)
        {
            var staff = staffs.Where(staffs => staffs.Id == id).SingleOrDefault();  //The existence of the object was checked according to the incoming id.
            return staff;
        }
        //Object of type Staff has been added to the list.
        [HttpPost]
        public IActionResult AddStaff([FromBody] Staff newStaff)
        {
            StaffRules rules = new StaffRules();
            try
            {
                ValidationResult result = rules.Validate(newStaff);
                rules.ValidateAndThrow(newStaff); //validations checked
                var staffId = staffs.SingleOrDefault(x => x.Id == newStaff.Id);

                if (staffId is not null)
                    return BadRequest();
                else
                {
                    staffs.Add(newStaff);
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


            return Ok();

        }
        //Data update process
        [HttpPut("{id}")]
        public IActionResult UpdateStaffs(int id, [FromBody] Staff updateStaff)
        {
            var staff = staffs.SingleOrDefault(x => x.Id == updateStaff.Id);
            if (staff is null)
                return BadRequest();

            staff.Name = updateStaff.Name != default ? updateStaff.Name : staff.Name; //Checking if the data has been changed before
            staff.LastName = updateStaff.LastName != default ? updateStaff.LastName : staff.LastName;
            staff.Email = updateStaff.Email != default ? updateStaff.Email : staff.Email;
            staff.Salary = updateStaff.Salary != default ? updateStaff.Salary : staff.Salary;
            staff.PhoneNumber = updateStaff.PhoneNumber != default ? updateStaff.PhoneNumber : staff.PhoneNumber;
            staff.DateOfBirth = updateStaff.DateOfBirth != default ? updateStaff.DateOfBirth : staff.DateOfBirth;
            return Ok();
        }
        // Data deletion process
        [HttpDelete("{id}")]
        public IActionResult RemoveStaff(int id)
        {
            var staff = staffs.SingleOrDefault(x => x.Id == id);
            if (staff is null)
                return BadRequest();

            staffs.Remove(staff);
            return Ok();
        }

    }
}
