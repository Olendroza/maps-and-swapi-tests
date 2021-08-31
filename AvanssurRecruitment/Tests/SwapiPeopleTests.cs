using AvanssurRecruitment.Fixtures;
using AvanssurRecruitment.Infrastructure;
using FluentAssertions;
using StarWarsApiCSharp;
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AvanssurRecruitment.Data;
using System.Linq;

namespace AvanssurRecruitment.Tests
{
    [Collection(BackendFixture.CollectionName)]
    public class SwapiPeopleTests
    {
        public readonly Repository<Person> peopleRepository;
        public readonly Repository<Planet> planetRepository;
        private readonly HttpClient httpClient;

        public SwapiPeopleTests(BackendFixture fixture)
        {
            peopleRepository = fixture.peopleRepository;
            planetRepository = fixture.planetRepository;
            httpClient = fixture.httpClient;
        }

        [Theory(DisplayName = "Person with known Id is from expected planet")]
        [InlineData(1, "Tatooine")]
        //The test that use SWapi-CSharp library and assumes that id of Luke is known.
        public void WorkingAPI_QueryForPersonById_HomeworldCorrect
            (int id, string expectedHomeworldName)
        {
            var planetId = peopleRepository.GetById(id)
               .Homeworld.GetId();

            planetRepository
                .GetById(planetId)
                .Name.Should().Be(expectedHomeworldName);
        }

        [Theory(DisplayName = "Person is from expected planet")]
        [InlineData("Luke Skywalker", "Tatooine")]
        //The test that use SWapi-CSharp library and assumes that only the name is known.
        //This is not an optimal solution since we are querying for all People in the database,
        //but the SWapi-CSharp does not provides a searcher.
        public void WorkingAPI_QueryPeopleForAllPeople_HomeworldCorrect
            (string name, string expectedHomeworldName)
        {
            var planetId = peopleRepository.GetEntities()
                .Single(entry => entry.Name == name)
                .Homeworld.GetId();

            planetRepository
                .GetById(planetId)
                .Name.Should().Be(expectedHomeworldName);
        }

        [Theory(DisplayName = "Persons is from expected planet")]
        [InlineData("Luke Skywalker", "Tatooine")]
        //Test with no external library
        public async Task WorkingApi_SearchingForPerson_HomeworldCorrect
            (string name, string expectedHomeworldName)
        {
            var url = new UrlsFactory().WithPeople()
                .WithSearch(name)
                .GetUrl();

            var person = JsonConvert
                .DeserializeObject<SwapiPeopleResponse>(await httpClient.GetStringAsync(url))
                .GetPerson(name);

            JsonConvert
                .DeserializeObject<SwapiPlanet>(await httpClient.GetStringAsync(person.Homeworld))
                .Name.Should().Be(expectedHomeworldName);
        }
    }
}
