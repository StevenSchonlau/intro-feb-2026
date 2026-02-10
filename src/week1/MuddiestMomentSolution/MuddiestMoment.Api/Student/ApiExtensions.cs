using MuddiestMoment.Api.Student.Endpoints;

namespace MuddiestMoment.Api.Student;

public static class ApiExtensions //api must be static
{
    //new in 10.0
    extension(IEndpointRouteBuilder endpoints)
    {
        // POST /students/moments
        // GET /student/moments
        public IEndpointRouteBuilder MapStudentEndpoints()
        {
            var group = endpoints.MapGroup("/student/moments"); //can apply authorization just here
            group.MapPost("", StudentAddsMoment.AddMoment);
            return group;
        }
    }

}



