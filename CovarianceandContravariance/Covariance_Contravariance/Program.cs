////////////////////////////////Covariance and Contravariance/////////////////////////////////////////////////////////////////////
Console.WriteLine(new string('-', 40));
Console.WriteLine("Covariance and Contravariance");

Base x = new Base();
//we are assigning Base object to Base reference
Console.WriteLine($"Base x = new Base();");
x.DoSomething();
//x.DoMore();
//Cannt access Derived member with X object

Console.WriteLine();


Console.WriteLine($"Base y = new Derived();");
Base y = new Derived();
//we are assigning Derived object to Base reference
y.DoSomething();
//y.DoMore();
/*
 Can we invoke the member of the Derived member on Object Y
which is the object of the Derived class ?

No because compiler does not see that object as the derived object.
It is accessing it through the reference to the base class
and base class has no reference which we are seeking 

We must or instantiate or at least assign the derived object
to a reference of derived type
 */

Console.WriteLine();

Console.WriteLine($"Derived z = new Derived();");
Derived z = new Derived();
//we are assigning Derived object to Derived reference
z.DoSomething();
z.DoMore();
// We can access Derived and Base members with Z object

Console.WriteLine();

Console.WriteLine($"Derived z1 = new Base();");
//Derived z1 = new Base();
//we are trying to assigning Base object to Derived reference but we cant achieve this suitation
Console.WriteLine();

IProducer<Base> prodOfBase = null!;

Base a = prodOfBase.Produce();
//This object is returning instances of the base types
// That is what its declaration says.

// Derived b = prodOfBase.Produce();
//But could we assign that to the derive reference
// No because this interface the producer of the base type,
// is returning something that is declared as the base type
// and we cannot assign that to the derived, that would violate the Object Substitution Principle 
//So this assignment is not illegal in c#
// What is legal in c# though, is if we start from the other end, from a producer of Derived type.

/*
 Here, IProducer<Base> is a generic interface that produces 
instances of Base. Since Derived is a subtype of Base, 
you can't directly assign the result of Produce() 
to a Derived variable. This is because prodOfBase is 
declared as producing Base, not Derived, even though 
Derived is a subtype of Base.
 */
Console.WriteLine();

IProducer<Derived> prodOfDerived = null!;
Derived b = prodOfDerived.Produce();
Base c = prodOfDerived.Produce();

//we can obviously assign that, the product of that object to the divied reference yes that is the same thing
// This interface is producing a derived object, it is declared
// but we can also assign that to a base reference 
// That is Object Substitution Principle applied in a legal way.
//So in a way, it turns out that the IProducer of the derived class behave like a 
// derived interface from the IProducer of the base class 
//These two interfaces are behaving covariantly, they are moving in the same direction.
//You derived a class, a generic parameters class, one from another, and the interface behave



Console.WriteLine();
/*
 In this scenario, IProducer<Derived> is a generic interface that
produces instances of Derived. 
You can assign the result of Produce() to both 
Derived and Base variables because Derived is a subtype of Base,
so it's valid to treat a Derived instance as a Base.

Derived : Base
implies
IProducer<Derived> : IProducer<Base>
a.k.a Covariant
 */

IConsumer<Base> consOfBase = null!;
consOfBase.Consume(new Base());
consOfBase.Consume(new Derived());

// What happens when we start using consumers
// the consuming interface which is accepting objects 
// so, the consumer of base can obviously receive an object, a concrete object of the base type, that is the same thing
// So we can assign the new base to the method argument which accepts a base
// what if we pass the derived object
// again this if fine because we can assign the derived object to the method argument declared as base

Console.WriteLine();

IConsumer<Derived> consOfDerived = null!;
//consOfDerived.Consume(new Base());
consOfDerived.Consume(new Derived());
//But what if it started from other end consumer of the derived type?
// obviously we can pass the derived object in, that's is fine.
// But we cant pass base object in
// because base cant assigned to the method argument expecting derived.
//That is how it is declared, so this invocation would violate the object substitution principle.
//in a way object consuming interface, generic interfaces are behaving contravariantyl 
// so that if you applied derived class as the generic type parameter 
// then you would construct a base interface it behaves oppositely.



/*

Derived : Base
implies
IConsumer<Base> : IConsumer<Derived>
a.k.a Contravariant
 */

Console.WriteLine();

IProducer<Base> p = prodOfBase;
//We can assign a producer of base type to reference of the same
IProducer<Base> q = prodOfDerived;
// we can assign a producer of derived class to the reference which is producer of base
//Right hand side would produce derived object which are assignable to base objects.

IProducer<Derived> r = prodOfDerived;
// we can assign derived producer to the  derived producer reference of course thats the same type.

//IProducer<Derived> s = prodOfBase;
//we cant do the other way around
// the producer of base type is the super type of producer of derived and the assignment is illegal 


IConsumer<Base> t = consOfBase;
//
//IConsumer<Base> u = consOfDerived;
// that means somebody would try to pass the base object into a method expecting derived object.
IConsumer<Derived> v = consOfBase;
// We can assign consumer of base
// because consumer of base is expecting the base object and we can pass the derived object in.
IConsumer<Derived> w = consOfDerived;
// if we had a reference to the consumer of derived,

//incomplete 





//Variance can be declared on interfaces and delegate types in C#
//It is augmenting the Object Substitution Principle to work for generic type
//Variance is all about Object Substitution when speaking about generic types, objects or generic type
//When we come to generic interface they can produce or consume objects

interface IProducer<out T>
{
    T Produce();
}
// This out is indicating the covariant type

interface IConsumer<in T>
{
    void Consume(T obj);
}
//An interface which consumes or accepts the object of Parameter type T through its member, 
//then we denote it as 'in' T it is coming into the interface object.
// we call as contravariant type


public class Base
{
    public void DoSomething() => Console.WriteLine($"Doing Some Thing From {this.GetType().Name}");
}

public class Derived : Base
{
    public void DoMore() => Console.WriteLine($"Doing More Thing From {this.GetType().Name}");
}
