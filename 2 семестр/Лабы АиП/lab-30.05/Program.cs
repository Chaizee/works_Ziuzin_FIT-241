using System.Runtime.InteropServices;
using System.Xml.Linq;

public unsafe struct Unit
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Unit* Left { get; set; }
    public Unit* Right { get; set; }

    public Unit(int id, string name)
    {
        Id = id;
        Name = name;
        Left = null;
        Right = null;
    }
}

public unsafe class Tree
{
    public Unit* Root;

    private Unit* CreateUnit(int id, string name)
    {
        Unit* unit = (Unit*)Marshal.AllocHGlobal(sizeof(Unit));
        unit->Id = id;
        unit->Name = name;
        unit->Left = null;
        unit->Right = null;
        return unit;
    }

    public void Free()
    {
        FreeUnit(Root);
        Root = null;
    }

    private void FreeUnit(Unit* node)
    {
        if (node == null) return;

        FreeUnit(node->Left);
        FreeUnit(node->Right);
        Marshal.FreeHGlobal((IntPtr)node);
    }

    public void Insert(int id, string name)
    {
        if (Root == null)
        {
            Root = CreateUnit(id, name);
            return;
        }

        Unit* current = Root;

        while (true)
        {
            if (id < current->Id)
            {
                if (current->Left == null)
                {
                    current->Left = CreateUnit(id, name);
                    break;
                }
                current = current->Left;
            }
            else
            {
                if (current->Right == null)
                {
                    current->Right = CreateUnit(id, name);
                    break;
                }
                current = current->Right;
            }
        }
    }

    public void Print(Unit* node)
    {
        if (node != null)
        {
            Print(node->Left);
            Console.WriteLine($"ID: {node->Id}, Name: {node->Name}");
            Print(node->Right);
        }
    }
}

public class Program
{
    public static unsafe void Main()
    {
        Tree tree = new Tree();

        tree.Insert(5, "Object 5");
        tree.Insert(3, "Object 3");
        tree.Insert(7, "Object 7");
        tree.Insert(10, "Object 10");
        tree.Insert(4, "Object 4");
        tree.Insert(12, "Object 12");
        tree.Insert(8, "Object 8");

        tree.Print(tree.Root);
        tree.Free();
    }
}