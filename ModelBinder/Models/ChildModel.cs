namespace ModelBinder.Models
{
    public class ChildModel : BaseModel
    {
        public override int Type { get { return 1; } }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
