using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models.cam;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Models.inf;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System.ComponentModel;
using System.Text;

namespace InfluencerManagerApp.Core;

public class Controller : IController
{
    private readonly IRepository<IInfluencer> influencers;
    private readonly IRepository<ICampaign> campaigns;

    public Controller()
    {
        this.influencers = new InfluencerRepository();
        this.campaigns = new CampaignRepository();
    }

    public string RegisterInfluencer(string typeName, string username, int followers)
    {
        if (typeName != nameof(BloggerInfluencer) &&
            typeName != nameof(BusinessInfluencer) &&
            typeName != nameof(FashionInfluencer))
        {
            return string.Format(OutputMessages.InfluencerInvalidType, typeName);
        }


        if (this.influencers.FindByName(username) != null)
        {
            return string.Format(OutputMessages.UsernameIsRegistered, username, nameof(InfluencerRepository));
        }

        IInfluencer influencer;

        if (typeName == nameof(BloggerInfluencer))
        {
            influencer = new BloggerInfluencer(username, followers);
        }
        else if (typeName == nameof(BusinessInfluencer))
        {
            influencer = new BusinessInfluencer(username, followers);
        }
        else
        {
            influencer = new FashionInfluencer(username, followers);
        }

        this.influencers.AddModel(influencer);
        return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
    }

    public string BeginCampaign(string typeName, string brand)
    {
        if (typeName != nameof(ProductCampaign) && typeName != nameof(ServiceCampaign))
        {
            return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
        }

        if (this.campaigns.FindByName(brand) != null)
        {
            return string.Format(OutputMessages.CampaignDuplicated, brand);
        }

        ICampaign campaign;

        if (typeName == nameof(ProductCampaign))
        {
            campaign = new ProductCampaign(brand);
        }
        else
        {
            campaign = new ServiceCampaign(brand);
        }

        this.campaigns.AddModel(campaign);
        return string.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
    }

    public string AttractInfluencer(string brand, string username)
    {
        if (this.influencers.FindByName(username) == null)
        {
            return string.Format(OutputMessages.InfluencerNotFound, nameof(InfluencerRepository), username);
        }

        if (this.campaigns.FindByName(brand) == null)
        {
            return string.Format(OutputMessages.CampaignNotFound, brand);
        }

        IInfluencer influencer = this.influencers.FindByName(username);
        ICampaign campaign = this.campaigns.FindByName(brand);

        if (campaign.Contributors.Contains(influencer.Username))
        {
            return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
        }

        bool isEligible = true;

        if (campaign is ProductCampaign && influencer is BloggerInfluencer)
        {
            isEligible = false;
        }
        else if (campaign is ServiceCampaign && influencer is FashionInfluencer)
        {
            isEligible = false;
        }

        if (!isEligible)
        {
            return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
        }

        if (campaign.Budget < influencer.CalculateCampaignPrice())
        {
            return string.Format(OutputMessages.UnsufficientBudget, brand, username);
        }

        influencer.EarnFee(influencer.CalculateCampaignPrice());
        influencer.EnrollCampaign(brand);
        campaign.Engage(influencer);

        return string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
    }

    public string FundCampaign(string brand, double amount)
    {

        if (this.campaigns.FindByName(brand) == null)
        {
            return string.Format(OutputMessages.InvalidCampaignToFund);
        }

        if (amount <= 0)
        {
            return string.Format(OutputMessages.NotPositiveFundingAmount);
        }

        campaigns.FindByName(brand).Gain(amount);

        return string.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
    }

    public string CloseCampaign(string brand)
    {
        ICampaign campaign = this.campaigns.FindByName(brand);
        if (campaign == null)
        {
            return string.Format(OutputMessages.InvalidCampaignToClose);
        }

        if (campaign.Budget <= 10_000)
        {
            return string.Format(OutputMessages.CampaignCannotBeClosed, brand);
        }

        foreach (var influencer in campaign.Contributors)
        {
            IInfluencer influencer1 = influencers.FindByName(influencer);
            influencer1.EarnFee(2000);
            influencer1.EndParticipation(brand);
        }

        campaigns.RemoveModel(campaign);
        return string.Format(OutputMessages.CampaignClosedSuccessfully, brand);
    }

    public string ConcludeAppContract(string username)
    {
        if (!this.influencers.Models.Any(x=>x.Username == username))
        {
            return string.Format(OutputMessages.InfluencerNotSigned, username);
        }

        IInfluencer influencer = this.influencers.FindByName(username);

        if (influencer.Participations.Count > 0)
        {
            return string.Format(OutputMessages.InfluencerHasActiveParticipations, username);
        }

        this.influencers.RemoveModel(influencer);
        return string.Format(OutputMessages.ContractConcludedSuccessfully, username);
    }

    public string ApplicationReport()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var influencer in influencers.Models
                     .OrderByDescending(i=>i.Income)
                     .ThenByDescending(i=>i.Followers))
        {
            sb.AppendLine(influencer.ToString());

            if (influencer.Participations.Any())
            {
                sb.AppendLine("Active Campaigns:");

                foreach (var campaign in this.campaigns.Models.Where(x=>x.Contributors.Contains(influencer.Username)).OrderBy(x=>x.Brand))
                {
                    sb.AppendLine($"--{campaign.ToString()}");
                }
            }
        }

        return sb.ToString().TrimEnd();
    }
}