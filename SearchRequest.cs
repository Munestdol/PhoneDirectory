using System.ComponentModel.DataAnnotations;

namespace PhoneDirectory
{
    public class SearchRequest
    {
        [Required(ErrorMessage = "The searchText field is required.")]
        public string SearchText { get; set; }
    }
}
