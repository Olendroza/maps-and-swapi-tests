﻿using StarWarsApiCSharp;
using Xunit;

namespace AvanssurRecruitment.Fixtures
{
    [CollectionDefinition(CollectionName)]
    public class BackendFixture : ICollectionFixture<BackendFixture>
    {
        public const string CollectionName = "Swapi Tests Collection";
        public readonly Repository<Person> peopleRepository;
        public readonly Repository<Planet> planetRepository;

        public BackendFixture()
        {
            peopleRepository = new Repository<Person>();
            planetRepository = new Repository<Planet>();
        }
    }
}
