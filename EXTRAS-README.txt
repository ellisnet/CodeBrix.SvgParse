================================================================================
EXTRAS-README: CodeBrix.SvgParse
Samples, tools and other content in this repository that is not part of a
NuGet package
================================================================================

There are no sample applications, demo apps or tools in this repository.
Everything here either ships in the CodeBrix.SvgParse.MsplLicenseForever
package or exists to build and test it.

The non-package content is:


TESTS
=====
    tests/CodeBrix.SvgParse.Tests/

The xUnit v3 test project. It is not packed and is not referenced by
consumers, but it is the best available body of compiling example code for
the package -- every test builds an SVG document from an inline string and
asserts against the resulting object model. Consumers are pointed at it from
the "WORKING EXAMPLES ON GITHUB" section of AGENT-README.txt.

Run it with `dotnet test CodeBrix.SvgParse.slnx`. No opt-in environment
variables, no external fixture files, no network access -- all input is
inline SVG text.


BUILD-TIME SOURCE GENERATOR
===========================
    src/CodeBrix.SvgParse.Generators/

An incremental Roslyn source generator consumed as an analyzer by the
library project. It is marked <IsPackable>false</IsPackable> and never
appears in the NuGet package, so it is not something a consumer references
or configures. See MAINTAINER-README.txt for what it emits and why.


OPTIONAL / EMBEDDED DATA
========================
    src/CodeBrix.SvgParse/Resources/svg11.dtd

The SVG 1.1 DTD, embedded into the library assembly rather than shipped as a
loose file. It is used by the DTD resolver during parsing; there is nothing
to run or configure.
