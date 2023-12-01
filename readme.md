## Prio Tool
This is a utility that automatically sets the priority of running processes
based on given rules.

### Use Cases
Sometimes you have a shitty but necessary background program that you don't
want hogging your CPU time. Or you want your game to preempt absolutely
everything else. Or you are the king/queen of autists and you want to
micromanage your CPU usage. And you don't want to open Task Manager every two
minutes. Hopefully you get it.

### Requirements
- Windows 7 and up
- .NET 6.0

### Installation
**Download the current version of Prio Tool.**

Extract that zip somewhere like `C:\Extras` or wherever you put things that
don't have an installer. Then run `setup.cmd` as admin. This will register the
background service and add the configuration tool to your startup items.

### Usage
The service will be started immediately after setup and on boot.

Once that's done, you can go ahead and start the Prio Tool UI. It's a little
configuration tool for the service.

Rules can either be single or dependent. A single rule will explicitly make
sure that X process is running at Y priority, while a dependent rule will do
the same but *only* if Z process is also running.

### Configuration
While you *can* configure this by hand, it's dumb because I made you a UI. If
you really want to use my shit in the most obtuse way possible, an explanation
of the ruleset format exists in my code.
