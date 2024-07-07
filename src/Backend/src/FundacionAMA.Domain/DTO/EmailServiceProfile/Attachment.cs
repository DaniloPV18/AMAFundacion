namespace FundacionAMA.Domain.DTO.EmailServiceProfile;

public class Attachment
{
    public Attachment(byte[] bytes, string name, string contentType)
    {
        Bytes = bytes;
        Name = name;
        ContentType = contentType;
    }

    public Byte[] Bytes { get; set; }
    public string Name { get; set; }
    public string ContentType { get; set; }
}
