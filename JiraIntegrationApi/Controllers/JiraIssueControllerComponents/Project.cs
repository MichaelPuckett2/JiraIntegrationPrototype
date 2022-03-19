namespace JiraIntegrationApi.Controllers.JiraIssueControllerComponents;

public class Project
{
    public string key { get; set; } = string.Empty;
    public static Project Empty { get; } = new();
}
