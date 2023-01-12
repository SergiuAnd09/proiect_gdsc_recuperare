using AppSchoolAPI.Features.Assignments.Models;
using AppSchoolAPI.Features.Assignments.Views;
using Microsoft.AspNetCore.Mvc;

namespace AppSchoolAPI.Features.Assignments;

[ApiController]
[Route("api/assignments")] //ca sa nu se dea la fiecare endpoint in parte

public class AssignmentsController : ControllerBase
{
    private static List<AssignmentModel> _mockDb = new List<AssignmentModel>();

    [HttpPost] //marcheaza zona de incepere a endpointului, descris de tag. tagul e marcat de [].httppost returneaza 201
    public AssignmentResponse Add(AssignmentRequest request)
    {
        var assignment = new AssignmentModel
        {
            Id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Subject = request.Subject,
            Description = request.Description,
            Deadline = request.Deadline
        };
        _mockDb.Add(assignment);
        return new AssignmentResponse
        {
            Id = assignment.Id,
            Subject = assignment.Subject,
            Description = assignment.Description,
            Deadline = assignment.Deadline
        };
    }

    [HttpGet]
    public IEnumerable<AssignmentResponse> Get()
    {
        return _mockDb.Select(

            assignment => new AssignmentResponse
            {
                Id = assignment.Id,
                Subject = assignment.Subject,
                Description = assignment.Description,
                Deadline = assignment.Deadline
            }
        );
    }

    [HttpGet("{id}")] //se face cautare dupa variabila id
    public AssignmentResponse Get([FromRoute] string id) //overloading si fromroute ne zice de unde ia variabila
    {
        var assignment = _mockDb.FirstOrDefault(entity => entity.Id == id);

        if (assignment is null)
        {
            return null;
        }
        
        return new AssignmentResponse
        {
            Id = assignment.Id,
            Subject = assignment.Subject,
            Description = assignment.Description,
            Deadline = assignment.Deadline
        };
    }

    //endpoint de delete care primeste din route id-ul unui obiect, il cauta si il sterge
    //endpoint de update, foloseste httppatch, primeste din route un id si din body un req nou si actualizaeaza datele modelului cu datele modelului nou cu datele de update, ale
    //requestului nou, apoi pe telegram la pin.
    
}