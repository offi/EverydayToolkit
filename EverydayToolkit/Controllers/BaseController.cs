using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using EverydayToolkit.Core;
using EverydayToolkit.ViewModels;

namespace EverydayToolkit.Controllers
{
    public class BaseController: Controller
    {
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonNetResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }

        protected JsonResult Success()
        {
            return Json(new SuccessResult());
        }

        protected JsonResult Success(object data)
        {
            return Json(new SuccessResult(data));
        }

        protected JsonResult Error()
        {
            return Json(new ErrorResult());
        }

        protected JsonResult Error(string message)
        {
            return Json(new ErrorResult(new [] { message }));
        }

        protected JsonResult Error(IEnumerable<string> messages)
        {
            return Json(new ErrorResult(messages));
        }
    }
}
