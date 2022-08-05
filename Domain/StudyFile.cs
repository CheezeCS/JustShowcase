namespace Domain
{
    public class StudyFile
    {
        public Guid Id { get; set; }
        public long Size { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public byte Course { get; set; }
        public string Subject { get; set; }
        public string Tags { get; set; }
    }
}