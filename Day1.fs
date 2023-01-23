namespace AoC

open System
open System.IO

module General =
    let aocPath = "/Users/flavioc/Codes/AoC/2022"
    
    let readInput file =
        let lines = File.ReadLines(Path.Combine(aocPath,file))
                    |> Seq.toList  
        
        lines    

module Day1 =
    
    let fileName = "day1.input"
 
    type Elves = (int * int list) list 
    
    let readInput file =
        let lines = File.ReadLines(Path.Combine(General.aocPath,file))
                    |> Seq.toList  
        
        lines
        
    let chunkBySpace l =
        
        let rec loop n list outList =
            let idxOpt = list
                            |> List.tryFindIndex (fun s -> String.IsNullOrEmpty(s) )
            match idxOpt with
            | Some idx -> 
                let s = list.[0..idx-1]
                let tail = list.[idx+1..] 
                
                let nextList =  List.append outList [(n,s)] 
                loop (n+1) tail nextList 
            | None ->
                List.append outList [(n,list)] 
        loop 0 l []
                                
    let elfCalories lines =
        chunkBySpace lines
        |> List.map (fun (i,s) -> (i,s |> List.map int)) 
        
    let maxElfCalories (elves: Elves) =
        elves
        |> List.map (fun (i,s) ->  List.sum s)
        |> List.max
        
    let top3ElfCalories (elves: Elves) =
        elves
        |> List.map (fun (i,s) ->  List.sum s)
        |> List.sortDescending
        |> List.take 3         
        
        