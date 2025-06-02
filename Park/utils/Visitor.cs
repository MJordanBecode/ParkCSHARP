namespace Park.utils;

public class NewVisitor
{
    public int Visitor;
    public int Ticket;
    public NewVisitor(int visitor, int ticket)
    {
        Visitor = visitor;
        Ticket = ticket;
    }
    
    public static void generateVisitor(int visitor, int ticket)
    {
        visitor = 1;
        ticket = 0;
        
        
    }

    public string ShowNumberOfVisitor(int visitor)
    {
        return visitor.ToString();
    }
    
}