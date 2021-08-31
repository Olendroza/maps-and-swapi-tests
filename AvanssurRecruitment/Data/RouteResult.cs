namespace AvanssurRecruitment.Data
{
    /// <summary>
    /// A TripResult contains required data about a given route.
    /// </summary>
    public class RouteResult
    {
        // I would use C# 9 records if they were available in .NET 4.7.2
        public RouteResult(int time, int distance)
        {
            Time = time;
            Distance = distance;
        }

        public int Time { get; }
        public int Distance { get; }
    }
}
