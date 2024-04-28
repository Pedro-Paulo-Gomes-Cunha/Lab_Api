
using System.Net.Mail;

namespace Lab.Domain.EntityValidations.EscolaValidation
{
    public static class EmailValidation
    {
        public static bool IsValid(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }
            return valid;
        }
    }
}
