using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace UrlFileDown.Tool
{
    public static class SerializeHelp<T> where T : class, new()
    {
        public static List<T> GetClassModelList(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            List<T> list = new List<T>();
            var files = Directory.GetFiles(path);
            if (files != null && files.Length > 0)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                foreach (var f in files)
                {
                    using (Stream stream = File.Open(f, FileMode.Open))
                    {
                        var obj = formatter.Deserialize(stream) as T;
                        if (obj != null)
                            list.Add(obj);
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// 序列化实体
        /// </summary>
        /// <param name="model">待序列化实体</param>
        /// <param name="savepathname">保存的文件路径文件名</param>
        /// <returns></returns>
        public static List<T> SerializeModel(T model, string savepath, string filename)
        {
            if (!Directory.Exists(savepath))
                Directory.CreateDirectory(savepath);
            var list = GetClassModelList(savepath);
            BinaryFormatter formatter = new BinaryFormatter();

            using (Stream filestream = File.Create(savepath + filename))
            {
                formatter.Serialize(filestream, model);
                filestream.Flush();
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 删除序列到本地的文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filename"></param>
        public static List<T> DeleteFile(string path, string filename)
        {
            if (File.Exists(path + filename))
                File.Delete(path + filename);
            var list = GetClassModelList(path);
            return list;
        }
    }
}
