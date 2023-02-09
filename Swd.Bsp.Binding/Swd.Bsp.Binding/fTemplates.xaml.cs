using System.Collections.ObjectModel;
using System.Data.Common;
using System.Windows;

namespace Swd.Bsp.Binding;

public partial class fTemplates : Window
{
    private ObservableCollection<Customer> _customerList;
    public ObservableCollection<Customer> CustomerList
    {
        get
        {
            return _customerList;
        }
        set
        {
            _customerList = value;
        }
    }
    
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
    
    public fTemplates()
    {
        InitializeComponent();
    }
    
    public fTemplates(Window callerWindows) : this()
    {
        _callerWindow = callerWindows;
        _customerList = new ObservableCollection<Customer>
        {
            new Customer{ Id = 1, Name = "Boban", Email = "boban@milojevic.at", PhoneNumber = "06604897138" },
            new Customer{ Id = 2, Name = "Boban1", Email = "boban@milojevic.at", PhoneNumber = "06604897138" },
            new Customer{ Id = 3, Name = "Boban2", Email = "boban@milojevic.at", PhoneNumber = "06604897138" }
        };
        
        this.DataContext = _customerList;
    }
}