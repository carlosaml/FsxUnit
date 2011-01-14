﻿namespace FsxUnit.Test
open NUnit.Framework
open FsxUnit

[<TestFixture>]
type ``be Null tests`` ()=
    [<Test>] member test.
     ``null should be Null`` ()=
        null |> should be Null

    [<Test>] member test.
     ``null should fail to not be Null`` ()=
        shouldFail (fun () -> null |> should'nt be Null)
        
    [<Test>] member test.
     ``non-null should fail to be  Null`` ()=
        shouldFail (fun () -> "something" |> should be Null)
        
    [<Test>] member test.
     ``non-null should not be Null`` ()=
        "something" |> should'nt be Null
