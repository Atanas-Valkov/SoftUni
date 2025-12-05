namespace InfluencerManagerApp.Models.cam;

public class ServiceCampaign : Campaign
{
    private const double budget = 30_000; 
    public ServiceCampaign(string brand) 
        : base(brand, budget)
    {
    }
}