using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-My-Header")]
    public class RegionController : ApiController
    {
        // GET: Region

        Region[] region = new Region[] { new Region { ID = 1, Name = "Europe" },
                                         new Region { ID = 2, Name = "Middle east" },
                                         new Region { ID = 3, Name = "Asia & Pacific" },
                                         new Region { ID = 4, Name = "Africa" }
                                        };

        Country[] country = new Country[] { new Country { ID = 1, RegionID = 2, Name = "United Arab Emirates" },
                                         new Country { ID = 2, RegionID = 3, Name = "Afghanistan" },
                                         new Country { ID = 3, RegionID = 1, Name = "Albania" },
                                         new Country { ID = 4, RegionID = 4, Name = "Angola" },
                                         new Country { ID = 5, RegionID = 1, Name = "Austria" },
                                         new Country { ID = 6, RegionID = 3, Name = "India" },
                                         new Country { ID = 7, RegionID = 2, Name = "Egypt" },
                                         new Country { ID = 8, RegionID = 4, Name = "Gabon" }
                                        };


        private IEnumerable<Country> GetCountriesForRegion(int RegionID)
        {
            var _region = region.FirstOrDefault(reg => reg.ID == RegionID);
            var _countries = Array.FindAll(country, cnt => cnt.RegionID == _region.ID);
            return _countries;
        }



        //-----------------------------------------------------------------------------------------
        // Basic Authentication
        //-----------------------------------------------------------------------------------------
        //Fiddler: Set username and password for basic authentication
        // 1. open fiddler, click Tools->TextWizard...menu item,
        // 2. select checkbox of "To Base64"
        // 3. input your user name and password in top textbox such as
        // myUsername:myPassword   Anurag:123456
        // 4. Go back to fiddler composer screen and add a header of below, the last past is the output of
        // Authorization: Basic QW51cmFnOjEyMzQ1Ng==
        //-----------------------------------------------------------------------------------------

        //http://localhost:50385/api/region/GetCountries/1

        [System.Web.Http.Route("api/region/GetCountries/{regionid}")]
        [BasicAuthentication]
        //[System.Web.Http.HttpGet("GetCountries")]
        public IHttpActionResult GetCountries(int RegionID)
        {
            string userName = Thread.CurrentPrincipal.Identity.Name;
            //using (testEntities entities = new testEntities())
            //{
                if (userName != "")
                {
                    return Ok(GetCountriesForRegion(RegionID));
                }
                else
                {
                    return Ok(HttpStatusCode.Unauthorized);
                }
            //}

                ////var _region = region.FirstOrDefault(reg => reg.ID == ID);
                ////var _countries = Array.FindAll(country, cnt => cnt.RegionID == _region.ID);
                ////return Ok(_countrys);
                //return Ok(GetCountriesForRegion(RegionID));
        }

        //http://localhost:50385/api/region/1/countries/5
        [System.Web.Http.Route("MyWebAPI/api/region/{regionid}/countries/{countryid}")]
        [BasicAuthentication]
        public IHttpActionResult GetSpecificCountry(int regionid, int countryid)
        {
            IEnumerable<Country> _countries =  GetCountriesForRegion(regionid);
            return Ok(_countries.FirstOrDefault(cntry => cntry.ID == countryid));
        }
    }
}