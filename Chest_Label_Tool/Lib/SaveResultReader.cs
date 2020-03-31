using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Chest_Label_Tool.Lib
{
    public static class SaveResultReader
    {
        public static SaveResultV2 ReadFromFile(string FilePath) 
        {
            if (Func.CheckFileExist(FilePath))
            {
                string JsonStr = Func.ReadText(FilePath);
                return ReadFromString(JsonStr);
            }
            else 
            {
                throw new IOException("File Not Find");
            }
        }

        public static SaveResultV2 ReadFromString(string JsonStr) 
        {
            SaveResultV2 item = JsonConvert.DeserializeObject<SaveResultV2>(JsonStr);
            if (item.KeyPoints == null || item.KeyPoints.Count == 0 ) 
            {
                SaveResultV1 item_old = SaveResultV1.ConvertSaveFile(JsonStr);
                item = SaveResultV2.Convert(item_old);
            }
            return item;
        }

    }
}
