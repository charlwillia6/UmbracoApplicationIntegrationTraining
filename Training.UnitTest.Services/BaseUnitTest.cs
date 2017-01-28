using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Training.Services.OnlineStore.Concretes;

namespace Training.UnitTest.Services
{
    public class BaseUnitTest
    {
        protected readonly PetaPocoProductService PetaPocoProductService;
        protected readonly PetaPocoCategoryService PetaPocoCategoryService;
        protected Mock<HttpContextBase> Context { get; private set; }

        public BaseUnitTest()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var indexOfBin = baseDirectory.LastIndexOf(@"\bin\", StringComparison.CurrentCultureIgnoreCase);
            var appDataPath = string.Format(@"{0}\App_Data\", baseDirectory.Substring(0, indexOfBin));
            
            // Set |DataDirectory| value
            AppDomain.CurrentDomain.SetData("DataDirectory", appDataPath);

            Context = new Mock<HttpContextBase>();
            Context.Setup(ctx => ctx.Session).Returns(new HttpSessionMock());

            PetaPocoCategoryService = new PetaPocoCategoryService("onlineStoreDbTest");
            PetaPocoProductService = new PetaPocoProductService("onlineStoreDbTest");
        }

        [TestCleanup()]
        public void CleanDataBase()
        {
            PetaPocoProductService.GetAll(null).ToList().ForEach(PetaPocoProductService.Delete);
            PetaPocoCategoryService.GetAll().ToList().ForEach(PetaPocoCategoryService.Delete);
        }
    }

    internal sealed class HttpSessionMock : HttpSessionStateBase
    {
        private readonly Dictionary<string, object> objects = new Dictionary<string, object>();

        public override object this[string name]
        {
            get { return (objects.ContainsKey(name)) ? objects[name] : null; }
            set { objects[name] = value; }
        }
    }
}
