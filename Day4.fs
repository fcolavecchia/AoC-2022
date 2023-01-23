module AoC.Day4

    open System.IO 
    open General 
    let fileName = "day4.input"
    
    type Range =
        {
            Start: int
            End: int 
        }
 
    let strToRange (str: string) =
        let l = str.Split('-')
        {
            Start = int l.[0] 
            End = int l.[1]
        }
        
    let getRepeatedItem predicate rangeList =
        rangeList
        |> List.map predicate 
        |> List.countBy id
        |> List.filter (fun (b,i) -> b = true)
        

    
    let getItems file =
        General.readInput file
            |> List.map (fun s ->
                            let l = s.Split(',')
                                    |> Array.map strToRange 
                            (l[0],l[1]))
            
    
    module Part1 =

        let rangeIsIn (r1, r2) =
            (r1.Start >= r2.Start && r1.End <= r2.End) ||
               (r2.Start >= r1.Start && r2.End <= r1.End)
               
        let getPoints predicate rangeList =
            rangeList
            |> getRepeatedItem predicate 
            |> List.head
            |> snd                
            
            
    module Part2 =
       
   
        let rangeIsOut (r1, r2) =
            (r1.Start < r2.Start && r1.End < r2.Start) ||
            (r1.Start > r2.End && r1.End > r2.End)           
           
            
        let getPoints rangeList =
            let countOut =
                rangeList
                |> getRepeatedItem rangeIsOut 
                |> List.head
                |> snd
                
            rangeList.Length - countOut                
                        