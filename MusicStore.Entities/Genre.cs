namespace MusicStore.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public Genre()
        {
            Status = true;
        }
    }

}