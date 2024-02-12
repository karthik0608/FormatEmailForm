namespace EmailFormFormatProject.Server.Model
{
    public class FormTemplateRequest
    {
        public IFormFile Attachment { get; set; }

        public string FormType { get; set; }

        public bool IsActive { get; set; }


    }
}
