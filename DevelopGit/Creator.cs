namespace DevelopGit;

public delegate void NotificationDelegate();
public class Creator
{
    public event NotificationDelegate OnNotification;


    public void Notify()
    {
        if (OnNotification != null)
        {
            OnNotification.Invoke();
        }
    }
    
}
