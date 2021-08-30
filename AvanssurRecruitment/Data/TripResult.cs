namespace AvanssurRecruitment.Data
{
    /// <summary>
    /// A TripResult contains required data about a given trip.
    /// </summary>
    public class TripResult
    {
        // I would use C# 9 records if they were available in .NET 4.7.2
        public TripResult(int time, int distance)
        {
            Time = time;
            Distance = distance;
        }

        public int Time { get; }
        public int Distance { get; }
    }
}
