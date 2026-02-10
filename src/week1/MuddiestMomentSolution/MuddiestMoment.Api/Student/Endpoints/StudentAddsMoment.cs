using Microsoft.AspNetCore.Http.HttpResults;

namespace MuddiestMoment.Api.Student.Endpoints;

public static class StudentAddsMoment
{
    public static async Task<Ok<StudentMomentResponseModel>> AddMoment(StudentMomentCreateModel request)
    {

        //get data sent
        //uathenticated
        //validate
        //database
        //receipt
        //this will return empty 200 OK
        var response = new StudentMomentResponseModel
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            CreatedOn = DateTimeOffset.UtcNow,
            AddedBy = "we need to read that authorization header"
        };
        return TypedResults.Ok(response);
    }
}
