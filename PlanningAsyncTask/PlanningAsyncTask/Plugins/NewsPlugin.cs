using System.ComponentModel;
using Microsoft.SemanticKernel;
using SimpleFeedReader;

namespace PlanningAsyncTask.Plugins;

public class NewsPlugin
{
    [KernelFunction("get_news")]
    [Description("gets news items for today's date.")]
    [return: Description("A list of current news stories.")]
    public List<FeedItem> GetNews(Kernel kernel)
    {
        var reader = new FeedReader();
        return reader.RetrieveFeed($"https://rss.nytimes.com/services/xml/rss/nyt/technology.xml")
            .Take(10)
            .ToList();
    }
}