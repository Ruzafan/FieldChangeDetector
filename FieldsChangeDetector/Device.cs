using ChangeDetectorLibrary;

namespace FieldsChangeDetector
{
    public partial class Device
    {
        [ChangeDetectable]
        public string Id { get; set; }
        [ChangeDetectable]
        public string Name { get; set; }
        [ChangeDetectable]
        public string Description { get; set; }
        [ChangeDetectable]
        public DateTime CreationDate { get; set; }

        [ChangeDetectable]
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
