using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApplicationLL.Controllers
{
    public class NewsController : ApiController
    {

        [HttpGet]
        [Route("api/News/{id}")]
        public HttpResponseMessage Get(int id)
        {


            try
            {
                var data = CategoryService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }




        [HttpPost]
        [Route("api/News/Create")]
        public HttpResponseMessage Create(NewsDTO cdt)
        {

            try
            {
                var data = NewsService.Createnews(cdt);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }

    }
}
