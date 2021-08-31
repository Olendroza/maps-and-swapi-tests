using System;
using System.Collections.Generic;

namespace AvanssurRecruitment.Data
{
    /// <summary>
    /// SwapiPerson represents a person objects stored in database.
    /// </summary>
    public class SwapiPerson
    {
        // I would use C# 9 records if they were available in .NET 4.7.2
        public SwapiPerson(string name, string height, string mass,
            string hair_color, string skin_color, string eye_color,
            string birth_year, string gender, string homeworld,
            List<string> films, List<object> species,
            List<string> vehicles, List<string> starships,
            DateTime created, DateTime edited, string url)
        {
            Name = name;
            Height = height;
            Mass = mass;
            Hair_color = hair_color;
            Skin_color = skin_color;
            Eye_color = eye_color;
            Birth_year = birth_year;
            Gender = gender;
            Homeworld = homeworld;
            Films = films;
            Species = species;
            Vehicles = vehicles;
            Starships = starships;
            Created = created;
            Edited = edited;
            Url = url;
        }

        public string Name { get;}
        public string Height { get;}
        public string Mass { get;}
        public string Hair_color { get;}
        public string Skin_color { get;}
        public string Eye_color { get;}
        public string Birth_year { get;}
        public string Gender { get;}
        public string Homeworld { get;}
        public List<string> Films { get;}
        public List<object> Species { get;}
        public List<string> Vehicles { get;}
        public List<string> Starships { get;}
        public DateTime Created { get;}
        public DateTime Edited { get;}
        public string Url { get;}
    }
}
