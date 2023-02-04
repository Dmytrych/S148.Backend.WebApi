namespace S148.Backend.Domain.Dto;

public class Image
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Extension { get; set; }
    
    public string MD5Checksum { get; set; }

    public byte[] Content { get; set; }
}