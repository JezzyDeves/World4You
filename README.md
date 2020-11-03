# World4You
World4You is a worldbuilding tool created [Jonathon](https://github.com/JezzyDeves), [Tessa](https://github.com/tessstrube), [Maureen](https://github.com/McCormickPMP), and [Tyler](https://github.com/DocMTyler). It is an opensource solution for worldbuilding. It allows you to create People, Animals, Artifacts, and Places.
Anything can be tied to a place so you can keep track of where things are in your world.

# Walkthrough
This is a basic tutorial on how to use this API with Postman. An important thing to remember is that currently if you delete an entity that is tied to another entity (like an artifact that a person uses) it will cause errors.
## Step One
Create a user account using the Register endpoint and copy the token into the authorization header in Postman
## Step Two
Create a place. You need a place in order to create any other objects. This also means you can't delete a place that is attached to a person.
## Step Three
Create any other object. You can attach an artifact to an animal or person but you do not have to.
