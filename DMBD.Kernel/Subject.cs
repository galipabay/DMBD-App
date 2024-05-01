using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMBD.Kernel
{
    public class Subject:BaseEntity
    {
        #region NullControlCtor
        public Subject()
        {
            throw new ArgumentNullException(nameof(Subject.subjectId));
            throw new ArgumentNullException(nameof(Subject.tcNo));
            throw new ArgumentNullException(nameof(Subject.subjectName));
            throw new ArgumentNullException(nameof(Subject.subjectCredit));
            throw new ArgumentNullException(nameof(Subject.subjectAkts));
            throw new ArgumentNullException(nameof(Subject.exemptSubjectName));
            throw new ArgumentNullException(nameof(Subject.exemptSubjectCredit));
            throw new ArgumentNullException(nameof(Subject.exemptSubjectAkts));
            throw new ArgumentNullException(nameof(Subject.exemptSubjectId));
            
        }
        #endregion

        #region Properties

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        private int subjectId;

        public int SubjectId
        {
            get { return subjectId; }
            set { subjectId = value; }
        }

        private string tcNo;

        public string TcNo
        {
            get { return tcNo; }
            set { tcNo = value; }
        }

        private string subjectName;

        public string SubjectName
        {
            get { return subjectName; }
            set { subjectName = value; }
        }

        private int subjectCredit;

        public int SubjectCredit
        {
            get { return subjectCredit; }
            set { subjectCredit = value; }
        }

        private int subjectAkts;

        public int SubjectAkts
        {
            get { return subjectAkts; }
            set { subjectAkts = value; }
        }

        private string exemptSubjectName;

        public string ExemptSubjectName
        {
            get { return exemptSubjectName; }
            set { exemptSubjectName = value; }
        }


        private int exemptSubjectCredit;

        public int ExemptSubjectCredit
        {
            get { return exemptSubjectCredit; }
            set { exemptSubjectCredit = value; }
        }

        private int exemptSubjectAkts;

        public int ExemptSubjectAkts
        {
            get { return exemptSubjectAkts; }
            set { exemptSubjectAkts = value; }
        }

        private string exemptSubjectId;

        public string ExemptSubjectId
        {
            get { return exemptSubjectId; }
            set { exemptSubjectId = value; }
        }

        #endregion Properties
    }
}
