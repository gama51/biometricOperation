using BiometricLibV2;
using BiometricRest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BiometricRest.Controllers
{
    public class BiometricRestApiController : ApiController
    {
        // GET api/BiometricRestApi
        public IEnumerable<string> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/BiometricRestApi/5
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/BiometricRestApiApi
        [ResponseType(typeof(Response))]
        public HttpResponseMessage Post([FromBody] BiometricRequest request)
        {
            HttpResponseMessage http_response = null;
            try
            {

                if (string.IsNullOrWhiteSpace(request.SubjectTemplate1) || string.IsNullOrWhiteSpace(request.SubjectTemplate2))
                {
                    http_response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(new Response { Result = false, Error = "templates are invalid" }, Formatting.Indented))
                    };
                    return http_response;
                }

                var operacionBiometrica = new OperacionBiometrica();
                operacionBiometrica.init(5000, "/local", true, request.umbral);
                var resp = operacionBiometrica.Verify(request.SubjectTemplate1, request.SubjectTemplate2);
                
                var resp2 = JsonConvert.DeserializeObject<Response>(resp);
                var response = new Response { Result = resp2.Result, score = resp2.score , Error = resp2.Error};
                http_response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(response, Formatting.Indented))
                };
                operacionBiometrica.release();

            }
            catch (Exception ex)
            {
                http_response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(new Response { Result = false, Error = ex.ToString() }, Formatting.Indented))
                };

            }
            return http_response;
        }

        // PUT api/BiometricRestApi/5
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/BiometricRestApi/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}