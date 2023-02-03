namespace JobList.Entities.Helpers
{
    public static class MexicoDateHelper
    {
        public static DateTime obtainDate()
        {
            TimeZoneInfo mexicoZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time (Mexico)");
            DateTime mexicoTime = TimeZoneInfo.ConvertTime(DateTime.Now, mexicoZone);
            return mexicoTime;
        }
    }
}
