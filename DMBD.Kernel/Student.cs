using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMBD.Kernel
{
    public class Student:BaseEntity
    {

        #region NullControlCtor
        public Student()
        {
            throw  new ArgumentNullException(nameof(Student.id));
            throw  new ArgumentNullException(nameof(Student.name));
            throw  new ArgumentNullException(nameof(Student.surname));
            throw  new ArgumentNullException(nameof(Student.mailAddress));
            throw  new ArgumentNullException(nameof(Student.registerType));
            throw  new ArgumentNullException(nameof(Student.preSchoolName));
            throw  new ArgumentNullException(nameof(Student.preFacultyName));
            throw  new ArgumentNullException(nameof(Student.preDepartmentName));
            throw  new ArgumentNullException(nameof(Student.departmentName));
            throw  new ArgumentNullException(nameof(Student.departmentId));
        }
        #endregion

        #region Properties

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int formId;

        public int FormId
        {
            get { return formId; }
            set { formId = value; }
        }

        private string studentId;
        public string StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }

        private string tcNo;

        public string TcNo
        {
            get { return tcNo; }
            set { tcNo = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string surname;

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        private string studentNo;

        public string StudentNo
        {
            get { return studentNo; }
            set { studentNo = value; }
        }


        private string mailAddress;

        public string MailAddress
        {
            get { return mailAddress; }
            set { mailAddress = value; }
        }

        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        private int registerType;

        public int RegisterType
        {
            get { return registerType; }
            set { registerType = value; }
        }

        private string preSchoolName;

        public string PreSchoolName
        {
            get { return preSchoolName; }
            set { preSchoolName = value; }
        }

        private string preFacultyName;

        public string PreFacultyName
        {
            get { return preFacultyName; }
            set { preFacultyName = value; }
        }

        private string preDepartmentName;

        public string PreDepartmentName
        {
            get { return preDepartmentName; }
            set { preDepartmentName = value; }
        }

        private string departmentName;

        public string DepartmentName
        {
            get { return departmentName; }
            set { departmentName = value; }
        }

        private string departmentId;

        public string DepartmentId
        {
            get { return departmentId; }
            set { departmentId = value; }
        }

        #endregion Properties
    }
}
