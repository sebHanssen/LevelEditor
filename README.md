# Level Editor Exam

## Introduction
This is a project for my Tools Programming exam during my 5th semester.

In this project I will incorporate these points:

- Implement a tile-based level editor
- Tiles should affect neighbouring tiles in a sensible way
- Code written in C# and XAML
- WPF as GUI
- The tool will support serialization and deserialization
- A description of the serialization format, for importing purposes

I also decided to include this optional point:

- Use git as a version control system

## Planning
Before I started writing anything, I decided to make a plan. I made a sketch of the design,
and planned out the basic functionality I wanted in my project.

Unfortunately the sketch image is for some reason lost. Though the final product does look quite similar to my original vision.

Visualizing the way I want it to turn out first, makes it easier to code afterwards.
This is because I now have a clear goal in mind when I code. I would explain it like this:  
> *Finding your way from start to finish is easier on a path of light, than in complete darkness.*

### High level overview
The application is a tile-based level editor that is able to save and load levels.   
The user is also able to choose the size of the level.

### Design

I decided to use the MVVM design pattern, and tried to stay as true to the pattern as possible.

## Features

Current features include:
- Creating a custom-sized level
- Three default custom tiles made by me
- Click and drag functionality
- Saving and loading levels on device with JSON serializing

### Challenges

- Finding out how UserControls work and how to implement them properly
- Implementing X & Y coordinates for my tiles, before the implementation of coordinates, all tiles would change image if a single one was changed.
- Properly serializing and deserializing with a 2D Array

### Satisfactory results

- The design and layout of the windows
- The use of UserControls to minimize the amount of boilerplate in codebehind
- The click and drag functionality

### Currently known bugs
- If you have selected a tile different than empty and save the project, your selected tile will become the empty tile again.

## Formatting

Currently there are three default tiles.
- Empty | e
- Grass | g
- Water | w

Each of these represent the letter next to it in the serialization process.

## Testing
As you might have noticed, there are no tests for this project. That isn't to say that I didn't try.  

The reasoning for this, is simply that I do not know nor understand how to implement tests, when most of the functionality of this project is based on custom events.

## Further development

There are quite a few points I think this project can be further developed.

### Tiles
Add a button on the toolbar to open a new window. In this window you can choose an image (48x48 only).   
You will also have to choose a letter to use for the serialization process.

### Tilesets
Folders that contains tiles can be custom tilesets. Currently in the project I have a button for the default tileset.

### Undo/Redo
By using custom events, make a list of the last 7 changes made. The user will be able to undo/redo within these 7 changes until another change is made.   
The newest change removes the oldest change. If you undo and make a different change all redos are removed.

### Formatting
Make a better system for formatting. Currently the solution is to manually assign and check for the letters corresponding to the tiles. 

### Unity Importing
Add support for exporting levels from level editors that can be imported into unity.

### Improved saving/loading
Be able to save levels with a name, and load them with that name. That way you can have multiple levels saved.   
The current solution only allows for one level to be saved locally.