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
    
    let crates = getCrates createItems
    let moves = getMoves movesItems
    
    printfn "%A" crates
    printfn "%A" moves
    
    let lastCrates =
        moves
        |> moveAll List.rev crates
        
    let topCrates = lastCrates |> getTopCrates              
    printfn "%A" topCrates

    let expected = "CMZ"

    Assert.AreEqual(expected,topCrates)
    
[<Test>]    
let  ``Day 5`` () =

    
    //     [D]    
    // [N] [C]    
    // [Z] [M] [P]
    //  1   2   3     
    
        
    let testFile = fileName 
    
    let createItems,movesItems = getItems testFile        
    let crates = getCrates createItems
    let moves = getMoves movesItems       
    
    let lastCrates =
        moves
        |> moveAll List.rev crates
        
    let topCrates = lastCrates |> getTopCrates              
    
    
    // let repeatedItems =  getRepeatedItem Part1.rangeIsIn items   
    //
    printfn "%A" topCrates
    //
    // let points = Part1.getPoints Part1.rangeIsIn items
    let expected = "LJSVLTWQM"
    //
    Assert.AreEqual(expected,topCrates)
     
[<Test>]
let  ``Day 5 Test, Part 2`` () =

    
    //     [D]    
    // [N] [C]    
    // [Z] [M] [P]
    //  1   2   3     
    
        
    let testFile = fileName + ".test"
    
    let createItems,movesItems = getItems testFile        
    printfn "%A" createItems
    printfn "%A" movesItems
    
    let crates = getCrates createItems
    let moves = getMoves movesItems
    
    printfn "%A" crates
    printfn "%A" moves
    
    let lastCrates =
        moves
        |> moveAll id crates
        
    let topCrates = lastCrates |> getTopCrates              
    printfn "%A" topCrates

    let expected = "MCD"

    Assert.AreEqual(expected,topCrates)
          
[<Test>]
let  ``Day 5, Part 2`` () =

    
    //     [D]    
    // [N] [C]    
    // [Z] [M] [P]
    //  1   2   3     
    
        
    let testFile = fileName
    
    let createItems,movesItems = getItems testFile        
    printfn "%A" createItems
    printfn "%A" movesItems
    
    let crates = getCrates createItems
    let moves = getMoves movesItems
    
    printfn "%A" crates
    printfn "%A" moves
    
    let lastCrates =
        moves
        |> moveAll id crates
        
    let topCrates = lastCrates |> getTopCrates              
    printfn "%A" topCrates

    let expected = "BRQWDBBJM"

    Assert.AreEqual(expected,topCrates)
                  