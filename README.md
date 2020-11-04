# World4You
World4You is a worldbuilding tool created [Jonathon](https://github.com/JezzyDeves), [Tessa](https://github.com/tessstrube), [Maureen](https://github.com/McCormickPMP), and [Tyler](https://github.com/DocMTyler). It is an opensource solution for worldbuilding. It allows you to create People, Animals, Artifacts, and Places.
Anything can be tied to a place so you can keep track of where things are in your world.

# Walkthrough
This is a basic tutorial on how to use this API with Postman. An important thing to remember is that currently if you delete an entity that is tied to another entity (like an artifact that a person uses) **it will cause errors.**
## Step One
Create a user account using the Register endpoint and copy the token into the authorization header in Postman
## Step Two
Create a place. You need a place in order to create any other objects. This also means you can't delete a place that is attached to a person.
## Step Three
Create any other object. You can attach an artifact to an animal or person but you do not have to.
## Documentation and Planning

- The following link is to our API Documentation and quick link to run in Postman:
https://web.postman.co/collections/13066114-bf181acd-9860-42cc-a7d7-31cc595b54b7?version=latest&workspace=193a98f4-f801-4931-86c3-23e5c2f027e0

- Link to our database wireframing diagram:
https://dbdiagram.io

- Link to our Project Planning document titled Galifournia
https://docs.google.com/document/d/1TigdUKKI0JSxvOU756qDP-eUT-ePfE2I4sv69dscwwo/edit

- Link to our Google excel sheet used for planning:
https://docs.google.com/spreadsheets/d/1qJV4wjHliaUc0M_5Gej2jWAoeMws4Q28/edit#gid=1698923123

- Link to our Trello Kanban Board
https://trello.com/b/QOHcJ3Cv/galafourniaapi


## Sources to Websites used:
- Link to Data Annotations - ForeignKey Attribute in EF 6
https://www.entityframeworktutorial.net/code-first/foreignkey-dataannotations-attribute-in-code-first.aspx
- Link to connect to outside db https://www.youtube.com/watch?v=Et2khGnrIqc&t=4294s


## Importing Seed Database
A reference for connecting .NET Framework to outside Database
https://www.youtube.com/watch?reload=9&v=weE1CwfS9rI

## Contributors
Made by Jonathon Rivers, Matthew "Tyler" Hougland, Maureen McCormick and Tessa Strube
