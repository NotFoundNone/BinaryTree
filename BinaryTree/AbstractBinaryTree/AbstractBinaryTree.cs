using System.Text;

namespace BinaryTree;

public class AbstractBinaryTree<E>: IAbstractBinaryTree<E> where E : IComparable
{
    public BinaryTreeNode<E> Root;
    
    public E GetKey()
    {
        return Root.Key;
    }

    public AbstractBinaryTree<E> GetLeft()
    {
        return Root.LeftKey;
    }

    public AbstractBinaryTree<E> GetRight()
    {
        return Root.RightKey;
    }

    public void SetKey(E key)
    {
        Root = SetKeyRec(Root, key);
    }
    
    private BinaryTreeNode<E> SetKeyRec(BinaryTreeNode<E> node, E value)
    {
        if (node == null)
        {
            return new BinaryTreeNode<E>(value);
        }

        if (value.CompareTo(node.Key) < 0)
        {
            if (node.LeftKey == null)
            {
                node.LeftKey = new AbstractBinaryTree<E>();
            }
            node.LeftKey.SetKey(value);
        }
        else if (value.CompareTo(node.Key) > 0)
        {
            if (node.RightKey == null)
            {
                node.RightKey = new AbstractBinaryTree<E>();
            }
            node.RightKey.SetKey(value);
        }

        return node;
    }
    
    public string AsIndentedPreOrder(int indent)
    {
        StringBuilder result = new StringBuilder();
        result.Append(new string(' ', indent));
        result.AppendLine(Root.Key.ToString());
        if (Root.LeftKey != null)
        {
            result.Append(Root.LeftKey.AsIndentedPreOrder(indent - 2));
        }
        if (Root.RightKey != null)
        {
            result.Append(Root.RightKey.AsIndentedPreOrder(indent + 2));
        }
        return result.ToString();
    }
    public List<AbstractBinaryTree<E>> PreOrder()
    {
        List<AbstractBinaryTree<E>> result = new List<AbstractBinaryTree<E>>();
        PreOrder(this, result);
        return result;
    }

    public List<AbstractBinaryTree<E>> InOrder()
    {
        List<AbstractBinaryTree<E>> result = new List<AbstractBinaryTree<E>>();
        InOrder(this, result);
        return result;
    }
    
    public List<AbstractBinaryTree<E>> PostOrder()
    {
        List<AbstractBinaryTree<E>> result = new List<AbstractBinaryTree<E>>();
        PostOrder(this, result);
        return result;
    }
    
    private void PostOrder(AbstractBinaryTree<E> node, List<AbstractBinaryTree<E>> result)
    {
        if (node == null)
            return;
        PostOrder(node.Root.LeftKey, result);
        PostOrder(node.Root.RightKey, result);
        result.Add(node);
    }
    private void PreOrder(AbstractBinaryTree<E> node, List<AbstractBinaryTree<E>> result)
    {
        if (node == null)
            return;

        result.Add(node);
        PreOrder(node.Root.LeftKey, result);
        PreOrder(node.Root.RightKey, result);
    }
    private void InOrder(AbstractBinaryTree<E> node, List<AbstractBinaryTree<E>> result)
    {
        if (node == null)
            return;

        InOrder(node.Root.LeftKey, result);
        result.Add(node);
        InOrder(node.Root.RightKey, result);
    }
    public void ForEachInOrder(Action<E> consumer)
    {
        if (Root.LeftKey != null)
        {
            Root.LeftKey.ForEachInOrder(consumer);
        }
        consumer(Root.Key);
        if (Root.RightKey != null)
        {
            Root.RightKey.ForEachInOrder(consumer);
        }
    }

    public void orderBFS()
    {
        if (this == null)
            return;

        Queue<AbstractBinaryTree<E>> queue = new Queue<AbstractBinaryTree<E>>();
        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();
            Console.Write(currentNode.GetKey() + " ");

            if (currentNode.GetLeft() != null)
            {
                queue.Enqueue(currentNode.GetLeft());
            }

            if (currentNode.GetRight() != null)
            {
                queue.Enqueue(currentNode.GetRight());
            }
        }
        Console.WriteLine();
    }
    
    public void orderDFS()
    {
        if (this == null)
            return;
        this.GetLeft()?.orderDFS();
        this.GetRight()?.orderDFS();
        Console.Write(this.GetKey() + " ");
    }
    
    
}

