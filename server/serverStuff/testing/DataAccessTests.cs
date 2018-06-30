using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dataAccess;
using System.IO;

namespace testing
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class DataAccessTests
    {
        public DataAccessTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetAllMain()
        {
            repoMain repo = new repoMain();

            var o = repo.GetFirst();

            List<main> recs =  o.ToList<main>(); 

            Assert.IsTrue(o != null);
        }

        [TestMethod]
        public void AddTest()
        {
            main entity = new main();

            entity.Id = 7;
            entity.Name = "test2";

            FileStream oFileStream = new FileStream(@"C:\Users\khabilep\Downloads\the-big-lebowski_english-614584\The.Big.Lebowski.1998.1080p.BluRay.x264.srt", FileMode.Open, FileAccess.Read);
            int length = Convert.ToInt32(oFileStream.Length);

            byte[] fileData;

            fileData = new byte[length];

            oFileStream.Read(fileData, 0, length);
            oFileStream.Close();

            entity.Data = fileData;

            MinerDataAccess repo = new MinerDataAccess();
            repo.Add(entity);






        }
    }
}
