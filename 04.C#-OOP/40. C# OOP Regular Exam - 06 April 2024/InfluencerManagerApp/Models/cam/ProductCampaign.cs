namespace InfluencerManagerApp.Models.cam;

public class ProductCampaign : Campaign
{
    private const double budget = 60_000;
    public ProductCampaign(string brand) 
        : base(brand, budget)
    {
    }
}