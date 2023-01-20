module Runs

open NUnit.Framework

open AoC 

[<SetUp>]
let Setup () =
    ()

[<Test>]
let rec ``Day 1 Test`` () =
    
    let testFile = Day1.fileName + ".test"
    
    let lines = Day1.readInput testFile
    
    let elves = Day1.chunkBySpace lines
    
    printfn "%A" lines
    printfn "%A" elves
    
    let expected = [(0, ["1000"; "2000"; "3000"]); (1, ["4000"]); (2, ["5000"; "6000"]);
                    (3, ["7000"; "8000"; "9000"]); (4, ["10000"])]
    
    let m = Day1.maxElfCalories (Day1.elfCalories lines) 
    printfn "%A" m

    Assert.AreEqual(expected,elves)
    

[<Test>]
let rec ``Day 1`` () =
    
    let testFile = Day1.fileName 
    
    let lines = Day1.readInput testFile
    
    let elves = Day1.chunkBySpace lines
    
    // printfn "%A" lines
    // printfn "%A" elves

    // Part 1  
    let answerPart1 = 69626
    let m = Day1.maxElfCalories (Day1.elfCalories lines) 
    printfn "%A" m

    // Part 2
    let top3 = Day1.top3ElfCalories (Day1.elfCalories lines)
    let top3Expected = [69626; 68657; 68497]
    let top3Sum = (top3 |> List.sum)
    printfn "%A"  top3Sum 
    
    let answerPart2 = 206780
    Assert.AreEqual(top3Expected,top3)
    Assert.AreEqual(top3Sum,answerPart2)
    Assert.AreEqual(answerPart1,m)    
