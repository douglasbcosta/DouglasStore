
using FluentValidator;
using FluentValidator.Validation;

namespace DouglasStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 30, "FirstName", "O nome deve conter pelo menos 30 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(LastName, 30, "LastName", "O sobrenome deve conter pelo menos 30 caracteres");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString(){
            return $"{FirstName} {LastName}";
        }
    }
}