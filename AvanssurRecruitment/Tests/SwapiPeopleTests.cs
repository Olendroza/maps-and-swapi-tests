using AvanssurRecruitment.Extensions;
using AvanssurRecruitment.Fixtures;
using FluentAssertions;
using StarWarsApiCSharp;
using Xunit;

namespace AvanssurRecruitment.Tests
{
    [Collection(BackendFixture.CollectionName)]
    public class SwapiPeopleTests
    {
        public readonly Repository<Person> peopleRepository;
        public readonly Repository<Planet> planetRepository;


        public SwapiPeopleTests(BackendFixture fixture)
        {
            peopleRepository = fixture.peopleRepository;
            planetRepository = fixture.planetRepository;

        }

        [Fact]
        public void Database_QueryPeopleForFirstEntry_HomeworldCorrect()
        {
            var homeworId = peopleRepository
               .GetById(1)
               .Homeworld
               .GetId();

            var planetName = planetRepository.GetById(homeworId).Name;
            planetName.Should().Be("Tatooine");
        }
    }
}
