using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMBD.Kernel.Model
{
	public class AdminUser
	{
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private int name;

		public int Name
		{
			get { return name; }
			set { name = value; }
		}

		private int surname;

		public int Surname
		{
			get { return surname; }
			set { surname = value; }
		}

		private int mailAddres;

		public int MailAddres
		{
			get { return mailAddres; }
			set { mailAddres = value; }
		}

		private int password;

		public int Password
		{
			get { return password; }
			set { password = value; }
		}

	}
}
