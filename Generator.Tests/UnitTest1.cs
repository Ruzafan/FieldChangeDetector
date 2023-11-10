using Generator.Models;

namespace Generator.Tests
{
    public partial class ComparedObject
    {
        [Comparable]
        public string Name { get; set; }
        [Comparable]
        public string Id { get; set; }

    }
    //public static partial class ComparedObject
    //{
    //    public static Dictionary<string, object>  Compare<ComparedObject>(this ComparedObject obj1, ComparedObject obj2)
    //    {

    //    }

    //}
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

            comparedObject.Compare(comparedObject, toCompareObject);

        }
    }
}