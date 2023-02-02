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
        CollectionItem item = GetCollectionItem();

        CollectionItemRepository repo = new CollectionItemRepository();
        repo.Add(item);
        
        Assert.AreNotEqual(0, item.Id);
    }
    
    [TestMethod]
    public async Task Add_CollectionItemAsync()
    {
        CollectionItem item = GetCollectionItem();

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
        CollectionItem item = GetCollectionItem();
        item.Price = Convert.ToDecimal(price);

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
        CollectionItem item = GetCollectionItem();

        string itemName = item.Name;
        repo.Add(item);

        CollectionItem addedItem = repo.GetById(item.Id);
        addedItem.Name = string.Format("TestItem{0}", DateTime.Now);
        repo.Update(addedItem, addedItem.Id);

        CollectionItem updateItem = repo.GetById(item.Id);
        
        Assert.AreNotEqual(itemName, updateItem.Name);
    }
    
    [TestMethod]
    public async Task Update_CollectionItemAsync()
    {
        CollectionItemRepository repo = new CollectionItemRepository();
        CollectionItem item = GetCollectionItem();

        string itemName = item.Name;
        await repo.AddAsync(item);

        CollectionItem addedItem = repo.GetById(item.Id);
        addedItem.Name = string.Format("TestItem{0}", DateTime.Now);
        await repo.UpdateAsync(addedItem, addedItem.Id);

        CollectionItem updateItem = repo.GetById(item.Id);
        
        Assert.AreNotEqual(itemName, updateItem.Name);
    }
    
    [TestMethod]
    public void Delete_CollectionItem()
    {
        CollectionItemRepository repo = new CollectionItemRepository();
        CollectionItem item = GetCollectionItem();
        
        repo.Add(item);
        repo.Delete(item.Id);
        
        CollectionItem deletedItem = repo.GetById(item.Id);

        Assert.IsNull(deletedItem);
    }
    
    [TestMethod]
    public async Task Delete_CollectionItemAsync()
    {
        CollectionItemRepository repo = new CollectionItemRepository();
        CollectionItem item = GetCollectionItem();
        
        await repo.AddAsync(item);
        await repo.DeleteAsync(item.Id);
        
        CollectionItem deletedItem = repo.GetById(item.Id);

        Assert.IsNull(deletedItem);
    }
    
    [TestMethod]
    public void GetAll_CollectionItem()
    {
        CollectionItem item = GetCollectionItem();
        
        CollectionItemRepository repo = new CollectionItemRepository();
        repo.Add(item);
        
        int itemCount = repo.GetAll().Count();
        Assert.AreNotEqual(0,itemCount);
    }


    private static CollectionItem GetCollectionItem()
    {
        CollectionItem item = new CollectionItem();
        item.Name = "TestItem";
        item.CreatedDate = DateTime.Now;
        item.CreatedBy = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        return item;
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