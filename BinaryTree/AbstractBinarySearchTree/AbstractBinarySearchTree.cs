namespace BinaryTree;

public class AbstractBinarySearchTree<E> : IAbstractBinarySearchTree<E> where E : IComparable<E>
{
    private BinarySearchTreeNode<E> Root { get; set; }

    public void Insert(E element)
    {
        Root = InsertRec(Root, element);
    }

    public BinarySearchTreeNode<E> InsertRec(BinarySearchTreeNode<E> node, E element)
    {
        if (node == null)
        {
            return new BinarySearchTreeNode<E>(element);
        }

        if (element.CompareTo(node.Value) < 0)
        {
            node.LeftChild = InsertRec(node.LeftChild, element);
        }

        if (element.CompareTo(node.Value) > 0)
        {
            node.RightChild = InsertRec(node.RightChild, element);
        }

        if (element.CompareTo(node.Value) == 0)
        {
            node.DuplicateCount++;
        }

        return node;

    }
    public bool Contains(E element)
    {
        return ContainsRec(Root, element);
    }
    private bool ContainsRec(BinarySearchTreeNode<E> node, E element)
    {
        if (node == null)
        {
            return false;
        }
        if (element.CompareTo(node.Value) == 0)
        {
            return true;
        }
        if (element.CompareTo(node.Value) < 0)
        {
            return ContainsRec(node.LeftChild, element);
        }
        return ContainsRec(node.RightChild, element);
    }

    public AbstractBinarySearchTree<E> Search(E element)
    {
        return SearchRec(Root, element);
    }
    private AbstractBinarySearchTree<E> SearchRec(BinarySearchTreeNode<E> node, E element)
    {
        if (node == null)
        {
            return null;
        }
        if (element.CompareTo(node.Value) == 0)
        {
            AbstractBinarySearchTree<E> result = new AbstractBinarySearchTree<E>();
            result.Root = node;
            return result;
        }
        if (element.CompareTo(node.Value) < 0)
        {
            return SearchRec(node.LeftChild, element);
        }
        return SearchRec(node.RightChild, element);
    }

    public BinarySearchTreeNode<E> GetRoot()
    {
        return Root;
    }

    public BinarySearchTreeNode<E> GetLeft()
    {
        if (Root != null)
        {
            return new BinarySearchTreeNode<E>(Root.LeftChild.Value);
        }
        return null;
    }

    public BinarySearchTreeNode<E> GetRight()
    {
        if (Root != null)
        {
            return new BinarySearchTreeNode<E>(Root.LeftChild.Value);
        }
        return null;
    }

    public E GetValue()
    {
        if (Root != null)
        {
            return Root.Value;
        }

        return default(E);
    }
    

    public int CountDuplicates()
    {
        return CountDuplicatesRec(Root);
    }

    private int CountDuplicatesRec(BinarySearchTreeNode<E> node)
    {
        if (node == null)
        {
            return 0;
        }

        int count = node.DuplicateCount;
        count += CountDuplicatesRec(node.LeftChild);
        count += CountDuplicatesRec(node.RightChild);

        return count;
    }
    
    public void RemoveDuplicates()
    {
        List<E> elementsList = new List<E>();
        InOrderTraversal(Root, elementsList);
    
        var distinctElements = elementsList.Distinct().ToList();
        var newTree = new AbstractBinarySearchTree<E>();

        foreach (var element in distinctElements)
        {
            newTree.Insert(element);
        }

        Root = newTree.Root;
    }

    private void InOrderTraversal(BinarySearchTreeNode<E> node, List<E> elementsList)
    {
        if (node == null)
        {
            return;
        }

        InOrderTraversal(node.LeftChild, elementsList);
        elementsList.Add(node.Value);
        InOrderTraversal(node.RightChild, elementsList);
    }
}