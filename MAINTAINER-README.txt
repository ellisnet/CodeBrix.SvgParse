================================================================================
MAINTAINER-README: CodeBrix.SvgParse
Notes for people and agents MAINTAINING this repository -- not for package
consumers
================================================================================

If you are CONSUMING the NuGet package, stop here and read AGENT-README.txt
instead. This file covers building, testing, packaging and the vendored
provenance of the repository itself.


PURPOSE AND SCOPE
=================
This repository produces exactly one NuGet package:

    PackageId : CodeBrix.SvgParse.MsplLicenseForever
    Assembly  : CodeBrix.SvgParse
    Project   : src/CodeBrix.SvgParse/CodeBrix.SvgParse.csproj
    License   : MS-PL (PackageLicenseExpression), PackageRequireLicenseAcceptance
    Consumer documentation: AGENT-README.txt (repo root)

A second project, src/CodeBrix.SvgParse.Generators, is a build-time
incremental source generator. It is NOT packable
(<IsPackable>false</IsPackable>) and is referenced by the library as an
analyzer:

    <ProjectReference Include="..\CodeBrix.SvgParse.Generators\..."
                      OutputItemType="Analyzer"
                      ReferenceOutputAssembly="false" />

It targets netstandard2.0 (the Roslyn analyzer host requirement) -- this is
the only place in the repository where a target other than net10.0 is
allowed.


REPOSITORY LAYOUT
=================
    AGENT-README.txt                  Consumer guide for the package.
    MAINTAINER-README.txt             This file.
    EXTRAS-README.txt                 Non-package content (there is little).
    README-INDEX.txt                  Map of the README files.
    README.md                         Human-facing overview; ships in the nupkg.
    LICENSE                           MS-PL text.
    THIRD-PARTY-NOTICES.txt           Upstream attribution; ships in the nupkg.
    icon-codebrix-128.png             Package icon; ships in the nupkg.
    CodeBrix.SvgParse.slnx            Solution. The Solution Items folder
                                      carries .gitignore, AGENT-README.txt,
                                      EXTRAS-README.txt, global.json,
                                      icon-codebrix-128.png, LICENSE,
                                      MAINTAINER-README.txt, README-INDEX.txt,
                                      README.md and THIRD-PARTY-NOTICES.txt;
                                      the Tests folder carries the test project.
    global.json                       Selects the test runner; see TESTING.
    src/CodeBrix.SvgParse/            The library.
    src/CodeBrix.SvgParse.Generators/ Build-time source generator.
    tests/CodeBrix.SvgParse.Tests/    xUnit v3 test project.

Inside src/CodeBrix.SvgParse the sources are grouped into feature folders --
"Basic Shapes", "Document Structure", "Clipping and Masking",
"Filter Effects", Painting, Paths, Text, Transforms, Primitives, Animation,
Metadata, Linking, Scripting, Interaction, Extensibility, Rendering,
SceneGraph, Compatibility, Css, Helpers, ExtensionMethods, Exceptions,
Resources.

IMPORTANT: folder names are NOT namespaces here. Only Pathing, Transforms,
FilterEffects, Primitives, Css, Exceptions and ExtensionMethods exist as
sub-namespaces; everything else declares `namespace CodeBrix.SvgParse;`
regardless of which folder it sits in. Several folders contain space
characters in their names, so quote paths in shell commands and use
find -print0 style loops.

A few files are intentionally EMPTY placeholders left from the fork --
Rendering/ISvgRenderer.cs, Rendering/IGraphicsProvider.cs,
Rendering/SvgRenderer.cs and "Clipping and Masking/ISvgClipable.cs" are all
zero bytes. Do not "fix" them by reintroducing upstream rendering
abstractions; this library is deliberately renderer-agnostic.

Resources/svg11.dtd is embedded with the logical name
"Svg.Resources.svg11.dtd" -- that logical name is deliberately the upstream
one, because the DTD resolver looks it up by that string.


BUILDING
========
    dotnet restore CodeBrix.SvgParse.slnx
    dotnet build   CodeBrix.SvgParse.slnx

Requirements: the .NET 10 SDK. global.json at the repository root does NOT pin
an SDK version, so the newest installed .NET 10 SDK is still used; it exists
solely to select the test runner -- see TESTING.

The library targets net10.0 only, with <GenerateDocumentationFile>true, so
every public member needs an XML doc comment: CS1591 must be fixed at the
source, never suppressed.

Because the generator project is wired in as an analyzer, a change to
src/CodeBrix.SvgParse.Generators only takes effect after the analyzer
assembly is rebuilt; if generated element registrations look stale, do a
clean build of the generator project first.


TESTING
=======
    dotnet test CodeBrix.SvgParse.slnx

THE TEST RUNNER IS Microsoft.Testing.Platform (MTP), selected by global.json at
the repository root:

    { "test": { "runner": "Microsoft.Testing.Platform" } }

Because that setting lives in global.json rather than in the csproj, it applies
to every `dotnet test` run anywhere in the repository, including CI. The file
has no `sdk` section and pins no SDK version. Keep it committed -- without it
`dotnet test` silently falls back to the older VSTest bridge. There is no
coverage collector: the test project references no coverlet package.

