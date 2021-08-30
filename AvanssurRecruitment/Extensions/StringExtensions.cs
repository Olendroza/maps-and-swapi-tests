using System.Linq;

namespace AvanssurRecruitment.Extensions
{
    public static class StringExtensions
    {
        public static int ToMeters(this string distance)
        {
            if (distance.Contains("km"))
            {
                var distanceSplited = distance.Replace("km", "").Trim().Split(',');
                return int.Parse(distanceSplited.First().Trim()) * 1000 + int.Parse(distanceSplited.Last().Trim()) * 100;
            }

            return int.Parse(distance.Replace("m", "").Trim());
       }

        public static int ToMinutes(this string time) => int.Parse(time.Replace("min", "").Trim());

        public static int GetId(this string url) => int.Parse(url.Remove(url.Length - 1).Split('/').Last());

    }
}
