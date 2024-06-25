<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/282256455/20.1.6%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T917398)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# RichEdit for ASP.NET Core - How to load/save documents from/to a database

This example illustrates how to load and save a document from/to a database. You can do this as follows:

1. Create a model, register the database context, and add a connection string.
2. Pass a model with a binary property (rich text content to be displayed) to RichEdit's view.
3. Use the [RichEditBuilder.Open(Func<Byte[]>, DocumentFormat)](https://docs.devexpress.com/AspNetCore/DevExpress.AspNetCore.RichEdit.RichEditBuilder.Open(System.Func-System.Byte----DevExpress.AspNetCore.RichEdit.DocumentFormat)?p=netframework) method to open a new document with the necessary rich content type and retrieve the binary content from the passed model.

```razor
@(Html.DevExpress().RichEdit("richEdit")
    ...
    .ExportUrl(Url.Action("SaveDocument"))
    .Open(() => { return Model.DocumentBytes; }, (DevExpress.AspNetCore.RichEdit.DocumentFormat)Model.DocumentFormat)
)
```

4. Set the ExportUrl property and implement an action method to save the file:

```csharp
public IActionResult SaveDocument(string base64, string fileName, int format, string reason)
{
	byte[] fileContents = System.Convert.FromBase64String(base64);
	//Database saving logic here
	return Ok();
}
```

<!-- default file list --> 
*Files to look at*:

* [Index.cshtml](./CS/Views/Home/Index.cshtml)
* [HomeController.cs](./CS/Controllers/HomeController.cs)
* [DocumentInfo.cs](./CS/Models/DocumentInfo.cs)
* [DocsDbContext.cs](./CS/Models/DocsDbContext.cs)
* [Startup.cs](./CS/Startup.cs)
* [appsettings.json](./CS/appsettings.json)
<!-- default file list end -->
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-core-richedit-work-with-database&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=asp-net-core-richedit-work-with-database&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
