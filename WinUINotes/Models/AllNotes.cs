using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace WinUINotes.Models
{
    //这个类的作用，就是把所有文件都读出来，并保存在Note对象中
    public class AllNotes
    {
        public ObservableCollection<Note> Note { get; set; } = new ObservableCollection<Note>();
        //ObservableCollection : A collection that
        //provides notifications when items get added, removed, or when the whole list is refreshed.

        public AllNotes()
        {
            LoadNotes();
        }

        //加载所有笔记
        public async void LoadNotes()
        {
            Note.Clear();
            StorageFolder storeageFolder = ApplicationData.Current.LocalFolder;
            //Get all the files in the local folder
            await GetFilesInFolderAsync(storeageFolder);
        }

        //读取文件夹内所有文件
        private async Task GetFilesInFolderAsync(StorageFolder folder)
        {
            IReadOnlyList<StorageFile> storageItems = await folder.GetFilesAsync();
            //A ReadOnlyList to get all the files in the folder, and add them to the Note collection
            foreach (IStorageItem item in storageItems)
            {
                //item is a Folder 
                if (item.IsOfType(StorageItemTypes.Folder))
                {
                    //Recursively get all the files in the subfolder
                    await GetFilesInFolderAsync((StorageFolder) item);
                }
                //item is a File
                else if(item.IsOfType(StorageItemTypes.File))
                {
                    //这个file的作用，就是创建一个temp文件把item文件内容读出来，并保存在Note对象中
                    StorageFile file = (StorageFile) item;
                    Note note = new Note()
                    {
                        Filename = file.Name,
                        Text = await FileIO.ReadTextAsync(file),
                        Date = file.DateCreated.DateTime,
                    };
                    Note.Add(note);
                }
            }
        }
    }
}
