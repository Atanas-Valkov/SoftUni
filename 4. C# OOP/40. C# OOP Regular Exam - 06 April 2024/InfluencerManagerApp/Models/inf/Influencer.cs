using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System.Numerics;

namespace InfluencerManagerApp.Models.inf;

public abstract class Influencer : IInfluencer
{
    private string username;
    private int followers;
    private double engagementRate;
    private double income;
    private readonly List<string> participations;

    protected Influencer(string username, int followers, double engagementRate)
    {
        this.Username = username;
        this.Followers = followers;
        this.EngagementRate = engagementRate;
        this.Income = 0;
        participations = new List<string>();
    }

    public string Username
    {
        get => this.username;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
            }

            this.username = value;
        }
    }

    public int Followers
    {
        get => this.followers;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
            }
            this.followers = value;
        }
    }

    public double EngagementRate
    {
        get => this.engagementRate;
        private set
        {
            this.engagementRate = value;
        }
    }

    public double Income
    {
        get => this.income;
        private set
        {
            this.income = value;
        }
    }

    public IReadOnlyCollection<string> Participations => this.participations.AsReadOnly();


    public void EarnFee(double amount)
    {
        this.Income += amount;              /// ?!?!?!?!??!
    }

    public void EnrollCampaign(string brand)
    {
        this.participations.Add(brand);
    }

    public void EndParticipation(string brand)
    {
        this.participations.Remove(brand);
    }

    public abstract int CalculateCampaignPrice();
    
    public override string ToString()
    {
        return $"{this.username} - Followers: {this.followers}, Total Income: {this.income}";
    }
}

