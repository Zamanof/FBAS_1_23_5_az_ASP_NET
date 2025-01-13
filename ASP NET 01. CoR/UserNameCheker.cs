// CoR
class UserNameCheker : BaseChecker
{
    public override bool Check(object request)
    {
        if (request is User user)
        {
            if (!string.IsNullOrWhiteSpace(user.UserName))
            {
                return Next.Check(request);
            }
        }
        return false;
    }
}

