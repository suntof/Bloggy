using Bloggy.CORE.Entities;
using Bloggy.REPO.UnitOfWorks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bloggy.MVC.Filters.ArticleVisitors
{
    public class ArticleVisitorFilter : IAsyncActionFilter
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleVisitorFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public bool Disable { get;set; }

        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //if(Disable) return next();

            List<Visitor> visitors = _unitOfWork.GetRepository<Visitor>().GetAllAsync().Result;


            string getIp = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            string getUserAgent = context.HttpContext.Request.Headers["User-Agent"];

            Visitor visitor = new(getIp, getUserAgent);



            if (visitors.Any(x => x.IpAddress == visitor.IpAddress))
                return next();
            else
            {
                _unitOfWork.GetRepository<Visitor>().AddAsync(visitor);
                _unitOfWork.Save();
            }
            return next();

        }
    }
}
