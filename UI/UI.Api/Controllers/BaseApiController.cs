using BLL.Service.AccountSer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using UI.Api.Fitler;

namespace UI.Api.Controllers
{
    //[RequestAuthorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BaseApiController : ApiController
    {

    }
}
