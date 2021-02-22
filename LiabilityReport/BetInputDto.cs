namespace LiabilityReport
{
    public class BetInputDto
    {
        public BetInputDto(BetInputDto BetDto)
        {
            BetId = BetDto.BetId;
            SelectionName = BetDto.SelectionName;
            SelectionId = BetDto.SelectionId;
            Stake = BetDto.Stake;
            Price = BetDto.Price;
            Currency = BetDto.Currency;
        }

        public BetInputDto()
        {
        }

        public string BetId { get; set; }

        public string BetTimestamp { get; set; }

        //int because betIds will grow.
        public int SelectionId { get; set; }

        public string SelectionName { get; set; }

        public double Stake { get; set; }

        public double Price { get; set; }
        
        public string Currency { get; set; }
                
    }
}
