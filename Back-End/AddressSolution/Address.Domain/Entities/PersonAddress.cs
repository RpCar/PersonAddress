namespace AddressService.Domain.Entities
{
    public class PersonAddress
    {
        public string Id { get; set; } = string.Empty;
        public Address Address { get; set; } = new();
        public Name Name { get; set; } = new();

    }
}
