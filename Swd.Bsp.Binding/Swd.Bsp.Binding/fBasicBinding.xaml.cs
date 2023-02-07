using System.Windows;

namespace Swd.Bsp.Binding;

public partial class fBasicBinding : Window
{
    private Window _callerWindow;

    public Window CallerWindow 
    {
        get
        {
            return _callerWindow;
        }
        set
        {
            _callerWindow = value;
        } 
    }
    
    public fBasicBinding()
    {
        InitializeComponent();
    }
    
    public fBasicBinding(Window callerWindows) : this()
    {
        _callerWindow = callerWindows;
    }

    private void BtnBack_OnClick(object sender, RoutedEventArgs e)
    {
        CallerWindow.Show();
        this.Close();
    }
}