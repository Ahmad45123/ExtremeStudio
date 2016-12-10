namespace Classes.ObjectExplorer
{
    public class ObjectExplorerItem
    {
        public ObjectExplorerItem(string name, string iden)
        {
            this.Name = name;
            Identifier = iden;
        }

        public string Name { get; set; }
        public string Identifier { get; set; }
    }
}