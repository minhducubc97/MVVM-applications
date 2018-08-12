using JSONCommunicator.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONCommunicator
{
    class Program
    {

        static void Main(string[] args)
        {
            CelebrityInfo TomCruise = new CelebrityInfo()
            {
                Name = "Tom Cruise",
                NotIncluded = false,
                Occupation = "Actor",
                Age = 56,
                Partner = "None"
            };

            CelebrityInfo RobertDowneyJR = new CelebrityInfo()
            {
                Name = "Robert Downey JR",
                NotIncluded = false,
                Occupation = "Actor",
                Age = 53,
                Partner = "Susan Downey"
            };

            CelebrityInfo LeeKwangSoo = new CelebrityInfo()
            {
                Name = "Lee Kwang Soo",
                NotIncluded = false,
                Occupation = "Entertainer, actor",
                Age = 33,
                Partner = "Joen So Min"
            };

            ObservableCollection<CelebrityInfo> listOfCelebrities = new ObservableCollection<CelebrityInfo>();
            listOfCelebrities.Add(TomCruise);
            listOfCelebrities.Add(RobertDowneyJR);
            listOfCelebrities.Add(LeeKwangSoo);

            Program.SerializeObject<CelebrityInfo>(listOfCelebrities, "data.txt");

            ObservableCollection<CelebrityInfo> newListOfCelebrities = new ObservableCollection<CelebrityInfo>();
            newListOfCelebrities = Program.DeSerializeObject<CelebrityInfo>("data.txt");

            foreach (var celeb in newListOfCelebrities)
            {
                Console.WriteLine("Name: " + celeb.Name);
                Console.WriteLine("Occupation: " + celeb.Name);
                Console.WriteLine("Age: " + celeb.Age);
                Console.WriteLine("Partner: " + celeb.Partner);
                Console.WriteLine(""); // seperate line
            }

            Console.ReadLine(); // keep the console running
        }

        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        public static void SerializeObject<T>(ObservableCollection<T> listOfSerializableObject, string fileName)
        {
            if (listOfSerializableObject == null) { return; }
            string output = JsonConvert.SerializeObject(listOfSerializableObject, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Newtonsoft.Json.Formatting.Indented }); ;
            File.WriteAllText(fileName, output);
        }

        /// <summary>
        /// Deserializes an json file into an object list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static ObservableCollection<T> DeSerializeObject<T>(string fileName)
        {
            ObservableCollection<T> list;
            using (StreamReader reader = new StreamReader(fileName))
            {
                string json = reader.ReadToEnd();
                list = JsonConvert.DeserializeObject<ObservableCollection<T>>(json);
            }
            return list;
        }
    }
}
