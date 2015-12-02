# Introduction #

NUnit.exe can be used to exercise the various features of the OpenCBR framework DLL.

# Details #
  * Download the OpenCBR code and the latest NUnit (2.4.6 as of this writing).

  * Open the Visual Studio Project and add the NUnit framework and make sure that it builds.

  * Specify the path to where nunit.exe got installed (C:\Program Files\NUnit 2.4.6\bin\nunit.exe by default).

  * You can now set breakpoints on any of the **test.....cs** files that make up the Testcases and see how the interactions with the OpenCBR framework unfold.

  * All the tests should work apart from testDefaultOCBRFile.cs (casebase specification.txt is missing) and testEuclideanSimilarity.cs (exercise for the reader ;-)