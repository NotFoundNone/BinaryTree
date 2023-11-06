namespace BinaryTree;

public class BinaryTreeNode<E> where E : IComparable 
{ 
    public E Key { get; set; } 
    public AbstractBinaryTree<E> LeftKey { get; set; }
    public AbstractBinaryTree<E> RightKey { get; set; }
    public BinaryTreeNode(E value) 
    { 
        Key = value;
    }
}