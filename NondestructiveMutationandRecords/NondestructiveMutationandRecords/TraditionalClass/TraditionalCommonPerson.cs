namespace NondestructiveMutationandRecords.TraditionalClass;

public class TraditionalCommonPerson
{
    public TraditionalCommonPerson(string name = "", int age = 0)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; init; }
    public int Age { get; init; }

    public TraditionalCommonPerson WithName(string name) => new(name, this.Age);
    public TraditionalCommonPerson WithAge(int age) => new(this.Name, age);

    public override string ToString() => $"TraditionalCommonPerson {{ Name = {Name}, Age = {Age} }}";
}
