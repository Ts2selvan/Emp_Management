namespace EMP_Management.Models
{
    public class EmpViewModel
    {
        public List<Employees> Employees { get; set; }
        public List<string> Designations { get; set; }
        public string SelectedDesignation { get; set; }
    }
}
