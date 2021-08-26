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

        public static int ToMinutes(this string time)
        {
            return int.Parse(time.Replace("min", "").Trim());
        }
    }
}
