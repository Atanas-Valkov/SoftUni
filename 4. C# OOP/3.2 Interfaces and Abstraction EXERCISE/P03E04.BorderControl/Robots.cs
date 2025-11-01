using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;

namespace P03E04.BorderControl;

public class Robots : ICheckable
{
    private string model;
    private string id;
    public Robots(string model, string id)
    {
        this.Model = model;
        this.Id = id;
    }

    public string Model { get; private set; }
    public string Id { get; private set; }
}