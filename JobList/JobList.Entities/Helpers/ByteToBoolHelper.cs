namespace JobList.Entities.Helpers
{
    public static class ByteToBoolHelper
    {
        public static bool Convert(sbyte val)
        {
            return val.ToString()=="1" ? true : false;
        }
    }
}
