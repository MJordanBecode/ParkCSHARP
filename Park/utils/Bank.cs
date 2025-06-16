using Park.DB;
namespace Park.utils;


public interface Bank
{
    public  int increaseMoney(int amout);
    public int decreaseMoney(int amout);
}

public class  Money : Bank
{
    public static string dbPath = "./DB/park.sqlite"; // Faire une méthode qui me permet de faire ça pour éviter le DRY 
    public static DatabaseManager takeMoneyDatabase = new(dbPath);

    int moneyBank = takeMoneyDatabase.GetDataBank();
    public int increaseMoney(int amount)
    {
 
        int increase = moneyBank + amount;
        takeMoneyDatabase.UpdateDataBank(increase);
        return increase; 
    }

    public int decreaseMoney(int amount)
    {
        int descrease = moneyBank - amount;
        takeMoneyDatabase.UpdateDataBank(descrease);
        return descrease; 
    }
}

    

