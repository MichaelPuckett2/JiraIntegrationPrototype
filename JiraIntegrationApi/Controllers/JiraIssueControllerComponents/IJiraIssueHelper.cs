namespace JiraIntegrationApi.Controllers.JiraIssueControllerComponents
{
    public interface IJiraIssueHelper
    {
        string GetAuthorizationHeader(JiraIssue issue);
        string GetAddIssueUrl(JiraIssue issue);
        string GetIssueTypeIdsUrl(JiraIssue issue);
    }
}