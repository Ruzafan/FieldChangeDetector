using ChangeDetectorLibrary;

namespace ChangeDetectableCodeGenerator.Tests
{
    public class ComparedObject
    {
        [ChangeDetectable]
        public string Name { get; set; }
        [ChangeDetectable]
        public string Id { get; set; }


    }


    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var comparedObject = new ComparedObject
            {
                Name = "Foo",
                Id = "1"
            };
            var toCompareObject = new ComparedObject
            {
                Name = "Foo",
                Id = "2"
            };

            var result = comparedObject.DetectChanges(toCompareObject);

            Assert.True(result.First().Key == "Id");
            Assert.True(result.First().Value == toCompareObject.Id);
        }
    }
}