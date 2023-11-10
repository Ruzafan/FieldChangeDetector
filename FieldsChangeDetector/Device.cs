using Generator.Models;

namespace FieldsChangeDetector
{
    public class Device
    {
        [Comparable]
        public string Id { get; set; }
        [Comparable]
        public string Name { get; set; }
        [Comparable]
        public string Description { get; set; }
        [Comparable]
        public DateTime CreationDate { get; set; }

        [Comparable]
        public DateTime LastAccess { get; set; }

        public Device()
        {
            Id = Guid.NewGuid().ToString();
            Name = "Test Device";
            Description = "Description";
            CreationDate = DateTime.UtcNow;
            LastAccess = DateTime.UtcNow;
        }
    }
}
