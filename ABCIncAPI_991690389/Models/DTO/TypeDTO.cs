namespace ABCIncAPI_991690389.Models.DTO
{
    /// <summary>
    /// Dto used when searching for type
    /// Dosn't include salary or dependent count
    /// </summary>
    public class TypeDTO
    {
        public int eId { get; set; }
        public string? eName { get; set; }
        public string? eEmail { get; set; }
        public string? eEmploymentType { get; set; }
    }
}
