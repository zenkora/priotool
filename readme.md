## Prio Tool
This is a utility for Windows that automatically sets the priority of running
processes based on given rules.

Sometimes you have a shitty but necessary background program that you don't
want hogging your CPU time. Or you want your game to preempt absolutely
everything else. Or you are just this autistic.

### Requirements
- Windows 7 and up
- .NET 6.0

### Installation
**Download the current version of Prio Tool.**

Extract that zip somewhere like `C:\Extras` or wherever you put things that
don't have an installer. You can make shortcuts and pin them somewhere
yourself, just make sure the service starts with admin privileges.

### Usage
First, start the service with admin privileges. It'll quietly fork itself to
the background.

Once that's done, you can go ahead and start the Prio Tool UI and start making
rules, which can either be single or dependent. A single rule will explicitly
make sure that X process is running at Y priority, while a dependent rule will
do the same but *only* if Z is also running.

### Configuration
Use the UI.

### License
This is free software. See [the license file](/license.txt).
