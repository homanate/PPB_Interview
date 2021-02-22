using NUnit.Framework;

namespace LiabilityReportTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            //LiabilityReport.
        }

        [Test]
        public void ReadFile_FileExist_ReturnsString()
        {
            Assert.Pass();
        }

        [Test]
        public void ReadFile_FileDoesNotExist_ReturnsNull()
        {
            Assert.Pass();
        }
    }
}