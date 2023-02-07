using System.Data.Common;
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

    private void BtnGetCustomer_OnClick(object sender, RoutedEventArgs e)
    {
        Customer c = new Customer { Id = 1, Name = "Boban", Email = "boban@milojevic.at", PhoneNumber = "06604897138" };
        this.DataContext = c;
    }
}