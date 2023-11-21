using ChangeDetectorLibrary;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ChangeDetectableCodeGenerator.Tests
{
    public class MongoChangeDetectableTest
    {
        [MongoChangeDetectable]
        public int Id { get; set; }
        [MongoChangeDetectable]
        public string Name { get; set; }
        [MongoChangeDetectable]
        public string Description { get; set; }

    }

    public class MongoBuilderGeneratedTest
    {

       

        [Fact]
        public void Test()
        {
            var comparedObject = new MongoChangeDetectableTest
            {
                Name = "Foo",
                Id = 1
            };
            var toCompareObject = new MongoChangeDetectableTest
            {
                Name = "Foo",
                Id = 2
            };

            var result = comparedObject.GetMongoUpdateDefinitionOfDifferences(toCompareObject);

            //Assert.True(result.First().Key == "Id");
            //Assert.True(result.First().Value == toCompareObject.Id);

           // var expectedResult = Builders<MongoChangeDetectableTest>.Update.Set(q => q.Id, toCompareObject.Id);
           //result.ToJson(typeof(MongoChangeDetectableTest)).Should().Be(expectedResult.ToJson(typeof(MongoChangeDetectableTest)));
        }
    }
}
