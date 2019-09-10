using RestfulWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestfulWebApi.Controllers
{
    [RoutePrefix("api/Contact")]   //this acts as prefix for all
    public class ContactController : ApiController
    {
        Contact[] contacts = new Contact[] {
                new Contact(){Id = 0, FirstName = "Mustafa", LastName = "dev"},
                new Contact(){Id = 1, FirstName = "Levent", LastName = "alsodev"},
                new Contact(){Id = 2, FirstName = "Oguzhan", LastName = "devtoo"},
        };

        // GET: api/Contact
        //[Route("api/Contact")]
        [Route("")]
        public IEnumerable<Contact> Get()
        {
            return contacts;
        }

        // GET: api/Contact/5
        //[Route("api/Contact/{id:int}")]  //since there is routeprefix, this one shortens
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            Contact singleContact = contacts.FirstOrDefault<Contact>(x => x.Id == id);

            if (singleContact == null)
            {
                return NotFound();
            }

            //Ok indicates http200
            return Ok(singleContact);
        }

        //[Route("api/Contact/{name}")]      //httppost and actionname tag wont be used if Custom routingtemplate will be used
                                             //however, if the function name wont be using Get prefix use [HttpGet] 
        [Route("{name}")]
        //[HttpPost]  // shows you this custom method is Post type
        //[ActionName("ContactName")]  //shows you how to route template
        public IEnumerable<Contact> GetContactByName(string name)
        {

            Contact[] contactArray = contacts.Where(x => x.FirstName.Contains(name)).ToArray<Contact>();

            return contactArray;
        }


        // POST: api/Contact
        [Route("")]
        public IEnumerable<Contact> Post([FromBody]Contact newContact)
        {
            List<Contact> contactList = contacts.ToList<Contact>();
            contactList.Add(newContact);

            contacts = contactList.ToArray();

            return contacts;
        }

        // PUT: api/Contact/5
        [Route("{id:int}")]
        public IEnumerable<Contact> Put(int id, [FromBody]Contact alteredContact)
        {
            //put altered contact into given index
            //contacts[id] = alteredContact;

            //put altered contact into given id
            Contact singleContact = contacts.FirstOrDefault<Contact>(x => x.Id == id);
            singleContact.FirstName = alteredContact.FirstName;
            singleContact.LastName = alteredContact.LastName;

            return contacts;
        }

        // DELETE: api/Contact/5
        [Route("{id:int}")]
        public IEnumerable<Contact> Delete(int id)
        {
            //remove the contact in given index using list
            //List<Contact> tempList = contacts.ToList<Contact>();
            //tempList.RemoveAt(id);
            //return tempList.ToArray(); ;

            //using linq
            contacts = contacts.Where<Contact>(x => x.Id != id).ToArray<Contact>();
            return contacts;
            
        }
       

    }
}
