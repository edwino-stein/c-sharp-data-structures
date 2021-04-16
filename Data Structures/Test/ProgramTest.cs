using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataStructures;
using System.IO;

namespace DataStructuresTest
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void MainTest()
        {
            
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.Main();

                var result = sw.ToString().Trim();
                Assert.AreEqual("Hello World!", result);
            }
        }
    }
}
