//using BenchmarkDotNet.Attributes;
////using RoslynComparatorGenerator;
//using System.Reflection;

//namespace FieldsChangeDetector
//{
//    [MemoryDiagnoser]
//    public class DetectDiferentFieldsValues
//    {
//        public DetectDiferentFieldsValues()
//        {

//        }

//        //[Benchmark]
//        //public Dictionary<string, object> CheckDiferentFieldsReflection()
//        //{
//        //    var device = new Device();

//        //    var deviceNew = new Device
//        //    {
//        //        Name = "Test new Name"
//        //    };

//        //    return ReturnDiferentFields(device, deviceNew);
//        //}

//        //[Benchmark]
//        //public Dictionary<string, object> CheckDiferentFieldsManually()
//        //{
//        //    var device = new Device();

//        //    var deviceNew = new Device
//        //    {
//        //        Name = "Test new Name"
//        //    };

//        //    return ReturnDiferentFieldsManually(device, deviceNew);
//        //}


//        //[Benchmark]
//        //public Dictionary<string, object> CheckDiferentFieldsManuallyButDifferent()
//        //{
//        //    var device = new Device();

//        //    var deviceNew = new Device
//        //    {
//        //        Name = "Test new Name"
//        //    };

//        //    return ReturnDiferentFieldsManuallyButDifferent(device, deviceNew);
//        //}

//        [Benchmark]
//        public Dictionary<string, object> CheckDiferentFieldsRoslyn()
//        {
//            var device = new Device();

//            var deviceNew = new Device
//            {
//                Name = "Test new Name"
//            };
//           // device.Compare(deviceNew);
            
//            return null;
//        }


//        public static Dictionary<string, object> ReturnDiferentFields<T>(T oldObject, T newObject)
//        {
//            var response = new Dictionary<string, object>();
//            if (oldObject == null || newObject == null) { return null; }
//            foreach (var property in oldObject.GetType().GetProperties())
//            {
//                if (property.GetValue(newObject) != property.GetValue(oldObject))
//                {
//                    response[property.GetType().Name] = property.GetValue(newObject);
//                }
//            }
//            return response;
//        }

//        public static Dictionary<string, object> ReturnDiferentFieldsManually(Device oldObject, Device newObject)
//        {
//            var response = new Dictionary<string, object>();
//            if (oldObject.Id != newObject.Id) response.Add("Id", newObject.Id);
//            if (oldObject.LastAccess != newObject.LastAccess) response.Add("LastAccess", newObject.LastAccess);
//            if (oldObject.CreationDate != newObject.CreationDate) response.Add("CreationDate", newObject.CreationDate);
//            if (oldObject.Name != newObject.Name) response.Add("Name", newObject.Name);
//            if (oldObject.Description != newObject.Description) response.Add("Description", newObject.Description);

//            return response;
//        }

//        public static Dictionary<string, object> ReturnDiferentFieldsManuallyButDifferent(Device oldObject, Device newObject)
//        {
//            var response = new Dictionary<string, object>();
//            if (oldObject.Id != newObject.Id) response.Add("Id", newObject.Id);
//            if (oldObject.LastAccess != newObject.LastAccess) response["LastAccess"] = newObject.LastAccess;
//            if (oldObject.CreationDate != newObject.CreationDate) response["CreationDate"] = newObject.CreationDate;
//            if (oldObject.Name != newObject.Name) response["Name"] = newObject.Name;
//            if (oldObject.Description != newObject.Description) response["Description"] = newObject.Description;

//            return response;
//        }

//    }
//}
