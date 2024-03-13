namespace CleanArch.MVC.Domain.Validation;
public class DomainExcpetionValidation : Exception
{
    public DomainExcpetionValidation(String error) : base(error)
    {}

    public static void When(bool hasError, string error){
        if(hasError)
            throw new DomainExcpetionValidation(error);
    }
}