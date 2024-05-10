using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMBD.Kernel
{
    public class Files:BaseEntity
    {
        #region Properties

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        private string tcNo;

        public string TcNo
        {
            get { return tcNo; }
            set { tcNo = value; }
        }

        private string transcript;

        public string Transcript
        {
            get { return transcript; }
            set { transcript = value; }
        }

        private string subjectContent;

        public string SubjectContent
        {
            get { return subjectContent; }
            set { subjectContent = value; }
        }

        #endregion Properties
    }
}
