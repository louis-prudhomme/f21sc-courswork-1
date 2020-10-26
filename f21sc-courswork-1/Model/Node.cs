namespace f21sc_coursework_1.Model
{
    /// <summary>
    /// Abstract representation of a node
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
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
