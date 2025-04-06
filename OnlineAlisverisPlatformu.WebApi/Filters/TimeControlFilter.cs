using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.CodeAnalysis;

namespace OnlineAlisverisPlatformu.WebApi.Filters
{
    public class TimeControlFilter : ActionFilterAttribute
    {
        public string StarTime { get; set; }
        public string EndTime { get; set; }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var now = DateTime.Now.TimeOfDay;

            StarTime = "08:00";
            EndTime = "17:00";

            if (now >= TimeSpan.Parse(StarTime) && now <= TimeSpan.Parse(EndTime) ){
                base.OnActionExecuted(context);
            }
            else
            {
                context.Result = new ContentResult
                {
                    Content = "You can't do this operation outside of working hours.",
                    StatusCode = 403
                };
            }
        }

    }
}
