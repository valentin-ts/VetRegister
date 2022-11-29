using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VetRegister.Data.Models;

namespace VetRegister.Data.Models

{
    public abstract class Person
    {
        public int Id { get; set; }

        public string PersonId { get; set; }

        [MaxLength(20)]
        public string FullName { get; set; }
    }
}
