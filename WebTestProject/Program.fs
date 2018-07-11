//open Main
open canopy
//open Example
//open SkillChecking
let x = 0

//elementTimeout <- 2.0
chromeDir <- __SOURCE_DIRECTORY__
start chrome

//runExample
//runSkillChecking
//runDemographics

run()
System.Console.WriteLine("Press any key to continue")
System.Console.ReadLine() |> ignore
quit()