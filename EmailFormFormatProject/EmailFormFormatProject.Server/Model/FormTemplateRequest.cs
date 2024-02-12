namespace EmailFormFormatProject.Server.Model
{
    public class FormTemplateRequest
    {
        public int Id { get; set; }

        public string Description { get; set; }
        
        public string HtmlContent { get; set; }

        public string FormType { get; set; }

        public bool IsActive { get; set; }
    }
}
