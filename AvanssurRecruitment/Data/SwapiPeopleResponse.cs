using System.Collections.Generic;

namespace AvanssurRecruitment.Data
{
    /// <summary>
    /// SwapiPeopleResponse represents a response while querying for people.
    /// </summary>
    public class SwapiPeopleResponse
    {
        // I would use C# 9 records if they were available in .NET 4.7.2
        public SwapiPeopleResponse(List<SwapiPerson> results)
        {
            Results = results;
        }

        public List<SwapiPerson> Results { get;}
    }
}
