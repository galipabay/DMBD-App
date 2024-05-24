using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMBD.Kernel.Model
{
	public class Department : BaseEntity
	{
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private string departmentName;

		public string DepartmentName
		{
			get { return departmentName; }
			set { departmentName = value; }
		}

	}
}
