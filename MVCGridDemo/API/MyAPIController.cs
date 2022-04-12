using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using MVCGridDemo.Repository;


namespace MVCGridDemo.API
{
    public class MyAPIController : ApiController
    {
        ISchemeRepository schemeRepository;
        public MyAPIController(ISchemeRepository Repository)
        {
            schemeRepository = Repository;
        }

        public IHttpActionResult GetScheme(int SchemeId)
        {
            return Ok(schemeRepository.GetScheme(SchemeId));
        }
    }
}