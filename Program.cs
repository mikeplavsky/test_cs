using System;
using System.IO;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

[DataContract]
internal class Person {

  [DataMember]
  internal string name;

  [DataMember]
  internal int age;

}

public class Program
{
    public static void Main(string[] args)
    {
        var p = new Person {name = "Jim", age = 20 };

        var sr = new DataContractJsonSerializer(typeof(Person));
        var mem = new MemoryStream();

        sr.WriteObject(mem, p);
        mem.Position = 0;

        var r = new StreamReader(mem);
        var res = r.ReadToEnd();

        Console.WriteLine(res);
    }
}
