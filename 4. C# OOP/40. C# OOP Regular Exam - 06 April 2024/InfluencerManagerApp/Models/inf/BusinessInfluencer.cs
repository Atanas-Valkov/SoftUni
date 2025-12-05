namespace InfluencerManagerApp.Models.inf;

public class BusinessInfluencer : Influencer
{
    private const double engagementRate = 3.0;
    private const double factor = 0.15;

    public BusinessInfluencer(string username, int followers)
        : base(username, followers, engagementRate)
    {
    }

    public override int CalculateCampaignPrice()
    {
        return (int)Math.Floor(Followers * engagementRate * factor);
    }


}