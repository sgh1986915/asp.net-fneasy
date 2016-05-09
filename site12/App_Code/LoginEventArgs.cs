using System;

public class LoginEventArgs : EventArgs
{
    public LoginEventArgs(string username, string password)
    {
        _username = username;
        _password = password;
    }
    private string _username;
    public string username
    {
        get { return _username; }
        set { _username = value; }
    }

    private string _password;
    public string password
    {
        get { return _password; }
        set { _password = value; }
    }

}