using GameZone.Extensions;
using GameZone.ValidationAttributes;

namespace GameZone.ViewModels
{
    public class CreateGameFormViewModel : GameFormViewModel
    {


        [AllowedExtension(FileSettings.AllowedExtensions),
          MaxFileSize(FileSettings.MaxFileSizeInBytes)]

        public IFormFile Cover { get; set; } = default!;
    }
}
