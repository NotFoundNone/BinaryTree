namespace BinaryTree;

public interface IAbstractBinaryTree<E> where E : IComparable
{
        E GetKey();
        AbstractBinaryTree<E> GetLeft();
        AbstractBinaryTree<E> GetRight();
        void SetKey(E key);
        string AsIndentedPreOrder(int indent);
        List<AbstractBinaryTree<E>> PreOrder();
        List<AbstractBinaryTree<E>> InOrder();
        List<AbstractBinaryTree<E>> PostOrder();
        void ForEachInOrder(Action<E> consumer);
}