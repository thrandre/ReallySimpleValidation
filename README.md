ReallySimpleValidation
======================

Validator.Register(
  new Validator<Person>(
    new Required<Person>(p => p.Name)), // Required property
    new InRange<Person>(p => p.Age, 20, 30); // Age required to be in range [20, 30]
    
var person = new Person
{
  Name = "",
  Age = 25
};

Validator.For<Person>().Validate(person); // Throws exception.

var valid = Validator.For<Person>().Validate(person, silent: true); // Fails gracefully and returns false.
