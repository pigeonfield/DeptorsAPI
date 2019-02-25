namespace DluznicyAPI.DAL.DAO
{
    public class RulesFilter
    {
        public int? WaitingTime { get; set; }

        public bool? LendOnlyToEmployed { get; set; }

        public bool? RequiresAddress { get; set; }

        public int? MaxAmountOfMoney { get; set; }

        public bool IsEmpty
        {
            get
            {
                return (WaitingTime == null && LendOnlyToEmployed == null && RequiresAddress == null && MaxAmountOfMoney == null);
            }
        }

    }
}