using JiraIntegrationApi.Controllers.JiraIssueControllerComponents;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace JiraIntegrationApi.Controllers;

[ApiController]
[Route("[controller]")]
public class JiraIssueController : ControllerBase
{
    private const string ContentType = "application/json";
    private const string BasicAuthentication = "Basic";

    private readonly HttpClient httpClient;
    private readonly IJiraIssueHelper issueHelper;

    //Get an API token from your Jira account 
    //https://id.atlassian.com/manage-profile/security/api-tokens
    //JIPTOken: 8fPX9YIl9PpicIJPssfD8747

    public JiraIssueController(HttpClient httpClient, IJiraIssueHelper issueHelper)
    {
        this.httpClient = httpClient;
        this.issueHelper = issueHelper;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(JiraIssue jiraIssue)
    {
        var url = issueHelper.GetAddIssueUrl(jiraIssue);
        using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url);
        var authorizationHeader = issueHelper.GetAuthorizationHeader(jiraIssue);
        if (authorizationHeader == JiraIssueHelper.EmptyEmail)  return Problem(JiraIssueHelper.EmptyEmail);
        if (authorizationHeader == JiraIssueHelper.EmptyApiToken) return Problem(JiraIssueHelper.EmptyApiToken);
        httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue(BasicAuthentication, authorizationHeader);
        httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentType));
        var jiraIssueJson = JsonSerializer.Serialize(jiraIssue.data);
        httpRequestMessage.Content = new StringContent(jiraIssueJson, Encoding.UTF8, ContentType);
        var sendResponse = await httpClient.SendAsync(httpRequestMessage);
        sendResponse.EnsureSuccessStatusCode();
        var json = await sendResponse.Content.ReadAsStringAsync();
        return string.IsNullOrWhiteSpace(json) 
            ? Problem() 
            : Ok(json);
    }

    [HttpGet]
    public async Task<IActionResult> GetIssueTypeIdsAsync(JiraIssue jiraIssue)
    {
        var url = issueHelper.GetIssueTypeIdsUrl(jiraIssue);
        using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);
        var authorizationHeader = issueHelper.GetAuthorizationHeader(jiraIssue);
        if (authorizationHeader == JiraIssueHelper.EmptyEmail) return Problem(JiraIssueHelper.EmptyEmail);
        if (authorizationHeader == JiraIssueHelper.EmptyApiToken) return Problem(JiraIssueHelper.EmptyApiToken);
        httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue(BasicAuthentication, authorizationHeader);
        httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentType));
        var jiraIssueJson = JsonSerializer.Serialize(jiraIssue);
        httpRequestMessage.Content = new StringContent(jiraIssueJson, Encoding.UTF8, ContentType);
        var sendResponse = await httpClient.SendAsync(httpRequestMessage);
        sendResponse.EnsureSuccessStatusCode();
        var json = await sendResponse.Content.ReadAsStringAsync();
        return string.IsNullOrWhiteSpace(json)
            ? Problem()
            : Ok(json);
    }
}
