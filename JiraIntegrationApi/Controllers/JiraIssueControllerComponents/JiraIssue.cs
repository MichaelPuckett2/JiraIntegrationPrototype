namespace JiraIntegrationApi.Controllers.JiraIssueControllerComponents;

public class JiraIssue
{
    public string email { get; set; } = string.Empty;
    public string apiToken { get; set; } = string.Empty;
    public string jiraCloudInstance { get; set; } = string.Empty;
    public Data data { get; set; } = Data.Empty;
}
