namespace InfluencerManagerApp.Models.inf;

public class BloggerInfluencer : Influencer
{
    private const double engagementRate = 2;
    private const double factor = 0.2;

    public BloggerInfluencer(string username, int followers) 
        : base(username, followers, engagementRate)
    {
    }

    public override int CalculateCampaignPrice()
    {
        return (int)Math.Floor(Followers * engagementRate * factor);
    }
}