using Microsoft.AspNetCore.Mvc;
using FisherInsuranceApi.Data;
using FisherInsuranceApi.Models;

[Route("api/claim")]
public class ClaimsController : Controller
{
    private IMemoryStore db;
    public ClaimsController(IMemoryStore repo)
    {
        db = repo;
    }

    [HttpGet]
    public IActionResult GetClaim()
    {
        return Ok(db.RetrieveAllClaims);
    }

    //POST api/claim/quotes
    [HttpPost]
    public IActionResult Post(int id, [FromBody] Claim claim)
    {
        return Ok(db.CreateClaim(claim));
    }

    //GET api/claim/5

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(db.RetrieveClaim(id));
    }

    //PUT api/claim/id

    [HttpPut]
    public IActionResult Put([FromBody] Claim claim)
    {
        return Ok(db.UpdateClaim(claim));
    }

    //DELETE api/claim/id

    [HttpDelete("{id}")]
    public IActionResult Delete(int id, [FromBody] Claim claim)
    {
        db.DeleteClaim(id);
        return Ok();
    }

}