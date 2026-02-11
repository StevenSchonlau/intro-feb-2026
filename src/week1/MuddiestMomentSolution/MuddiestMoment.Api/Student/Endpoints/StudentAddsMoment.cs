using Marten;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MuddiestMoment.Api.Student.Endpoints;

public static class StudentAddsMoment
{
    public static async Task<Ok<StudentMomentResponseModel>> AddMoment(
        StudentMomentCreateModel request, IDocumentSession session)
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
            AddedBy = "fake user"
        };

        //saving to db
        var entity = new StudentMomentEntity
        {
            //mapping
            Id = response.Id,
            Title = response.Title,
            Description = response.Description,
            AddedBy = response.AddedBy,
            CreatedOn = response.CreatedOn
        };

        //varies depending on library/db
        session.Store(entity);
        await session.SaveChangesAsync(); //this is atomic with all things in session

        return TypedResults.Ok(response);
    }
}
