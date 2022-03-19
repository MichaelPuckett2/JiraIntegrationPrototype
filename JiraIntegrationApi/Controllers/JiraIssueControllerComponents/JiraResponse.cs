namespace JiraIntegrationApi.Controllers.JiraIssueControllerComponents;

public class JiraResponse
{
    public string id { get; set; } = string.Empty;
    public string key { get; set; } = string.Empty;
    public string self { get; set; } = string.Empty;
    public static JiraResponse Empty { get; } = new();
}