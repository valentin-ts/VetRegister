﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetRegister.Core.Models.Doctor;
using VetRegister.Core.Models.Procedure;
using VetRegister.Infrastructure.Data.Models;

namespace VetRegister.Core.Contracts
{
    public interface IDoctorService
    {
        public bool DoctorExists(int id);

        public int? GetDoctorId(string? userId);

        public DoctorViewModel? GetById(int id);

        public IEnumerable<DoctorViewModel> GetAllDoctors();

        public DoctorViewModel GetDoctorDetails(int id);

        public void CreateDoctor(Doctor newDoctor);
    }
}
