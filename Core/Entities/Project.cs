namespace Core.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }

        public ProjectType ProjectType { get; set; }

        public int ProjectTypeId { get; set; }

        public ProjectYear ProjectYear { get; set; }

        public int ProjectYearId { get; set; }
        
    }
}