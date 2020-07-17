using Rehber.API.Attributes;
using Rehber.API.Security;
using Rehber.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Rehber.API.Controllers
{

    public class TelefonlarController : ApiController
    {
        TelefonlarDAL PhonesDAL = new TelefonlarDAL();

        //Nuamara Sorgulama /api/telefonlar?tel=xxxxxxxxxx
        [ResponseType(typeof(Telefonlar))]
        public IHttpActionResult GetSearchByNumber(String tel)
        {
            if (PhonesDAL.IsThereAnyPhoneNumber(tel) == null)
            {
                return Content(HttpStatusCode.NotFound, "Böyle bir numara bulunamadı..!");
            }
            else
            {
                return Ok(PhonesDAL.IsThereAnyPhoneNumber(tel));
            }
        }

        [ResponseType(typeof(IEnumerable<Telefonlar>))]
        [APIAuthorizeAttribute(Roles="Admin,Manager")]
        public IHttpActionResult Get()
        {
            var phones = PhonesDAL.GetAllPhones();
            return Ok(phones);
        }

        [ResponseType(typeof(Telefonlar))]
        [APIAuthorizeAttribute(Roles = "Admin,Manager")]
        public IHttpActionResult Get(int id)
        {
            var phone = PhonesDAL.GetPhoneById(id);
            if (phone == null)
            {
                return Content(HttpStatusCode.NotFound, "Böyle bir numara bulunamadı..!");
            }
            return Ok(phone);
        }

        [ResponseType(typeof(Telefonlar))]
        [APIAuthorizeAttribute(Roles = "Admin,Manager")]
        public IHttpActionResult Post(Telefonlar telefon)
        {
            if (PhonesDAL.IsThereAnyPhoneNumber(telefon.TelefonNo) != null)
            {
                return Content(HttpStatusCode.BadRequest, "Bu numara zaten kayıtlı..!");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var createdphone = PhonesDAL.CreatePhone(telefon);
                    return CreatedAtRoute("DefaultApi", new { id = createdphone.ID }, createdphone);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
        }

        [ResponseType(typeof(Telefonlar))]
        [APIAuthorizeAttribute(Roles = "Admin,Manager")]
        public IHttpActionResult Put(int id, Telefonlar telefon)
        {
            // Kayıt yok ise
            if (PhonesDAL.IsThereAnyPhoneID(id) == false)
            {
                return Content(HttpStatusCode.NotFound, "Böyle bir kayıt bulunamadı..!");
            }
            // Telefon modeli uygun degil ise
            else if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(PhonesDAL.UpdatePhone(id, telefon));
            }
        }

        [APIAuthorizeAttribute(Roles = "Admin")]
        public IHttpActionResult Delete(int id)
        {
            if (PhonesDAL.IsThereAnyPhoneID(id) == false)
            {
                return Content(HttpStatusCode.NotFound, "Böyle bir kayıt bulunamadı..!");
                //return NotFound();
            }
            else
            {
                PhonesDAL.DeletePhone(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
    }
}
