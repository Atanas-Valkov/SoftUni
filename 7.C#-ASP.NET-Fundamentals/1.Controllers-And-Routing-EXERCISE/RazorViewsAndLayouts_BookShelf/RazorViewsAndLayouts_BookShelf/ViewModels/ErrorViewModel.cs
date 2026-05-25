namespace RazorViewsAndLayouts_BookShelf.ViewModels
{
    public class ErrorViewModel
    {
        public string? RequestId
        {
            get; set;
        }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
