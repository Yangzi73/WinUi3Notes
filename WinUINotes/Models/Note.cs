using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;//作用:

namespace WinUINotes.Models
{
    /// <summary>
    /// 12
    /// </summary>
    public class Note
    {
        private StorageFolder storeageFolder = ApplicationData.Current.LocalFolder;
        public string Filename { get; set; } = String.Empty;
        public string Text { get; set; } = String.Empty;
        public DateTime Date {  get; set; } = DateTime.Now;

        //显示文件名和日期
        public string DisplayFilename_Date => $"{Filename} - {Date}";
        
        public Note()
        {
            Filename = "note" + DateTime.Now.ToBinary().ToString() + ".txt";
        }

        public async Task saveAsync()
        {
            //Save the note to the local folder
            StorageFile noteFile = (StorageFile) await storeageFolder.TryGetItemAsync(Filename);
            if (noteFile == null) {
                noteFile = await storeageFolder.CreateFileAsync(Filename, CreationCollisionOption.ReplaceExisting);
            }
            await FileIO.WriteTextAsync(noteFile, Text);
        }

        public async Task DeleteAsync()
        {
            //Delete the note from the local folder
            StorageFile noteFile = (StorageFile) await storeageFolder.TryGetItemAsync(Filename);
            if (noteFile != null)
            {
                await noteFile.DeleteAsync();
            }
            
        }
    }
}
