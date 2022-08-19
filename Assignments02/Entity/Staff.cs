using System;
using System.ComponentModel.DataAnnotations;

namespace Assignments.Entity
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public double Salary { get; set; }
    }
}
