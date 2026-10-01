class Address
{
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        _street = street;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public bool IsInUSA() => _country.Equals("USA", System.StringComparison.OrdinalIgnoreCase)
        || _country.Equals("United States", System.StringComparison.OrdinalIgnoreCase)
        || _country.Equals("United States of America", System.StringComparison.OrdinalIgnoreCase);

    public string GetFullAddress() => $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
}