using System.Text;

namespace JiraIntegrationApi.Controllers.JiraIssueControllerComponents;

public class JiraIssueHelper : IJiraIssueHelper
{
    public const string EmptyEmail = "Email is empty";
    public const string EmptyApiToken = "Api Token is empty";
    public const string EmptyJiraCloundInstance = "Jira Clound Instance is empty";

    public string GetAuthorizationHeader(JiraIssue jiraIssue)
    {
        if (string.IsNullOrWhiteSpace(jiraIssue.email)) return EmptyEmail;
        if (string.IsNullOrWhiteSpace(jiraIssue.apiToken)) return EmptyApiToken;

        var preString = $"{jiraIssue.email}:{jiraIssue.apiToken}";
        var bytes = Encoding.UTF8.GetBytes(preString);
        var base64 = Convert.ToBase64String(bytes);
        return base64;
    }

    public string GetAddIssueUrl(JiraIssue jiraIssue)
    {
        if (string.IsNullOrWhiteSpace(jiraIssue.jiraCloudInstance)) return EmptyJiraCloundInstance;
        return $"https://{jiraIssue.jiraCloudInstance}/rest/api/3/issue";
    }

    public string GetIssueTypeIdsUrl(JiraIssue jiraIssue)
    {
        if (string.IsNullOrWhiteSpace(jiraIssue.jiraCloudInstance)) return EmptyJiraCloundInstance;
        return $"https://{jiraIssue.jiraCloudInstance}/rest/api/3/issuetype";
    }
}
