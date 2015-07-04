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

        protected JsonResult JsonSuccess()
        {
            return Json(new SuccessResult(), JsonRequestBehavior.AllowGet);
        }

        protected JsonResult JsonSuccess(object data)
        {
            return Json(new SuccessResult(data), JsonRequestBehavior.AllowGet);
        }

        protected JsonResult JsonError()
        {
            return Json(new ErrorResult(), JsonRequestBehavior.AllowGet);
        }

        protected JsonResult JsonError(string message)
        {
            return Json(new ErrorResult(new [] { message }), JsonRequestBehavior.AllowGet);
        }

        protected JsonResult JsonError(IEnumerable<string> messages)
        {
            return Json(new ErrorResult(messages), JsonRequestBehavior.AllowGet);
        }
    }
}
