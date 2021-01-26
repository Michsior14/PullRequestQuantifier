﻿# Pull Request Quantifier
![.NET Core Build](https://github.com/microsoft/PullRequestQuantifier/workflows/.NET%20Core%20Build/badge.svg)
![Nuget](https://img.shields.io/nuget/v/PullRequestQuantifier.Client)

A highly customizable framework to quantify a pull request within a repository context.

Highlights

- Counts pull request changes with high accuracy
- Provides customizations through a yaml file for fine grained control over change counts
- Uses git history to provide a repository level context to the pull request

##
<details open>
  <summary display="inline"> <strong>Pull request optimization good practices</strong> </summary>
  <p/>
  <p/>
  
##### Why small changes matter:

- Time to review is less.
- Bugs are more likely to be detected.
- Share knowledge efficiently, small portions can always be assimilated better.
- Release fast to production. Small changes are always more likely to be reviewed faster with less iterations and therefore they can be released faster.
- Exercise your mind to divide big problems into smaller ones.

##### What can I do to optimize my changes:

- Quantify your PR accurately: exclude files that are not necessary to be reviewed or do not increase the review complexity. Example: autogenerated code, docs, project IDE setting files, binaries, etc.
   Check out the `Excluded` section from your `prquantifier.yaml` file.
- Split your problem into subproblems and try to code towards them.
- Don't refactor and code new features at the same time.

##### How to interpret the change counts in git diff output:

- One line was added: `+1 -0`
- One line was deleted: `+0 -1`
- One line was modified: `+1 -1` (git diff doesn't know about modified, it will interpret that line like one addition plus one deletion)

</details>

## 

<details open>
  <summary display="inline"> <strong>Clients</strong> </summary>
<p/>
  <p/>
 The following open source clients are supported:

| - | Name | Example |
|------|------|---------|
| <a href="./src/Clients/PullRequestQuantifier.Local.Client"><img src="./docs/images/cli-icon.png" width="50"/></a>  | [CLI](./src/Clients/PullRequestQuantifier.Local.Client) | ![](./docs/images/client-cli.png) |
| <a href="./src/Clients/PullRequestQuantifier.Vsix.Client"><img src="./docs/images/visual-studio-icon.png" width="50"/></a>  | [Visual Studio](./src/Clients/PullRequestQuantifier.Vsix.Client) | ![](./docs/images/client-vsix.png) |
| <a href="./src/Clients/PullRequestQuantifier.GitHub.Client"><img src="./docs/images/github-icon.png" width="50"/></a>  | [GitHub](./src/Clients/PullRequestQuantifier.GitHub.Client) | ![](./docs/images/client-github.png) |


</details>


##

<details>
  <summary display="inline"> <strong>How to develop new clients</strong> </summary>
  <p/>
  <p/>
Three steps

1. Load the context, if available
1. Call Quantifier
1. Output the results

```c#
// 1. point to the context file (with behavior specification)
var contextFile = "path/to/context/file/prquantifier.yaml";

// 2. quantify local git repository

var quantifyClient = new QuantifyClient(contextFile);
var quantifierResult = await quantifyClient.Compute("path/to/local/git/repo");

// 3. output the results
Console.WriteLine(quantifierResult.Label);
Console.WriteLine(quantifierResult.QuantifiedLinesAdded);
Console.WriteLine(quantifierResult.QuantifiedLinesDeleted);
```

</details>

## 


<details>
  <summary display="inline"> <strong>Context customization</strong> </summary>
  <p/>
  <p/>
  
  See [context specification](./docs/prquantifier-yaml.md) for details of the yaml-based customization.

[Download latest vesion of context generator](https://github.com/microsoft/PullRequestQuantifier/releases) and run it from the command line inside a git repository.

![](./docs/images/client_context_generator.png) 

</details>

## 

<details>
  <summary display="inline"> <strong>Developing</strong> </summary>
  <p/>
  <p/>
  PullRequestQuantifier uses `netstandard2.1` for the main library(PullRequestQuantifier.Client) and `net5.0` for the unit tests (Xunit).

[Coding guildelines](./docs/CSharpCodingGuidelines.md)
</details>

##

<details>
  <summary display="inline"> <strong>Build</strong> </summary>
  <p/>
  <p/>
  From the root directory

```
dotnet build .\PullRequestQuantifier.sln
```
</details>

##

<details>
  <summary display="inline"> <strong>Test</strong> </summary>
  <p/>
  <p/>
  From the root directory

```
dotnet test .\PullRequestQuantifier.sln
```
</details>

## 

<details>
  <summary display="inline"> <strong>Contributing</strong> </summary>
  <p/>
  <p/>
  This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.opensource.microsoft.com.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., status check, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
</details>



## 

<details>
  <summary display="inline"> <strong>Trademarks</strong> </summary>
  <p/>
  <p/>
This project may contain trademarks or logos for projects, products, or services. Authorized use of Microsoft 
trademarks or logos is subject to and must follow 
[Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/en-us/legal/intellectualproperty/trademarks/usage/general).
Use of Microsoft trademarks or logos in modified versions of this project must not cause confusion or imply Microsoft sponsorship.
Any use of third-party trademarks or logos are subject to those third-party's policies.
</details>


