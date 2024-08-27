namespace NondestructiveMutationandRecords.UsingInitSetters;

public class InitSettersCommonPerson
{
    public InitSettersCommonPerson(string name = "", int age = 0)
    {
        this.Name = name;
        this.Age = age;
    }

    public InitSettersCommonPerson(InitSettersCommonPerson copy) : this(copy.Name, copy.Age) { }

    public string Name { get; init; }
    public int Age { get; init; }

    public InitSettersCommonPerson WithName(string name) => new(name, this.Age);
    public InitSettersCommonPerson WithAge(int age) => new(this.Name, age);

    public override string ToString() => $"InitSettersCommonPerson {{ Name = {Name}, Age = {Age} }}";
}
