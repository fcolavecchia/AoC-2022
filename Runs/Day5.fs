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
    
    let createItems,movesItems = getItems testFile        
    printfn "%A" createItems
    printfn "%A" movesItems
    
    printfn "%A" (getCrates createItems)
    printfn "%A" (getMoves movesItems)
    
    let crates = getCrates createItems
    let moves = getMoves movesItems
    
    // moves
    // |> List.iter 
    
    
    // let repeatedItems =  getRepeatedItem Part1.rangeIsIn items   
    //
    // printfn "%A" repeatedItems
    //
    // let points = Part1.getPoints Part1.rangeIsIn items
    // let expected = 2
    //
    // Assert.AreEqual(expected,points)
    ()