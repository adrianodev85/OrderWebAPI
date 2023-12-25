using Flunt.Notifications;
using System.Runtime.CompilerServices;

namespace OrderWebAPI.Endpoints;

public static class ProblemDetailExtension
{
    public static Dictionary<string, string[]> ConvertToProblemaDetails(this IReadOnlyCollection<Notification> notification)
    {
        return notification
            .GroupBy(e => e.Key)
            .ToDictionary(e => e.Key, e => e.Select(x => x.Message)
            .ToArray());
    }
}
