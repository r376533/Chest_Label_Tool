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
        public static SaveResultV2 ReadFromFile(string FilePath,DcmInfo info) 
        {
            if (Func.CheckFileExist(FilePath))
            {
                string JsonStr = Func.ReadText(FilePath);
                return ReadFromString(JsonStr, info);
            }
            else 
            {
                throw new IOException("File Not Find");
            }
        }

        public static SaveResultV2 ReadFromString(string JsonStr, DcmInfo info) 
        {
            SaveResultV2 item;
            if (SaveResultV2.IsVersion2(JsonStr))
            {
                item = JsonConvert.DeserializeObject<SaveResultV2>(JsonStr);
            }
            else 
            {
                SaveResultV1 item_old = SaveResultV1.ConvertSaveFile(JsonStr);
                item = SaveResultV2.Convert(item_old,info);
            }
            return item;
        }

    }
}
