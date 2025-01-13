// CoR
class CheckerDirector
{
    public bool MakeUserCheker(User user)
    {
        UserNameCheker userNameChecker = new UserNameCheker();
        PasswordCheker passwordChecker = new PasswordCheker();
        EmailChecker emailChecker = new EmailChecker();
        userNameChecker.Next = passwordChecker;
        passwordChecker.Next = emailChecker;
        return userNameChecker.Check(user);
    }
}