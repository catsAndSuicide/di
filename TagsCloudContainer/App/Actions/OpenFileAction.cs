﻿using System.IO;
using System.Windows.Forms;
using TagsCloudContainer.App.Settings;
using TagsCloudContainer.Infrastructure.UiActions;

namespace TagsCloudContainer.App.Actions
{
    internal class OpenFileAction : IUiAction
    {
        private readonly AppSettings appSettings;

        public OpenFileAction(AppSettings appSettings)
        {
            this.appSettings = appSettings;
        }

        public MenuCategory Category => MenuCategory.File;
        public string Name => "Открыть...";
        public string Description => "Использовать файл как источник тегов";

        public void Perform()
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                InitialDirectory = Path.GetFullPath(appSettings.InputFileName),
                Filter = "Текстовые файлы (*.txt)|*.txt"
            };
            var res = dialog.ShowDialog();
            if (res == DialogResult.OK)
                appSettings.InputFileName = dialog.FileName;
        }
    }
}