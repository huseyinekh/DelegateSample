using DayEndTask.Models;






static class Program
{
    static void Main()
    {
  

        Company company = new Company();
        company.Name = "Azur Company";
     


         company.Register("User", "Men", "123");
        company.Login("UserMen", "123");




    }
}