using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetRegister.Data.Models;

namespace VetRegister.Data.models

{
    public abstract class Person
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public bool IsDoctor { get; set; }

        public bool IsOwner { get; set; }

    }
}
