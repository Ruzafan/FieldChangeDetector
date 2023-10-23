using BenchmarkDotNet.Attributes;
using RoslynComparatorGenerator;
using System.Reflection;

namespace FieldsChangeDetector
{
    [MemoryDiagnoser]
    public class DetectDiferentFieldsValues
    {
        private dynamic generatedInstance;
        public DetectDiferentFieldsValues()
        {
            var generatedCode = RoslynCodeGenerator.GenerateComparisonCode<Device>();
            Compiler compiler = new Compiler();
            Assembly generatedAssembly = compiler.CompileCode(generatedCode);

            if (generatedAssembly != null)
            {
                // Now, you have the compiled assembly containing your generated method.
                // You can reference and use this assembly in your other program.
                // Example:
                Type generatedType = generatedAssembly.GetType("RoslynComparer.ComparisonHelper");
                generatedInstance = Activator.CreateInstance(generatedType);

                // Use the result as needed.
            }
        }

        [Benchmark]
        public Dictionary<string, object> CheckDiferentFieldsReflection()
        {
            var device = new Device
            {
                Id = Guid.NewGuid().ToString(),
                CreationDate = DateTime.Now,
                Description = "Description",
                LastAccess = DateTime.Now,
                Name = "Test Name"
            };

            var deviceNew = new Device
            {
                Id = Guid.NewGuid().ToString(),
                CreationDate = DateTime.Now,
                Description = "Description",
                LastAccess = DateTime.Now,
                Name = "Test new Name"
            };

            return ReturnDiferentFields(device, deviceNew);
        }

        [Benchmark]
        public Dictionary<string, object> CheckDiferentFieldsManually()
        {
            var device = new Device
            {
                Id = Guid.NewGuid().ToString(),
                CreationDate = DateTime.Now,
                Description = "Description",
                LastAccess = DateTime.Now,
                Name = "Test Name"
            };

            var deviceNew = new Device
            {
                Id = Guid.NewGuid().ToString(),
                CreationDate = DateTime.Now,
                Description = "Description",
                LastAccess = DateTime.Now,
                Name = "Test new Name"
            };

            return ReturnDiferentFieldsManually(device, deviceNew);
        }

        [Benchmark]
        public Dictionary<string, object> CheckDiferentFieldsRoslyn()
        {
            var device = new Device
            {
                Id = Guid.NewGuid().ToString(),
                CreationDate = DateTime.Now,
                Description = "Description",
                LastAccess = DateTime.Now,
                Name = "Test Name"
            };

            var deviceNew = new Device
            {
                Id = Guid.NewGuid().ToString(),
                CreationDate = DateTime.Now,
                Description = "Description",
                LastAccess = DateTime.Now,
                Name = "Test new Name"
            };

            return generatedInstance.ReturnDiferentFieldsRoslyn(device, deviceNew);
        }


        public static Dictionary<string, object> ReturnDiferentFields<T>(T oldObject, T newObject)
        {
            var response = new Dictionary<string, object>();
            if (oldObject == null || newObject == null) { return null; }
            foreach (var property in oldObject.GetType().GetProperties())
            {
                if (property.GetValue(newObject) != property.GetValue(oldObject))
                {
                    response.Add(property.GetType().Name, property.GetValue(newObject));
                }
            }
            return response;
        }

        public static Dictionary<string, object> ReturnDiferentFieldsManually(Device oldObject, Device newObject)
        {
            var response = new Dictionary<string, object>();
            if(oldObject.Id != newObject.Id) response.Add("Id", newObject.Id);
            if (oldObject.LastAccess != newObject.LastAccess) response.Add("LastAccess", newObject.LastAccess);
            if (oldObject.CreationDate != newObject.CreationDate) response.Add("CreationDate", newObject.CreationDate);
            if (oldObject.Name != newObject.Name) response.Add("Name", newObject.Name);
            if (oldObject.Description != newObject.Description) response.Add("Description", newObject.Description);

            return response;
        }

    }
}
