namespace Contracted.Models
{
    public class Contractor
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class ContractorCompanyViewModel : Contractor
    {

        public int JobId { get; set; }

    }
}