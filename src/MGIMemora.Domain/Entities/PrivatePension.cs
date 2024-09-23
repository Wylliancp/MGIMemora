namespace MGIMemora.Domain.Entities
{
    public class PrivatePension : Entity
    {
        public PrivatePension(string name, string benefitName, string modality, decimal valueMillions, string sponsorshipCompany)
        {
            Name = name;
            BenefitName = benefitName;
            Modality = modality;
            ValueMillions = valueMillions;
            SponsorshipCompany = sponsorshipCompany;
        }


        public String Name { get; private set; } = default!;
        public String BenefitName { get; private set; } = default!;
        public String Modality { get; private set; } = default!;
        public Decimal ValueMillions { get; private set; } = default!;
        public String SponsorshipCompany { get; private set; } = default!;

        public void UpdateModality(String modality){
            this.Modality = modality;
        }

        public void Update(String name, String benefitName, Decimal valueMillions, String sponsorshipCompany)
        {
            this.Name = name;
            this.BenefitName = benefitName;
            this.ValueMillions = valueMillions;
            this.SponsorshipCompany = sponsorshipCompany;
        }

    }
}