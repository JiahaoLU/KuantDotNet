namespace Kuant.Utils
{
    public enum Frequency
    {
        Annual=1,
        Semiannual=2,
        Quarterly=4,
        Monthly=12,
        Weekly=52,
        Daily=365,
        Continuous=-1
    }

    public enum DayCount
    {
        A360 = 0,
        ///<summary>FIXED</summary>
        A365F = 1,
        ///<summary>30/360 ISDA</summary>
        Thirty360 = 2

        // to be completed
    }
}