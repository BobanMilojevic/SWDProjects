using System.Windows;

namespace Swd.Bsp.Binding;

public partial class fObjectBinding : Window
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
    
    public fObjectBinding()
    {
        InitializeComponent();
    }
    
    public fObjectBinding(Window callerWindows) : this()
    {
        _callerWindow = callerWindows;
    }
}