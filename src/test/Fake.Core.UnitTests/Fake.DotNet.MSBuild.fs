module Fake.DotNet.MSBuildTests

open Fake.Core
open Fake.DotNet
open Expecto

[<Tests>]
let tests =
  testList "Fake.DotNet.MSBuild.Tests" [
    testCase "Test that we can create simple msbuild cmdline" <| fun _ ->
      let _, cmdLine =
        MSBuild.buildArgs (fun defaults ->
          { defaults with
              ConsoleLogParameters = []
              Properties = ["OutputPath", "C:\\Test\\"] })
      let expected =
        if Environment.isUnix then "\"/p:RestorePackages=False\" \"/p:OutputPath=C:\\Test\\\\\""    
        else "\"/m\" \"/nodeReuse:False\" \"/p:RestorePackages=False\" \"/p:OutputPath=C:\\Test\\\\\""    
      Expect.equal cmdLine expected "Expected a given cmdline."
  ]
