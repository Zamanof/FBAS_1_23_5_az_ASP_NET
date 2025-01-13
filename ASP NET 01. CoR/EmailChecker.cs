// CoR
using System.Text.RegularExpressions;

class EmailChecker : BaseChecker
{
    public override bool Check(object request)
    {
        if (request is User user) 
        {
            return !string.IsNullOrEmpty(user.Email) 
                && new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?").IsMatch(user.Email);
        }
        return false;
    }
}