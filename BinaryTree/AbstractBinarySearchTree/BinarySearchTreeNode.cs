namespace BinaryTree;

public class BinarySearchTreeNode<E> where E : IComparable<E>
{
    public E Value;
    public BinarySearchTreeNode<E> LeftChild;
    public BinarySearchTreeNode<E> RightChild;
    public int DuplicateCount;

    public BinarySearchTreeNode(E value)
    {
        this.Value = value;
    }
    
    public BinarySearchTreeNode(E value, BinarySearchTreeNode<E> leftChild, BinarySearchTreeNode<E> rightChild, int duplicateCount)
    {
        this.Value = value;
        this.LeftChild = leftChild;
        this.RightChild = rightChild;
        this.DuplicateCount = duplicateCount;
    }
}