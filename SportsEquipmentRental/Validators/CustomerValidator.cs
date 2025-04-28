using FluentValidation;

public class CustomerValidator : AbstractValidator<CustomerViewModel>
{
    public CustomerValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Imię jest wymagane.")
            .MaximumLength(50).WithMessage("Imię nie może przekraczać 50 znaków.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Nazwisko jest wymagane.")
            .MaximumLength(50).WithMessage("Nazwisko nie może przekraczać 50 znaków.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email jest wymagany.")
            .EmailAddress().WithMessage("Nieprawidłowy format adresu email.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Numer telefonu jest wymagany.")
            .Matches(@"^\d{9}$").WithMessage("Numer telefonu musi składać się z 9 cyfr.");
    }
}
