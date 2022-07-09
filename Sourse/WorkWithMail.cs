using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Sourse
{
    class WorkWithMail
    {
        private readonly MailAddress _from = new MailAddress("pizzalog711@gmail.com");
        private MailMessage _mail;
        private static int _key { get; set; }
        private static MailAddress _to;
        private static string _password;
        

        public WorkWithMail()
        {
        }
        public WorkWithMail(string to, string password, int key)
        {
            _to = new MailAddress(to);
            _key = key;
            _password = password;
            _mail = new MailMessage(_from, _to);
            _mail.Subject = "Pizza";
            _mail.Body = $"Your key: {_key}";
        }

        public int GetConfirmKey()
        {
            return _key;
        }
        public string GetConfirmLogin()
        {
            return _to.ToString();
        }
        public string GetConfirmPassword()
        {
            return _password;
        }
        public void SendMail()
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("pizzalog711@gmail.com", "meihapujqkiajgnq");
            smtp.EnableSsl = true;
            smtp.Send(_mail);
        }

        
        
    }
}
