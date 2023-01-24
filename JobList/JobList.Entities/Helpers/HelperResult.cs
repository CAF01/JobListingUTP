namespace JobList.Entities.Helpers
{
    using Microsoft.AspNetCore.Mvc;
    public static class HelperResult
    {
        public static IActionResult Result(object value)
        {
            if (value is null)
            {
                return new StatusCodeResult(404);
            }

            if (value.GetType() == typeof(int))
            {

                return ((int)value > 0) ? new OkObjectResult(value) : new BadRequestResult();

            }
            if (value.GetType() == typeof(string))
            {
                return ((string)value != null) ? new OkObjectResult(value) : new BadRequestResult();
            }
            else
            {
                return value != null ? new OkObjectResult(value) : new BadRequestResult();
            }

        }
    }
}
