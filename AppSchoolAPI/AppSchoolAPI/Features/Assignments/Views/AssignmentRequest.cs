namespace AppSchoolAPI.Features.Assignments.Views;

public class AssignmentRequest //ce se baga de la frontend
{
    public string Subject { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
}