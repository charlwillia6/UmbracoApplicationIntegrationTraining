using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using onlineStoreDb;

namespace Training.UnitTest.Services
{
    [TestClass]
    public class PetaPocoCategoryServiceUnitTest : BaseUnitTest
    {
        [TestMethod]
        public void Are_Crud_Methods_Working()
        {
            var category1 = new Category() { Name = "Category 1" };
            var category2 = new Category() { Name = "Category 2" };

            // create
            var id1 = PetaPocoCategoryService.Add(category1);
            var id2 = PetaPocoCategoryService.Add(category2);
            Assert.IsNotNull(id1 != 0);
            Assert.IsNotNull(id2 != 0);

            // read
            var item1 = PetaPocoCategoryService.GetById(id1);
            var item2 = PetaPocoCategoryService.GetById(id2);
            Assert.IsNotNull(item1);
            Assert.IsNotNull(item2);

            // update
            var newName = "Category 1.1";
            item1.Name = newName;
            PetaPocoCategoryService.Update(item1);
            var updatedItem = PetaPocoCategoryService.GetById(id1);
            Assert.IsNotNull(updatedItem);
            Assert.IsTrue(newName == item1.Name);

            // delete
            PetaPocoCategoryService.Delete(id1);
            PetaPocoCategoryService.Delete(item2);
            var leftItems = PetaPocoCategoryService.GetAll();
            Assert.AreEqual(0, leftItems.Count());
        }
    }
}
