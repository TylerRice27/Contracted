namespace Contracted.Models
{
    public class Company
    {

        public int Id { get; set; }

        public string Name { get; set; }

    }

    public class CompanyContractorViewModel : Company
    {

        public int JobId { get; set; }

    }

}