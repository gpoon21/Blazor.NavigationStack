using Microsoft.AspNetCore.Components;

namespace Blazor.NavigationStack;

public class StackPage {
    public string? Name {
        get { return _name; }
        init { _name = value; }
    }

    private string? _name;
    public required RenderFragment Content { get; init; }

    public RenderFragment? Menu {
        get { return _menu; }
        init { _menu = value; }
    }

    private RenderFragment? _menu;

    private readonly TaskCompletionSource<object> _tcs = new();

    public Task<object> Task {
        get { return _tcs.Task; }
    }

    internal void SetMenu(RenderFragment renderFragment) {
        _menu = renderFragment;
    }

    internal void SetName(string name) {
        _name = name;
    }

    internal void SetResult((bool isCanceled, object? value) value) {
        _tcs.SetResult(value);
    }


}