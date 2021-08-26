namespace AvanssurRecruitment.Data
{
    public class TripResult
    {
        public TripResult(int time, int distance)
        {
            Time = time;
            Distance = distance;
        }

        public int Time { get; }
        public int Distance { get;}
    }
}
