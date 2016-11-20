namespace BSTree.Class
{
   public class Node
    {
        public Node(int key, int value)
        {
            this.Key = key;
            this.Value = value;
        }
        public int Key { get; set; }
        public int Value { get; set; }
        public Node Left {get; set;}
        public Node Right { get;set;}
    }
}
