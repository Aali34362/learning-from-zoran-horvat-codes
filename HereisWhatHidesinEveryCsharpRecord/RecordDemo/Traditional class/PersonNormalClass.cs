namespace RecordDemo.Traditional_class;

public class PersonNormalClass : IEquatable<PersonNormalClass>
{
    public string Name { get; init; }
    public DateOnly BirthDate { get; init; }

    public PersonNormalClass(string name, DateOnly birthDate)
    {
        this.Name = name;
        this.BirthDate = birthDate;
    }

    public void Deconstruct(out string name, out DateOnly birthDate)
    {
        name = this.Name;
        birthDate = this.BirthDate;
    }

    public bool Equals(PersonNormalClass? other) =>
        other?.Name.Equals(this.Name) == true &&
        other?.BirthDate.Equals(this.BirthDate) == true;

    public override bool Equals(object? other) => this.Equals(other as PersonNormalClass);

    public override int GetHashCode() => HashCode.Combine(this.Name, this.BirthDate);

    public override string ToString() =>
        $"{nameof(PersonNormalClass)} {{ {nameof(Name)} = {Name}, {nameof(BirthDate)} = {BirthDate} }}";
}