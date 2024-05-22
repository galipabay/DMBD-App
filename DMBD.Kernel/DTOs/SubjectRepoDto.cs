using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMBD.Kernel.DTOs
{
	public class SubjectRepoDto : BaseDto
	{
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private string subjectCode;

		public string SubjectCode
		{
			get { return subjectCode; }
			set { subjectCode = value; }
		}

		private string subjectName;

		public string SubjectName
		{
			get { return subjectName; }
			set { subjectName = value; }
		}

		private int akts;

		public int Akts
		{
			get { return akts; }
			set { akts = value; }
		}

		private int credit;

		public int Credit
		{
			get { return credit; }
			set { credit = value; }
		}
	}
}