tests/CodeBrix.SvgParse.Tests uses xunit.v3 with
xunit.runner.visualstudio and Microsoft.NET.Test.Sdk. There are no opt-in
environment variables, no external test data and no network access; the
whole suite is in-memory SVG strings.

The test project reaches internal API (SvgElementFactory, SvgElement's
protected internal ElementName/Attributes) through
src/CodeBrix.SvgParse/InternalsVisibleTo.cs, which grants:

    CodeBrix.SvgParse.Tests
    CodeBrix.SkiaSvg

Keep that list short. CodeBrix.SkiaSvg is on it because the rendering
backend needs the element name and attribute collection that consumers do
not get; anything added there becomes a de-facto API contract with that
package.

Test files are named <Area>Tests.cs and live flat in the test project.


PACKAGING AND PUBLISHING
========================
Packing is driven from the library csproj, not from a script:

    <GeneratePackageOnBuild>true</GeneratePackageOnBuild>

so every build produces a .nupkg.

Versioning is date-stamped and auto-incrementing, computed in the csproj
from System.DateTime.UtcNow:

    1.<years since _VersionBaseYear>.<day of year>.<minute of day UTC>

Consequences to remember:
  - the value strictly increases over time;
  - every build produces a new version, so a fresh .nupkg per build;
  - two builds in the SAME UTC minute produce the SAME version -- never
    publish two packages from within one minute;
  - this is not SemVer: major is pinned and minor encodes the year, so
    neither signals API compatibility;
  - re-baseline by changing _VersionBaseYear.

Files that ship inside the nupkg (all via <None Include ... Pack="true">):

    icon-codebrix-128.png     (PackageIcon)
    README.md                 (PackageReadmeFile)
    AGENT-README.txt          <- the consumer guide
    THIRD-PARTY-NOTICES.txt

AGENT-README.txt is therefore a shipped artifact: an edit to it changes the
package contents. MAINTAINER-README.txt, EXTRAS-README.txt and
README-INDEX.txt are NOT packed.

The single NuGet dependency is CodeBrix.StyleSheetParse.MitLicenseForever;
the pinned version lives in the csproj and must never be copied into
AGENT-README.txt.


PROVENANCE AND VENDORED SOURCES
===============================
CodeBrix.SvgParse is a fork of the Svg.Custom project (part of the Svg.Skia
projects, v4.2.0), re-namespaced from "Svg" to "CodeBrix.SvgParse".

Vendored-source conventions:
  - Every file that was renamed carries a trailing marker on its namespace
    line, e.g.
        namespace CodeBrix.SvgParse.Transforms; //Was previously: namespace Svg.Transforms;
    Preserve those markers when editing; they are how a maintainer traces a
    file back upstream.
  - Editing the vendored sources in place is expected -- this is a fork, not
    a submodule.
  - Attribution and the upstream license live in THIRD-PARTY-NOTICES.txt,
    which ships in the package. Update it if the upstream baseline moves.
  - Deliberate divergences from upstream so far: several upstream-public
    members are internal here (SvgElementFactory, the one-argument
    SvgAttributeAttribute constructor, SvgElement.ElementName and
    SvgElement.Attributes), the rendering abstractions are gone, and the
    geometry/color primitives are library-native rather than System.Drawing.
    Do not "restore" upstream shapes without deciding that consciously --
    consumer documentation now states the current shapes as facts.


CODING CONVENTIONS
==================
  - net10.0 only. netstandard2.0 is allowed solely for the Roslyn analyzer
    host project.
  - File-scoped namespaces; the top of a file is header, usings, then the
    file-scoped namespace.
  - Nullable reference-type annotations are OFF for this repository; do not
    add `?` to reference types.
  - XML doc comments are required on public members (GenerateDocumentationFile
    is on).
  - Keep the `//Was previously:` provenance comments.
  - Comment code out rather than deleting it when the intent is to record a
    divergence from upstream.
  - Test files are named <Area>Tests.cs. The existing test methods use the
    Subject_Scenario_Expectation shape (DeepCopy_Group_CopiesChildren,
    GetElementById_ReturnsNullForMissingId); follow the file you are adding
    to rather than introducing a second style.


NOTES
=====
  - The source generator (AvailableElementsGenerator) scans the LIBRARY's own
    compilation for classes carrying [SvgElement] and emits
    `internal static class SvgElements` with an ElementNames dictionary plus
    the registrations used by the internal SvgElementFactory. None of that is
    consumer-callable, and a consumer assembly cannot register new element
    types with the parser. The generator's supporting types are Element.cs,
    Property.cs, MemberType.cs, PropertyEqualityComparer.cs and
    SyntaxReceiver.cs.
  - SvgDocumentCompatibilityLoader / SvgCssCompatibilityProcessor in the
    Compatibility folder exist to align CSS handling with browser behavior
    (stable base URI for relative stylesheet references, raw stylesheet text
    preserved for a later pass). The test suite loads through them for
    styling assertions; keep them in step with the plain SvgDocument loaders.
  - The CodeBrix.SvgParse.Css namespace is entirely internal. If a type
    there ever needs to be public, decide deliberately -- the consumer guide
    currently tells agents there is nothing there for them.
