﻿using GameZone.Extensions;
using GameZone.ValidationAttributes;

namespace GameZone.ViewModels
{
    public class EditGameFormViewModel : GameFormViewModel
    {
        public int Id { get; set; }

        public string? CurrentCover { get; set; }

        [AllowedExtension(FileSettings.AllowedExtensions),
         MaxFileSize(FileSettings.MaxFileSizeInBytes)]

        public IFormFile? Cover { get; set; } = default!;
    }
}