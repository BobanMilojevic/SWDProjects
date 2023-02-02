using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Swd.PlayCollector.Model;
using Swd.PlayCollector.Repository;

namespace Swd.PlayCollector.Test;

[TestClass]
public class TestRepository
{
    public TestRepository()
    {
        EmptyDatabase();
    }
    
    [TestMethod]
    public void Add_CollectionItem()
    {
        CollectionItem item = new CollectionItem();
        item.Name = "TestItem";
        item.CreatedDate = DateTime.Now;
        item.CreatedBy = "User";
        //item.CreatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        CollectionItemRepository repo = new CollectionItemRepository();
        repo.Add(item);
        
        Assert.AreNotEqual(0, item.Id);
    }
    
    [TestMethod]
    public async Task Add_CollectionItemAsync()
    {
        CollectionItem item = new CollectionItem();
        item.Name = "TestItem";
        item.CreatedDate = DateTime.Now;
        item.CreatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        CollectionItemRepository repo = new CollectionItemRepository();
        await repo.AddAsync(item);
        
        Assert.AreNotEqual(0, item.Id);
    }
    
    [TestMethod]
    [DataRow(0.0)]
    [DataRow(-10.0)]
    [DataRow(10.0)]
    public void Add_CollectionItemWithPrice(double price)
    {
        CollectionItem item = new CollectionItem();
        item.Name = "TestItem";
        item.Price = Convert.ToDecimal(price);
        item.CreatedDate = DateTime.Now;
        item.CreatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        CollectionItemRepository repo = new CollectionItemRepository();
        repo.Add(item);
        
        Assert.AreNotEqual(0, item.Id);
    }
    
    [TestMethod]
    public void Add_Location()
    {
        Location item = new Location();
        item.Name = "TestLocation";
        item.CreatedDate = DateTime.Now;
        item.CreatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        LocationRepository repo = new LocationRepository();
        repo.Add(item);
        
        Assert.AreNotEqual(0, item.Id);
    }
    
    [TestMethod]
    public async Task Add_LocationAsync()
    {
        Location item = new Location();
        item.Name = "TestLocation";
        item.CreatedDate = DateTime.Now;
        item.CreatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        LocationRepository repo = new LocationRepository();
        await repo.AddAsync(item);
        
        Assert.AreNotEqual(0, item.Id);
    }
    
    [TestMethod]
    public void Update_CollectionItem()
    {
        CollectionItemRepository repo = new CollectionItemRepository();
        
        CollectionItem item = new CollectionItem();
        string itemName = "TestItem";
        item.Name = itemName;
        item.CreatedDate = DateTime.Now;
        item.CreatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        
        repo.Add(item);

        CollectionItem addedItem = repo.GetById(item.Id);
        addedItem.Name = string.Format("TestItem{0}", DateTime.Now);
        repo.Update(addedItem, addedItem.Id);

        CollectionItem updateItem = repo.GetById(item.Id);
        
        Assert.AreNotEqual(itemName, updateItem.Name);
    }
    
    [TestMethod]
    public void Delete_CollectionItem()
    {
        CollectionItemRepository repo = new CollectionItemRepository();
        
        CollectionItem item = new CollectionItem();
        string itemName = "TestItem";
        item.Name = itemName;
        item.CreatedDate = DateTime.Now;
        item.CreatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        
        repo.Add(item);
        repo.Delete(item.Id);
        
        CollectionItem deletedItem = repo.GetById(item.Id);

        Assert.IsNull(deletedItem);
    }
    
    [TestMethod]
    public void GetAll_CollectionItem()
    {
        CollectionItemRepository repo = new CollectionItemRepository();

        var items = repo.GetAll();
        var items2 = repo.GetAll().ToList();
        
        int itemCount = repo.GetAll().Count();
        Assert.AreNotEqual(0,itemCount);
    }


    public static void EmptyDatabase()
    {
        PlayCollectorContext testContext = new PlayCollectorContext();

        var command = testContext.Database.GetDbConnection().CreateCommand();
        command.CommandText = "spEmptyDatabase";
        command.CommandType = System.Data.CommandType.StoredProcedure;
        
        // Beispiel für einen Parameter der an die SP übergeben wird
        //command.Parameters.Add(new SqlParameter("parametername", "parametervalue"));
        
        testContext.Database.OpenConnection();
        command.ExecuteNonQuery();
        
        //Beispiel um Rückgabewerte zu verarbeiten
        /*var result = command.ExecuteReader();
        var dataTable = new DataTable();
        dataTable.Load(result);*/
    }
}