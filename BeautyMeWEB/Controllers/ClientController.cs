﻿using BeautyMe;
using BeautyMeWEB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BeautyMeWEB.Controllers
{

    public class ClientController : ApiController
    {
        // GET: api/Client

        [HttpGet]
        [Route("api/client")]
        public HttpResponseMessage Get()
        {
            BeautyMeDBContext db = new BeautyMeDBContext();
            List<ClientDTO> c = db.Client.Select(x => new ClientDTO
            {
                Email = x.Email,
                ID_number = x.ID_number,
                First_name = x.First_name,
                Last_name = x.Last_name,
                phone = x.phone,
                password = x.password
            }).ToList();
            if (c != null)
                return Request.CreateResponse(HttpStatusCode.OK, c);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // GET: api/Client/5
        [HttpGet]
        [Route("api/client/{id}")]
        public HttpResponseMessage Get(string id, string pass)
        {
            BeautyMeDBContext db = new BeautyMeDBContext();
            ClientDTO c1 = db.Client.Where(x => x.ID_number == id && x.password == pass).Select(a => new ClientDTO
            {
                password = a.password,
                ID_number = a.ID_number,
                Last_name = a.Last_name,
                First_name = a.First_name
            }).FirstOrDefault();
            if (c1 != null)
                return Request.CreateResponse(HttpStatusCode.OK, c1);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // POST: api/Client
        [HttpPost]
        [Route("api/client/{lala}")]
        public HttpResponseMessage Post([FromBody] string pass, string lala)
        {
            ClientDTO clientDTO = new ClientDTO();
            BeautyMeDBContext db = new BeautyMeDBContext();
            List<ClientDTO> clients = db.Client.Select(x => new ClientDTO
            {
                Email = x.Email,
                ID_number = x.ID_number,
                First_name = x.First_name,
                Last_name = x.Last_name,
                password = x.password

            }).ToList();
            foreach (ClientDTO c in clients)
            {
                if (c.ID_number == lala)
                {
                    if (c.password == pass)
                        clientDTO = c;
                }
            }
            if (clientDTO != null)
                return Request.CreateResponse(HttpStatusCode.OK, clientDTO);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "not found");
        }

        // PUT: api/Client/5
        [HttpPut]
        [Route("api/client/{id}")]
        public HttpResponseMessage Put(int id, [FromBody] Client value)
        {
            BeautyMeDBContext db = new BeautyMeDBContext();
            Client c = new Client();
            c = value;
            if (c != null)
            {
                db.Client.Add(c);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "new client added to the dataBase");
            }
            else
                return Request.CreateResponse(HttpStatusCode.NoContent);
        }
        // DELETE: api/Client/5
        public void Delete(int id)
        {
        }
    }
}
