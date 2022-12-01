#nullable disable

class TabMemento
{
    public string Name { get; set; }
    public byte Size { get; set; }
}

class TabOriginator
{
    public string Name { get; set; }
    public byte Size { get; set; }

    internal TabUndoCareTaker TabUndoCareTaker
    {
        get => default;
        set
        {
        }
    }

    private TabUndoCareTaker _tabCareTaker;

    public TabOriginator()
    {
        _tabCareTaker = new TabUndoCareTaker();
    }

    public void Save()
    {
        _tabCareTaker.TextMemento = new TabMemento
        {
            Name = this.Name,
            Size = this.Size
        };
    }

    public void Undo()
    {
        TabMemento previousTextMemento = _tabCareTaker.TextMemento;

        Name = previousTextMemento.Name;
        Size = previousTextMemento.Size;
    }
    public override string ToString()
        => $"Name: {Name}, Size: {Size.ToString()}";
}

class TabUndoCareTaker
{
    private Stack<TabMemento> _mementos;

    public TabUndoCareTaker()
    {
        _mementos = new Stack<TabMemento>();
    }

    public TabMemento TextMemento
    {
        get
        {
            return _mementos.Pop();
        }
        set
        {
            _mementos.Push(value);
        }
    }
}
