namespace EmailFormFormatProject.Server.Database.Model
{
    public class FormTemplate
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Template { get; set; }

        public bool IsActive { get; set; }

        public DateTime UploadDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
