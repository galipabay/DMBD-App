﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMBD.Kernel.Model
{
	public class AdminUser: BaseEntity
	{
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
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

		private string mailAddres;
        [Required(ErrorMessage = "E-mail alanı gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-mail adresi giriniz.")]
        public string MailAddres
		{
			get { return mailAddres; }
			set { mailAddres = value; }
		}

		private string password;
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [StringLength(50, ErrorMessage = "Şifre en fazla 50 karakter olabilir.")]
        public string Password
		{
			get { return password; }
			set { password = value; }
		}

	}
}
