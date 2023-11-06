namespace BinaryTree;

public interface IAbstractBinarySearchTree<E> where E : IComparable<E>
{
    void Insert(E element);
    bool Contains(E element);
    AbstractBinarySearchTree<E> Search(E element);
    BinarySearchTreeNode<E> GetRoot();
    BinarySearchTreeNode<E> GetLeft();
    BinarySearchTreeNode<E> GetRight();
    E GetValue();
}