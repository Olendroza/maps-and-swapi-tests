using AvanssurRecruitment.Data;
using System.Linq;

namespace AvanssurRecruitment.Infrastructure
{
    public static class SwapiPeopleResponseExtensions
    {
        public static SwapiPerson GetPerson(this SwapiPeopleResponse response, string name) =>
            response.Results.Single(person => person.Name == name);
    }
}
