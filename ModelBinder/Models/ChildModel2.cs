namespace ModelBinder.Models
{
    public class ChildModel2 : BaseModel
    {
        public override int Type { get { return 2; } }
        public int Id { get; set; }
        public int BaseId { get; set; }
        public string Address { get; set; }
    }
}
