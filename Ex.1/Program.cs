using System;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Xml.Serialization;

namespace Ex._1
{
    public class Program
    {
        [Serializable]
        [DataContract]
        public class Squard
        {
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public int Members { get; set; }

            public Squard() { }

            public Squard(string name, int members) 
            { 
                Name = name;
                Members = members;
            
            }
            
            //public  string Print() 
            //{
            //    return $"Name: {Name} Count: {Members} ";
            //}

        
        }

        static string MoreThenOneVerification(List<string> files)
        {
            var jsonFiles = new List<string>();

            foreach (var file in files)
            {
                if (file.EndsWith(".json"))
                {
                    jsonFiles.Add(file);
                }
            }

            if (jsonFiles.Count != 1)
            {
                throw new Exception("Error!");
            }

            else return jsonFiles[1];
        }

        static void Main(string[] args)
        {

            Squard squard = new Squard("RedSocks", 37);

            //string json = JsonSerializer.Serialize(squard, typeof(Squard)); 
            //StreamWriter file = File.CreateText("squard1.json");
            //Console.WriteLine(json);

            //using (FileStream fs = new FileStream("squard.json", FileMode.OpenOrCreate))
            //{
            //    Squard squard2 = new Squard("RedSocks", 37);
            //    JsonSerializer.Serialize<Squard>(fs, squard2);
            //    Console.WriteLine("Data has been saved");
            //}

            using (FileStream fs = new FileStream("squard.json", FileMode.OpenOrCreate))
            {
                Squard? squard3 =  JsonSerializer.Deserialize<Squard>(fs);
                Console.WriteLine($"Name: {squard3?.Name}  Age: {squard3?.Members}");
            }

            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Squard));

            
            using (FileStream fs = new FileStream("squard.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, squard);

                Console.WriteLine("Object has been serialized");
            }
            //Console.WriteLine(person.Print());




        }



        //// передаем в конструктор тип класса Person
        //XmlSerializer xmlSerializer = new XmlSerializer(typeof(Squard));

        //// получаем поток, куда будем записывать сериализованный объект
        //using (FileStream fs = new FileStream("person.xml", FileMode.OpenOrCreate))
        //{
        //    xmlSerializer.Serialize(fs, person);

        //    Console.WriteLine("Object has been serialized");
        //}


    }
        
    
}