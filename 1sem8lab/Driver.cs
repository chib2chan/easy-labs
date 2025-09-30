using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _1sem8lab
{
    //здесь изображена связь композиция - водитель и мед.книжка
    public class Driver
    {
        public string Name { get; set; }
        public int ExperienceYears { get; set; }
        public MedicalCertificate medicalCertificate { get;  }
        public Driver(string name, int experienceYears, int certificateNumber, DateTime issueDate, string doctorName)
        {
            Name = name;
            ExperienceYears = experienceYears;
            medicalCertificate = new MedicalCertificate(certificateNumber, issueDate, doctorName);
            //агрегация
        }
    }

    public class MedicalCertificate
    {
        public int CertificateNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public string DoctorName { get; set; }
        public MedicalCertificate(int certificateNumber, DateTime issueDate, string doctorName)
        {
            CertificateNumber = certificateNumber;
            IssueDate = issueDate;
            DoctorName = doctorName;
        }
    }
}