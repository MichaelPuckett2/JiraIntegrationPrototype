namespace JiraIntegrationApi.Controllers.JiraIssueControllerComponents;

public class Fields
{
    public string summary { get; set; } = string.Empty;
    public IssueType issuetype { get; set; } = new();
    public Project project { get; set; } = Project.Empty;
    public Description description { get; set; } = Description.Empty;
    public static Fields Empty { get; } = new();
}

public class Description
{
    public string type { get; set; } = string.Empty;
    public int version { get; set; }
    public Content[] content { get; set; } = Array.Empty<Content>();
    public static Description Empty { get; } = new();
}

public class Content
{
    public string type { get; set; } = string.Empty;
    public InnerContent[] content { get; set; } = Array.Empty<InnerContent>();
    public static Content Empty { get; } = new();
}

public class InnerContent
{
    public string type { get; set; } = string.Empty;
    public string text { get; set; } = string.Empty;
    public static InnerContent Empty { get; } = new();
}