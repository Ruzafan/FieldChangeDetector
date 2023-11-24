using ChangeDetectorLibrary;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Xunit.Abstractions;

namespace ChangeDetectableCodeGenerator.Tests
{
    public class MongoChangeDetectableTest
    {
        [MongoChangeDetectable]
        public int Id { get; set; }
        [MongoChangeDetectable]
        public string Name { get; set; }
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

            var updateDefinition = new List<UpdateDefinition<MongoChangeDetectableTest>>();
            updateDefinition.Add(Builders<MongoChangeDetectableTest>.Update.Set(q => q.Id, toCompareObject.Id));


            var expectedresult = Builders<MongoChangeDetectableTest>.Update.Combine(updateDefinition);
            var expectedRendered = expectedresult.Render(BsonSerializer.LookupSerializer<MongoChangeDetectableTest>(), new BsonSerializerRegistry()).ToString();
            var resultRendered = result.Render(BsonSerializer.LookupSerializer<MongoChangeDetectableTest>(), new BsonSerializerRegistry()).ToString();
            resultRendered.Should().Be(expectedRendered);
        }

        [Fact]
        public void TestShouldBeDifferentFail()
        {
            var comparedObject = new MongoChangeDetectableTest
            {
                Name = "Foo",
                Id = 1
            };
            var toCompareObject = new MongoChangeDetectableTest
            {
                Name = "Foo",
                Id = 1
            };

            var result = comparedObject.GetMongoUpdateDefinitionOfDifferences(toCompareObject);

            var updateDefinition = new List<UpdateDefinition<MongoChangeDetectableTest>>();
            updateDefinition.Add(Builders<MongoChangeDetectableTest>.Update.Set(q => q.Id, toCompareObject.Id));


            var expectedresult = Builders<MongoChangeDetectableTest>.Update.Combine(updateDefinition);
            var expectedRendered = expectedresult.Render(BsonSerializer.LookupSerializer<MongoChangeDetectableTest>(), new BsonSerializerRegistry()).ToString();
            var resultRendered = result.Render(BsonSerializer.LookupSerializer<MongoChangeDetectableTest>(), new BsonSerializerRegistry()).ToString();
            resultRendered.Should().NotBe(expectedRendered);
        }

        [Fact]
        public void TestShouldBeDifferentFailBecauseDescriptionHasNotTheAttribute()
        {
            var comparedObject = new MongoChangeDetectableTest
            {
                Name = "Foo",
                Id = 1,
                Description= "Original value"
            };
            var toCompareObject = new MongoChangeDetectableTest
            {
                Name = "Foo",
                Id = 1,
                Description= "Changed"
            };

            var result = comparedObject.GetMongoUpdateDefinitionOfDifferences(toCompareObject);

            var updateDefinition = new List<UpdateDefinition<MongoChangeDetectableTest>>();
            updateDefinition.Add(Builders<MongoChangeDetectableTest>.Update.Set(q => q.Description, toCompareObject.Description));


            var expectedresult = Builders<MongoChangeDetectableTest>.Update.Combine(updateDefinition);
            var expectedRendered = expectedresult.Render(BsonSerializer.LookupSerializer<MongoChangeDetectableTest>(), new BsonSerializerRegistry()).ToString();
            var resultRendered = result.Render(BsonSerializer.LookupSerializer<MongoChangeDetectableTest>(), new BsonSerializerRegistry()).ToString();
            resultRendered.Should().NotBe(expectedRendered);
        }
    }
}
