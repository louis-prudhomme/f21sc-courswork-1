namespace f21sc_courswork_1.Model
{
    public class Node<T>
    {
        public T Left { get; }
        public T Center { get; }
        public T Right { get; }

        public Node(T left, T center, T right)
        {
            this.Left = left;
            this.Center = center;
            this.Right = right;
        }

        public bool HasLeft => this.Left != null;
        public bool HasCenter => this.Center != null;
        public bool HasRight => this.Right != null;
    }
}
