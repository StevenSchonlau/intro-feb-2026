using Marten;

namespace MuddiestMoment.Api.Student.Endpoints;

public static class StudentMarksMomentAnswered
{
    //Who Authorization
    // Which Questions (that id)
    //Policy
    // - you should only be able to do this for question you own or created
    public static async Task<IResult> MarkQuestionAnswered(Guid id, IDocumentSession session)
    {

        //delete that question from the database
        //in actuality doesn't delete it, just flags it
        var savedMoment = await session.Query<StudentMomentEntity>()
            .Where(m => m.Id == id)
            .SingleOrDefaultAsync();
        if (savedMoment == null)
        {

            return TypedResults.Ok(); //idempotent ops, should just return succcess if not there
        }
        savedMoment.IsAnswered = true;
        session.Store(savedMoment);
        await session.SaveChangesAsync();
        return TypedResults.Ok();
    }
}
