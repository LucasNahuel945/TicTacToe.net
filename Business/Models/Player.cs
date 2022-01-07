namespace Business.Models
{
    public class Player
    {
        public int Id { get; init; }
        public bool IsPlaying { get; set; }

        public Player(int id)
        {
            this.Id = id;
            this.IsPlaying = false;
        }

        public Player(int id, bool isPlaying)
        {
            this.Id = id;
            this.IsPlaying = isPlaying;
        }

        
    }
}
