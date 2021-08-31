using AvanssurRecruitment.Data;

namespace AvanssurRecruitment.Infrastructure
{
    /// <summary>
    /// Factory that provides with correct links used for Swapi calls.
    /// </summary>
    public class UrlsFactory
    {
        public UrlsFactory()
        {
            Url = Urls.SwapiBaseUrl;
        }

        private string Url;

        public UrlsFactory WithPeople()
        {
            Url += Urls.SwapiPeopleUrl;

            return this;
        }

        public UrlsFactory WithSearch(string searchInput)
        {
            Url += $"{Urls.SwapiSearch}{searchInput}";

            return this;
        }

        public string GetUrl() => Url;
    }
}
