# Blazor Navigation Stack

A flexible navigation stack for Blazor. Easily manage complex page chains with a hierarchical navigation system ideal for wizards, multi-step forms, and nested workflows.




## Samples/Demo
<a href="https://purple-rock-0e47e3410.6.azurestaticapps.net/" target="_blank">Live Demo</a>
<table>
  <tr>
    <td align="center"><strong>Simple Usage</strong></td>
    <td align="center"><strong>Customized</strong></td>
    <td align="center"><strong>Steps</strong></td>
  </tr>
  <tr>
    <td><img src="ReadmeAssets/SimpleUsage.gif"  alt="Simple Usage Demo"></td>
    <td><img src="ReadmeAssets/Customized.gif"  alt="Customized Demo"></td>
    <td><img src="ReadmeAssets/Steps.gif"  alt="Steps Demo"></td>
  </tr>
</table>

## Installation
## Basic Usage
### Obtaining INavigationStack
All operations on the Blazor navigation stack can be done through INavigationStack interface.
INavigationStack interface can be obtained through many ways.
1. Through context
	``` razor
	<NavigationStack>  
	 <BaseContent>  
	 <button @onclick="()=>StartClicked(context)">Start</button>  
	 </BaseContent>  
	</NavigationStack>  
	  
	@code {  
	  private void StartClicked(INavigationStack stack) {  
	        //push pages to the navigation stack  
	  }  
	}
	```

2. Through cascading parameter
	
 	ComponentWithNavigationStack.razor
	``` razor
	<NavigationStack>  
	 <BaseContent>  
	 <StackPageComponent/>  
	 </BaseContent>  
	</NavigationStack>
	```
	StackPageComponent.razor
	``` razor
	@code {  
	  [CascadingParameter]  
	    public INavigationStack? NavigationStack { get; set; }  
	}
	```

3. Through @ref
	``` razor
	<NavigationStack @ref="_stack">  
	</NavigationStack>  
	  
	@code {  
	  private INavigationStack? _stack;  
	}
	```
### Add a page to the stack
+ Adding a page on top of the current  one by calling INavigationStack.Push method.
+ Remove the top most page by calling INavigationStack.Pop method
``` razor
void ReturnClicked() {  
    _stack.Pop();  
}  
RenderFragment Content() {  
    return @<div>  
  Content of the page  
  <button @onclick="ReturnClicked">Return</button>  
 </div>;  
}  
await _stack.Push(new StackPage() {  
    Content = Content(),  
});
```
### Add a page expecting a result
+ Adding a page on top of the current  one by calling INavigationStack.Push\<T> method.
+ Setting a result and pop the cuurent page by calling INavigationStack.SetResult method.

ComponentWithStack.razor
``` razor
RenderFragment Content() {  
    return @<StackPageComponent/>;  
}  
NavigationStack.Result<string> result = await _stack.Push<string>(new StackPage() {  
    Content = Content(),  
});  
if(result.IsCanceled) return;  
string? valueFromStackPage = result.Value;
```
StackPageComponent.razor
``` razor
<div>  
 <input type="text" @bind="_value"/>  
 <button @onclick="OkClicked">Ok</button>  
</div>  
  
@code {  
  [CascadingParameter]  
    public INavigationStack? NavigationStack { get; set; }  
    private string _value = "";  
    private void OkClicked() {  
        NavigationStack?.SetResult(_value);  
    }  
}
```

## Customization
