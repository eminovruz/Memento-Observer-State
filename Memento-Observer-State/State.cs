class Document
{
    IState state;

    public void Render()
    {
        state.Render();
    }

    public void Publish()
    {
        state.Publish();
    }

    public void ChangeState(IState State)
    {
        state = State;
    }
}

interface IState
{
    void Render();

    void Publish();
}

class Draft : IState
{
    private Document _document;

    public void ChangeState()
        => _document.ChangeState(new Rar());
    
    public void Publish()
    {
        // Some Codes...
    }

    public void Render()
    {
        // Some Codes...
    }
}

class Rar : IState
{
    private Document _document;

    public void ChangeState()
        => _document.ChangeState(new Draft());

    public void Publish()
    {
        // Some Codes...
    }

    public void Render()
    {
        // Some Codes...
    }
}