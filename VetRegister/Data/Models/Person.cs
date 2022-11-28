using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetRegister.Data.Models;

namespace VetRegister.Data.Models

{
    public class Person
    {
        public int Id { get; set; }

        public string PersonId { get; set; }


        public bool IsOwner { get; set; }

        public IEnumerable<Animal> Animals { get; set; } = new List<Animal>();


        public bool IsDoctor { get; set; }
        public IEnumerable<Exam> Exams { get; set; } = new List<Exam>();

    }
}
