using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALS.CQRS.Commands;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCqrs.Commanding;

namespace ALS.CQRS.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/GameReview")]
    public class GameReviewController 
        : Controller
    {
        [NotNull]
        private readonly ICommandBus m_Bus;

        public GameReviewController(
            [NotNull] ICommandBus bus)
        {
            m_Bus = bus;
        }

        // GET: api/GameReview
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GameReview/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/GameReview
        [HttpPost]
        public void Post([FromBody] CreateGameReviewCommand command)
        {
            m_Bus.Execute(command);
        }

        // PUT: api/GameReview/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CreateGameReviewCommand command)
        {
            m_Bus.Execute(command);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
