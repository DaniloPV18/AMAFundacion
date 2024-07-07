namespace FundacionAMA.Application.DTO;

public class BasicResponse
{
    public Guid Id { get; set; }
    public string ErrorMessage { get; set; }

    public BasicResponse(BasicResponse obj)
    {
        Id = obj.Id;
        ErrorMessage = obj.ErrorMessage;
    }
    public BasicResponse(Guid id, string errorMessage)
    {
        Id = id;
        ErrorMessage = errorMessage;
    }
    public BasicResponse(string errorMessage)
    {
        Id = Guid.NewGuid();
        ErrorMessage = errorMessage;
    }
}
