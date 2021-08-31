using System;
using System.Collections.Generic;

namespace AvanssurRecruitment.Data
{
    /// <summary>
    /// SwapiPlanet represents Homeworld objects stored in database.
    /// </summary>
    public class SwapiPlanet
    {
        // I would use C# 9 records if they were available in .NET 4.7.2
        public SwapiPlanet(string name, string rotation_period, string orbital_period,
            string diameter, string climate, string gravity, string terrain,
            string surface_water, string population, List<string> residents,
            List<string> films, DateTime created, DateTime edited, string url)
        {
            Name = name;
            Rotation_period = rotation_period;
            Orbital_period = orbital_period;
            Diameter = diameter;
            Climate = climate;
            Gravity = gravity;
            Terrain = terrain;
            Surface_water = surface_water;
            Population = population;
            Residents = residents;
            Films = films;
            Created = created;
            Edited = edited;
            Url = url;
        }

        public string Name { get;}
        public string Rotation_period { get;}
        public string Orbital_period { get;}
        public string Diameter { get;}
        public string Climate { get;}
        public string Gravity { get;}
        public string Terrain { get;}
        public string Surface_water { get;}
        public string Population { get;}
        public List<string> Residents { get;}
        public List<string> Films { get;}
        public DateTime Created { get;}
        public DateTime Edited { get;}
        public string Url { get;}
    }
}
