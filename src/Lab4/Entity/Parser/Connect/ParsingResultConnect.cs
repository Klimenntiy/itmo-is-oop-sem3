namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.Parser.Connect;

public class ParsingResultConnect
{
    public string Address { get; private set; }

    public string Mode { get; private set; }

    public ParsingResultConnect()
    {
        Address = string.Empty;
        Mode = string.Empty;
    }

    public void SetAddress(string address)
    {
        Address = address;
    }

    public void SetMode(string mode)
    {
        Mode = mode;
    }
}