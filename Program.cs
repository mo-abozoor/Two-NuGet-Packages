using System.IO;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
};

//string json = File.ReadAllText("person.json");
string json = File.ReadAllText(@"H:\UCAS\F4\مساق اختياري ASP.NET\asp projects\console\Two NuGet Packages\person.json");


JObject jObject = JsonConvert.DeserializeObject<JObject>(json);

var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<JObject, Person>()
        .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src["firstName"].ToString()))
        .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src["lastName"].ToString()))
        .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src["age"].ToObject<int>()));
});

var mapper = new Mapper(config);
Person person = mapper.Map<Person>(jObject);

Console.WriteLine($"Name: {person.FirstName} {person.LastName}, Age: {person.Age}");
