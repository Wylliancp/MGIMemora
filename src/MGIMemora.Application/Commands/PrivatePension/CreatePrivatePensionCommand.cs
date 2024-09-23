using MGIMemora.Domain.Commands;

namespace MGIMemora.Application.Commands.PrivatePension
{

    public class CreatePrivatePensionCommand : ICommand
    {
        public String Name { get; set; } = default!;
        public String BenefitName { get; set; } = default!;
        public String Modality { get; set; } = default!;
        public Decimal ValueMillions { get; set; } = default!;
        public String SponsorshipCompany { get; set; } = default!;
    }
    
}