using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Swd.Bsp.Binding;

public partial class fCollectionBinding : Window
{
    private Window _callerWindow;
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
    
    public fCollectionBinding()
    {
        InitializeComponent();
    }

    public fCollectionBinding(Window callerWindows) : this()
    {
        _callerWindow = callerWindows;
        _customerList = new ObservableCollection<Customer>
        {
            new Customer{ Id = 1, Name = "Boban", Email = "boban@milojevic.at", PhoneNumber = "06604897138" },
            new Customer{ Id = 2, Name = "Boban1", Email = "boban@milojevic.at", PhoneNumber = "06604897138" },
            new Customer{ Id = 3, Name = "Boban2", Email = "boban@milojevic.at", PhoneNumber = "06604897138" }
        };

        lstCustomer.ItemsSource = _customerList;
        this.DataContext = _customerList;
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        Customer newCustomer = new Customer
            { Id = 4, Name = "Matthias", Email = "matthias@milojevic.at", PhoneNumber = "06604897138" };
        CustomerList.Add(newCustomer);
    }
}