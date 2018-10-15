namespace TheHeiganDance
{
    public class Player
    {
        public int LifePoints { get; set; } = 18500;

        public int RowIndex { get; set; } = 7;
        public int ColumnIndex { get; set; } = 7;

        public double AttackPoints { get; set; }

        public string KilledBy { get; set; }

        public bool IsAlive => this.LifePoints > 0;
    }
}
