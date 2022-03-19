namespace JiraIntegrationApi.Controllers.JiraIssueControllerComponents;

public class IssueType
{
    public string name { get; set; } = string.Empty;
    public static IssueType Empty { get; } = new();
}
