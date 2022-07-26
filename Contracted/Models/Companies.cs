namespace Contracted.Models
{
    public class Companies
    {

        public int Id { get; set; }

        public string Name { get; set; }

    }

    public class CompanyContractorViewModel : Companies
    {

        public int JobId { get; set; }

    }

}