namespace SimpleAPI.DataAccessLayer.Models;

public class SecretModel : BaseModel
{
    public string Title { get; set; } = string.Empty;
    public string SecretName { get; set; } = string.Empty;
    public string SecretValue { get; set; } = string.Empty;
    public string URL { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public DateTime ExpirationDate { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime LastModificationTime { get; set; }

    public CategoryModel Category { get; set; }
}