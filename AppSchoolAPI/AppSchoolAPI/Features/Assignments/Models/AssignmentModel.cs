using System.Runtime.InteropServices.JavaScript;
using AppSchoolAPI.Base.MODELS;

namespace AppSchoolAPI.Features.Assignments.Models;

public class AssignmentModel : Model
{
    public string Subject { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
}