# PowerSaverX
This is a small tool for Windows to manage power schedules.

Project address: https://github.com/darnell8/PowerSaverX.git

## How to use
First create some power plans for the environment to run, the power plan set the maximum and minimum value of the CPU usage status (other options are adjusted according to the situation as appropriate).
Then just run the program.

Set the path:
Select Power Plan -> Edit Power Plan -> Processor Power Management -> Minimum Processor State/Maximum Processor State

## Principle
The principle of this tool is that instead of manually switching the power plan, every 5 seconds the program will check if there is a specific process running. If there is it switches to balanced mode or high performance mode, and anyway it switches to power saving mode.

## Origin
- Ever since I bought my laptop I've been struggling with portability and battery life. I used to be a performance-oriented person, so I purchased a Shenzhou branded machine.
- I tried installing Black Apple in the hope that it would extend the battery life a bit, but I realized that it didn't help because the CPU frequency and power consumption didn't change after monitoring. I was thinking of buying a macbook air, but apple's expensive upgrade specs dissuaded me.
- After checking the information I think what I can do at the moment is to control the power consumption caused by the CPU's crazy boost frequency in some scenarios.
- The machine is in a quiescent state: in an energy-saving power plan, the CPU frequency is roughly 1.1GHz and the total power consumption is 2W\~5W; in a balanced or high-performance power plan, the CPU frequency will remain at 3.6GHz and the total power consumption is 4W\~10W.

## Suggestions
Some feedback or suggestions are welcome.