namespace AppSchoolAPI.Features.Assignments.Views;

public class AssignmentResponse  //ce vrem sa afisam
{
    public string Id { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
}