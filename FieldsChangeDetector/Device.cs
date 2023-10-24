namespace FieldsChangeDetector
{
    public class Device
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

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
