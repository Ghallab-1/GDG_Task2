//Youssef Ghallab//



using System;
using System.Collections.Generic;


abstract class Member
{
    public int MemberID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Member(int memberId, string name, int age)
    {
        MemberID = memberId;
        Name = name;
        Age = age;
    }


    public abstract double CalculateMonthlyFee();
    public abstract void DisplayDetails();
}


class RegularMember : Member
{
    public double WorkoutPlanFee { get; set; }
    private const double BaseFee = 50;

    public RegularMember(int memberId, string name, int age, double workoutPlanFee)
        : base(memberId, name, age)
    {
        WorkoutPlanFee = workoutPlanFee;
    }

    public override double CalculateMonthlyFee()
    {
        return BaseFee + WorkoutPlanFee;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Regular Member: {Name}, Age: {Age}, Monthly Fee: ${CalculateMonthlyFee()}");
    }
}


class PremiumMember : Member
{
    public double PersonalTrainerFee { get; set; }
    public double DietPlanFee { get; set; }
    private const double BaseFee = 100;

    public PremiumMember(int memberId, string name, int age, double personalTrainerFee, double dietPlanFee)
        : base(memberId, name, age)
    {
        PersonalTrainerFee = personalTrainerFee;
        DietPlanFee = dietPlanFee;
    }

    public override double CalculateMonthlyFee()
    {
        return BaseFee + PersonalTrainerFee + DietPlanFee;
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Premium Member: {Name}, Age: {Age}, Monthly Fee: ${CalculateMonthlyFee()}");
    }
}


interface IGymManagement
{
    void AddMember(Member member);
    void DisplayAllMembers();
}


class Gym : IGymManagement
{
    private List<Member> members = new List<Member>();

    public void AddMember(Member member)
    {
        members.Add(member);
    }

    public void DisplayAllMembers()
    {
        Console.WriteLine("\n--- Gym Members ---");
        foreach (var member in members)
        {
            member.DisplayDetails();
        }
    }
}


class Program
{
    static void Main()
    {
        Gym gym = new Gym();

        
        gym.AddMember(new RegularMember(1, "Ghallab", 25, 20));
        gym.AddMember(new RegularMember(2, "Joe", 30, 30));

        
        gym.AddMember(new PremiumMember(3, "Mido", 28, 50, 40));
        gym.AddMember(new PremiumMember(4, "Honda", 35, 60, 50));

        
        gym.DisplayAllMembers();
    }
}
