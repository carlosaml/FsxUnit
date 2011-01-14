﻿namespace FsxUnit.Test
open NUnit.Framework
open FsxUnit


type AlwaysEqual() =
    override this.Equals(other) = true
    override this.GetHashCode() = 1

    
type NeverEqual() =
    override this.Equals(other) = false
    override this.GetHashCode() = 1


[<TestFixture>]
type ``equal Tests`` ()=
    let anObj = new obj()
    let otherObj = new obj()
    
    [<Test>] member test.
     ``value type should equal equivalent value`` ()=
        1 |> should equal 1
    
    [<Test>] member test.
     ``value type should fail to equal nonequivalent value`` ()=
        shouldFail (fun () -> 1 |> should equal 2)
    
    [<Test>] member test.
     ``value type should not equal nonequivalent value`` ()=
        1 |> should'nt equal 2

    [<Test>] member test.
     ``value type should fail to not equal equivalent value`` ()=
        shouldFail (fun () -> 1 |> should'nt equal 1)

    [<Test>] member test.
     ``reference type should equal itself`` ()=
        anObj |> should equal anObj

    [<Test>] member test.
     ``reference type should fail to equal other`` ()=
        shouldFail (fun () -> anObj |> should equal otherObj)
        
    [<Test>] member test.
     ``reference type should not equal other`` ()=
        anObj |> should'nt be (equal otherObj)

    [<Test>] member test.
     ``reference type should fail to not equal itself`` ()=
        shouldFail (fun () -> anObj |> should not (equal anObj))

    [<Test>] member test.
     ``should pass when Equals returns true`` ()=
        anObj |> should be (equal (new AlwaysEqual()))
    
    [<Test>] member test.
     ``should fail when Equals returns false`` ()=
        shouldFail (fun () -> anObj |> should equal (new NeverEqual()))
        
    [<Test>] member test.
     ``should pass when negated and Equals returns false`` ()=
        anObj |> should'nt be (equal (new NeverEqual()))

    [<Test>] member test.
     ``should fail when negated and Equals returns true`` ()=
        shouldFail (fun () -> anObj |> should'nt be (equal (new AlwaysEqual())))
