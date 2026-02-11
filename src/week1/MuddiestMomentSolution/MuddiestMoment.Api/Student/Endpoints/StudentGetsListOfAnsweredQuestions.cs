using Marten;

namespace MuddiestMoment.Api.Student.Endpoints;

public static class StudentGetsListOfAnsweredQuestions
{
    public static async Task<IResult> GetAllAnsweredMomentsForStudent(IDocumentSession session)
    {
        var moments = await session.Query<StudentMomentEntity>()
            .Where(m => m.AddedBy == "fake user" && m.IsAnswered == true)
            .Select(m => new StudentMomentResponseModel
            {
                Id = m.Id,
                AddedBy = m.AddedBy,
                CreatedOn = m.CreatedOn,
                Description = m.Description,
                Title = m.Title
            })
            .ToListAsync();

        return TypedResults.Ok(moments);
    }
}
