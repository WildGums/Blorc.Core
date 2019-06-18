# Blorc.Core

Blorc.Core is a set of components that can be used to write Blazor libraries and apps.

## BlorcComponent

`BlorcComponentBase` is a base control for any Blazor component. It adds several new features to any component.

### Property bags

Thanks to the underlying property bag, each component will automatically support change notifications.

```
[Parameter]
public bool IsGrouped
{
    get => GetPropertyValue<bool>(nameof(IsGrouped));
    set => SetPropertyValue(nameof(IsGrouped), value);
}
```

### State converters

Because properties can be watched automatically via the property bag, it's possible to subscribe to properties and automatically update states based on property changes.

```
CreateConverter()
    .Fixed("pf-c-select")
    .If(() => IsExpanded, "pf-m-expanded")
    .Watch(() => IsExpanded)
    .Update(() => Class);
```

| Feature | Description |
|-----------------|-------------|
| Fixed | This is a fixed of constant expression that will always be added. |
| If | The state is added in case the predicate returns `true` (e.g. `IsExpanded == true`). |
| Watch | Adds a property to the watch list. The state will be re-evaluated every time a watched property changes. |
| Update | Updates a specific property with the new state. In the example above the `Class` property will be updated every time the `IsExpanded` property changes. |

## Binding system

To be described...

## DocumentService / DOM manipulation

Blazor is able to update everything within the `<app>` element. Sometimes it's necessary to update the DOM outside this element. This is possible via the `IDocumentService` that uses Javascript interop:

```
@functions
{
    [Inject]
    public IDocumentService DocumentService { get; set; }

    protected override void OnInit()
    {
        base.OnInit();

        DocumentService.InjectHead(new Css("/patternfly/patternfly.css"));
    }
}
```