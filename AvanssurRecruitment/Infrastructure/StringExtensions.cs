using System.Linq;

namespace AvanssurRecruitment.Infrastructure
{

    public static class StringExtensions
    {
        /// <summary>
        /// Converts value read from Frontend into meters.
        /// </summary>
        public static int ToMeters(this string distance)
        {
            //Assumption - in the task there was a requirement to query maps.google.pl so distance units are in polish.
            if (distance.Contains("km"))
            {
                var distanceSplited = distance.Replace("km", "").Trim().Split(',');
                return int.Parse(distanceSplited.First().Trim()) * 1000 + int.Parse(distanceSplited.Last().Trim()) * 100;
            }

            return int.Parse(distance.Replace("m", "").Trim());
       }

        /// <summary>
        /// Converts value read from Frontend into minutes.
        /// </summary>
        //Assumption - in the task there was a requirement to query maps.google.pl so time units are in polish.
        public static int ToMinutes(this string time) => int.Parse(time.Replace("min", "").Trim());

        /// <summary>
        /// Extracts Id that is at the end of the endpoint.
        /// </summary>
        public static int GetId(this string url) => int.Parse(url.Remove(url.Length - 1).Split('/').Last());
    }
}
