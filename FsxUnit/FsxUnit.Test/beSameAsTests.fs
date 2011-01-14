﻿namespace FsxUnit.Test
open NUnit.Framework
open FsxUnit

[<TestFixture>]
type ``be SameAs tests`` ()=
    let anObj = new obj()
    let otherObj = new obj()

    [<Test>] member test.
     ``an object should be the same as itself`` ()=
        anObj |> should be (sameAs anObj)

    [<Test>] member test.
     ``an object should fail to be same as different object`` ()=
        shouldFail (fun () -> anObj |> should be (sameAs otherObj))
        
    [<Test>] member test.
     ``an object should not be same as different object`` ()=
        anObj |> should'nt be (sameAs otherObj)

    [<Test>] member test.
     ``an object should fail to not be same as itself`` ()=
        shouldFail (fun () -> anObj |> should'nt be (sameAs anObj))
