namespace BinaryTree;

public class Program
{
    static void Main()
    {
        // Создание корневого узла
        BinaryTreeNode<int> rootNode = new BinaryTreeNode<int>(10);
        
        // Создание бинарного дерева и установка корневого узла
        AbstractBinaryTree<int> binaryTree = new AbstractBinaryTree<int>();
        binaryTree.Root = rootNode;
        
        // Добавление элементов в дерево
        binaryTree.SetKey(5);
        binaryTree.SetKey(15);
        binaryTree.SetKey(3);
        binaryTree.SetKey(7);
        binaryTree.SetKey(12);
        binaryTree.SetKey(18);
        
        // Пример использования методов бинарного дерева
        Console.WriteLine("Binary Tree PreOrder:");
        foreach (var node in binaryTree.PreOrder())
        {
            Console.Write(node.GetKey() + " ");
        }
        
        Console.WriteLine("\nBinary Tree InOrder:");
        foreach (var node in binaryTree.InOrder())
        {
            Console.Write(node.GetKey() + " ");
        }
        
        Console.WriteLine("\nBinary Tree PostOrder:");
        foreach (var node in binaryTree.PostOrder())
        {
            Console.Write(node.GetKey() + " ");
        }
        Console.WriteLine();
        
        Console.WriteLine("Binary Tree InOrder using ForEachInOrder:");
        binaryTree.ForEachInOrder(key =>
        {
            Console.Write(key + " ");
        });
        Console.WriteLine();
        
        // Проверка метода AsIndentedPreOrder
        Console.WriteLine("Binary Tree AsIndentedPreOrder:");
        string indentedPreOrder = binaryTree.AsIndentedPreOrder(4);
        Console.WriteLine(indentedPreOrder);
        
        // Обход дерева в ширину
        Console.WriteLine("Binary Tree BFS (Breadth-First Search):");
        binaryTree.orderBFS();
        
        Console.WriteLine("Binary Tree DFS (Depth-First Search):");
        binaryTree.orderDFS();
        
        Console.WriteLine();
        
        // Создаем экземпляр дерева поиска с символами
        AbstractBinarySearchTree<char> tree = new AbstractBinarySearchTree<char>();

        // Добавляем символы в дерево
        tree.Insert('A');
        tree.Insert('B');
        tree.Insert('A');
        tree.Insert('C');
        tree.Insert('B');
        tree.Insert('C');

        // Печатаем дерево (может потребовать дополнительной реализации)
        PrintTree(tree.GetRoot());
        
        Console.WriteLine();

        // Подсчет повторяющихся символов
        int duplicates = tree.CountDuplicates();
        Console.WriteLine($"Количество повторяющихся символов: {duplicates}");

        // Удаление дубликатов
        tree.RemoveDuplicates();

        // Печатаем дерево после удаления дубликатов
        PrintTree(tree.GetRoot());
        
    }

    static void PrintTree(BinarySearchTreeNode<char> node)
    {
        if (node != null)
        {
            PrintTree(node.LeftChild);
            Console.Write(node.Value + " ");
            if (node.DuplicateCount != 0)
                for (int i = 0; i < node.DuplicateCount; i++)
                    Console.Write(node.Value + " ");
            PrintTree(node.RightChild);
        }
    }
}
