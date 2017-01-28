using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using onlineStoreDb;
using Training.Services.OnlineStore.Models;

namespace Training.UnitTest.Services
{
    [TestClass]
    public class PetaPocoProductServiceUnitTest : BaseUnitTest
    {
        [TestMethod]
        public void Are_Crud_Methods_Working()
        {
            var category1 = new Category() {Name = "Category 1" };
            PetaPocoCategoryService.Add(category1);
            var product1 = new Product() {Name = "Product 1", Price = 11, Category = category1.Id };
            var product2 = new Product() { Name = "Product 2", Price = 22, Category = category1.Id };

            // create
            var id1 = PetaPocoProductService.Add(product1);
            var id2 = PetaPocoProductService.Add(product2);
            Assert.IsNotNull(id1 != 0);
            Assert.IsNotNull(id2 != 0);

            // read
            var item1 = PetaPocoProductService.GetById(id1);
            var item2 = PetaPocoProductService.GetById(id2);
            Assert.IsNotNull(item1);
            Assert.IsNotNull(item2);

            // update
            var newPrice = 11.5M;
            item1.Price = newPrice;
            PetaPocoProductService.Update(item1);
            var updatedItem = PetaPocoProductService.GetById(id1);
            Assert.IsNotNull(updatedItem);
            Assert.IsTrue(newPrice == item1.Price);

            // delete
            PetaPocoProductService.Delete(id1);
            PetaPocoProductService.Delete(item2);
            var leftItems = PetaPocoProductService.GetAll(null);
            Assert.AreEqual(0, leftItems.Count());
        }

        [TestMethod]
        public void Get_Top_Rates()
        {
            // arrange
            var category1 = new Category() { Name = "Category 1" };
            PetaPocoCategoryService.Add(category1);
            var product1 = new Product() { Name = "Product 1", Price = 11, Category = category1.Id, Rates = 5 };
            var product2 = new Product() { Name = "Product 2", Price = 22, Category = category1.Id, Rates = 1 };
            var id1 = PetaPocoProductService.Add(product1);
            PetaPocoProductService.Add(product2);

            // act
            var result = PetaPocoProductService.GetTopRated(1);

            // assert
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(5, result.First().Rates);
            Assert.AreEqual(id1, result.First().Id);
        }

        [TestMethod]
        public void Get_Featured()
        {
            // arrange
            var category1 = new Category() { Name = "Category 1" };
            PetaPocoCategoryService.Add(category1);
            var product1 = new Product() { Name = "Product 1", Price = 11, Category = category1.Id, Rates = 5, HpFeatured = true};
            var product2 = new Product() { Name = "Product 2", Price = 22, Category = category1.Id, Rates = 1 };
            var id1 = PetaPocoProductService.Add(product1);
            PetaPocoProductService.Add(product2);

            // act
            var result = PetaPocoProductService.GetFeatured(1);

            // assert
            Assert.AreEqual(1, result.Count());
            Assert.IsTrue(result.First().HpFeatured);
            Assert.AreEqual(id1, result.First().Id);
        }

        [Ignore]
        public void Get_Top_Selling()
        {
            // no logic has been implemented yet into the concrete service
        }

        [TestMethod]
        public void When_Try_To_Search_Product_By_Name_List_Of_Products_Is_Returned_Properly()
        {
            // arrange
            var category1 = new Category() { Name = "Rock" };
            PetaPocoCategoryService.Add(category1);
            var product1 = new Product() { Name = "Product 1", Price = 11, Category = category1.Id, Rates = 5, HpFeatured = true };
            var product2 = new Product() { Name = "Product 2 MySearch", Price = 22, Category = category1.Id, Rates = 1 };
            var id1 = PetaPocoProductService.Add(product1);
            PetaPocoProductService.Add(product2);

            // act 1
            var totalItems = 0;
            var result = PetaPocoProductService.Search("MySearch", null, out totalItems);

            // assert 1
            Assert.AreEqual(1, totalItems);
        }

        [TestMethod]
        public void When_Try_To_Search_Product_By_Category_Name_List_Of_Products_Is_Returned_Properly()
        {
            // arrange
            var category1 = new Category() { Name = "Rock" };

            PetaPocoCategoryService.Add(category1);

            var product1 = new Product() { Name = "Product 1", Price = 11, Category = category1.Id, Rates = 5, HpFeatured = true };
            var product2 = new Product() { Name = "Product 2 MySearch", Price = 22, Category = category1.Id, Rates = 1 };
            var id1 = PetaPocoProductService.Add(product1);
            PetaPocoProductService.Add(product2);

            // act 1
            var totalItems = 0;
            var result = PetaPocoProductService.Search("Rock", null, out totalItems);

            // assert 1
            Assert.AreEqual(2, totalItems);
        }

        [TestMethod]
        public void When_Try_To_Search_Product_By_Category_Id_List_Of_Products_Is_Returned_Properly()
        {
            // arrange
            var category1 = new Category() { Name = "Rock" };
            var category2 = new Category() { Name = "Punk" };

            PetaPocoCategoryService.Add(category1);
            PetaPocoCategoryService.Add(category2);

            var product1 = new Product() { Name = "Product 1", Price = 11, Category = category1.Id, Rates = 5, HpFeatured = true };
            var product2 = new Product() { Name = "Product 2 MySearch", Price = 22, Category = category1.Id, Rates = 1 };
            var product3 = new Product() { Name = "Product 2 MySearch", Price = 22, Category = category2.Id, Rates = 1 };

            var id1 = PetaPocoProductService.Add(product1);
            var id2 = PetaPocoProductService.Add(product2);
            PetaPocoProductService.Add(product3);

            // act 1
            var totalItems = 0;
            var result = PetaPocoProductService.GetAll(new ProductSearchFilter() {CategoryId = category1.Id}, out totalItems);

            // assert 1
            Assert.AreEqual(2, totalItems);
        }
    }
}
