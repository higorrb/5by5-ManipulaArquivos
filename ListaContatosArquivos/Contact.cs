public class Contact(string n, string p, char g)
{
    //public int Id { get; set; }
    public string Name { get; set; } = n;
    public string Phone { get; set; } = p;
    public char Gender { get; set; } = g;

    public override string ToString()
    {
        return $" Name: {Name}, Phone: {Phone}, Gender: {Gender}";
    }
}