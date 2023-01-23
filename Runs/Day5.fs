module Runs.Day5


open NUnit.Framework

open AoC.Day5


[<Test>]
let  ``Day 5 Test`` () =

    
    //     [D]    
    // [N] [C]    
    // [Z] [M] [P]
    //  1   2   3     
    
        
    let testFile = fileName + ".test"
    
    let crates,moves = getItems testFile        
    printfn "%A" crates
    printfn "%A" moves
    
    printfn "%A" (getCrates crates)
    printfn "%A" (getMoves moves)
    // let repeatedItems =  getRepeatedItem Part1.rangeIsIn items   
    //
    // printfn "%A" repeatedItems
    //
    // let points = Part1.getPoints Part1.rangeIsIn items
    // let expected = 2
    //
    // Assert.AreEqual(expected,points)
    ()