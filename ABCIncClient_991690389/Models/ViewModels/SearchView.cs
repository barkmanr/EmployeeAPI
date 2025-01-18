namespace ABCIncClient_991690389.Models.ViewModels
{
    /// <summary>
    /// View used for searching
    /// Template class to allow any data type to be the search result
    /// Has list of employee and search result
    /// </summary>
    public class SearchView<T>
    {
        public List<EmployeeVM>? Emps { get; set; }
        public T? Search { get; set; }
    }
}
