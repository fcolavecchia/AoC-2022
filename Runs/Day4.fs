module Runs.Day4




open NUnit.Framework

open AoC.Day4


[<Test>]
let  ``Day 4 Test`` () =
    
    let testFile = fileName + ".test"
    
    let items = getItems testFile        
    printfn "%A" items 
    let repeatedItems =  getRepeatedItem Part1.rangeIsIn items   
    
    printfn "%A" repeatedItems
    
    let points = Part1.getPoints Part1.rangeIsIn items
    let expected = 2
    
    Assert.AreEqual(expected,points)

 

[<Test>]
let  ``Day 4 `` () =
    
    let testFile = fileName 
    
    let items = getItems testFile        
    printfn "%A" items 
    let repeatedItems =  getRepeatedItem Part1.rangeIsIn items   
    
    printfn "%A" repeatedItems
    
    let points = Part1.getPoints Part1.rangeIsIn items
    let expected = 532
    
    Assert.AreEqual(expected,points)
       
[<Test>]
let  ``Day 4 Test, Part 2`` () =
    
    let testFile = fileName + ".test"
    
    let items = getItems testFile        
    printfn "%A" items 
    let repeatedItems =  getRepeatedItem Part2.rangeIsOut items   
    
    printfn "%A" repeatedItems
    
    let points = Part2.getPoints items
    let expected = 4
    
    Assert.AreEqual(expected,points)
    
    
[<Test>]
let  ``Day 4, Part 2`` () =
    
    let testFile = fileName 
    
    let items = getItems testFile        
    printfn "%A" items 
    let repeatedItems =  getRepeatedItem Part2.rangeIsOut items   
    
    printfn "%A" repeatedItems
    
    let points = Part2.getPoints items
    let expected = 854
    
    Assert.AreEqual(expected,points)    
       