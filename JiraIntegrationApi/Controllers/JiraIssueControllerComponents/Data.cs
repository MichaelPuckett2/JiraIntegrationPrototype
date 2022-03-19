namespace JiraIntegrationApi.Controllers.JiraIssueControllerComponents;

public class Data
{
    public Fields fields { get; set; } = Fields.Empty;
    public static Data Empty { get; } = new();
}
