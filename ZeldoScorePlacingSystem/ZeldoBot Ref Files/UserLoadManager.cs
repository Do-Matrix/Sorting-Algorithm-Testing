using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;

namespace ZeldoScorePlacingSystem.ZeldoBot_Ref_Files
{
    public class UserLoadManager
    {
        public List<Users> Users = new List<Users>();
        public const string FilePath = @"D:/Users.json";


        public void save()
        {
            TextWriter writer = null;
            try
            {
                var serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.NullValueHandling = NullValueHandling.Include;
                writer = new StreamWriter(FilePath, false);
                serializer.Serialize(writer, this);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static UserLoadManager Load()
        {
            var serializer = new JsonSerializer();
            TextReader reader = null;
            try
            {
                if (File.Exists(FilePath))
                {
                    reader = new StreamReader(FilePath, false);
                    return serializer.Deserialize(reader, typeof(UserLoadManager)) as UserLoadManager;
                }
                return new UserLoadManager();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    
                }
            }
        }
    }
}
